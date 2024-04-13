﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using ShaderLoader;
using ViewerBase;

namespace Re4ViewerRender
{
    /// <summary>
    /// Classe destinada a renderizar tudo no cenario (No ambiente GL);
    /// </summary>
    public static class TheRender
    {
        public static bool RenderTextures = true;
        public static bool RenderWireframe = false;
        public static bool RenderNormals = false;
        public static bool RenderOnlyFrontFace = false;

        public static void Render(ref Matrix4 camMtx, ref Matrix4 projMatrix, RenderOrder order, ModelGroup modelGroup, Shader objShader, TextureRef whiteTex, Color SkyColor, Vector3 camPos)
        {
            GL.ClearColor(SkyColor);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            //---------------

            if (RenderWireframe)
            {
                GL.Disable(EnableCap.CullFace);
                GL.CullFace(CullFaceMode.FrontAndBack);
                GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line);
                GL.LineWidth(1.5f);
            }
            else 
            {
                GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);

                if (RenderOnlyFrontFace)
                {
                    GL.Enable(EnableCap.CullFace);
                    GL.CullFace(CullFaceMode.Front);
                }
                else
                {
                    GL.CullFace(CullFaceMode.FrontAndBack);
                    GL.Disable(EnableCap.CullFace);
                }
            }

            GL.FrontFace(FrontFaceDirection.Cw);

            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.Texture2D);

            objShader.Use();
            objShader.SetMatrix4("view", camMtx);
            objShader.SetMatrix4("projection", projMatrix);

            objShader.SetMatrix4("mRotation", Matrix4.Identity);
            objShader.SetVector3("mScale", Vector3.One);
            objShader.SetVector3("mPosition", Vector3.Zero);

            objShader.SetVector3("CameraPosition", camPos);
            objShader.SetVector4("matColor", Vector4.One);
            //objShader.SetVector4("smxColor", Vector4.One);
            
            if (RenderNormals)
            {
                objShader.SetInt("EnableNormals", 1);
            }
            else
            {
                objShader.SetInt("EnableNormals", 0);
            }


            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
            GL.Enable(EnableCap.AlphaTest);
            GL.AlphaFunc(AlphaFunction.Gequal, 0.001f); //Gequal

            //tex
            whiteTex.Use(TextureUnit.Texture0);
            whiteTex.Use(TextureUnit.Texture1);

            //lista de modelos
            foreach (var item in order.MeshOrder)
            {
                //chamadas da textura
                var mesh = modelGroup.MeshParts[item.mesh];
                var modelID = mesh.RefModelID;
                var material = modelGroup.MaterialGroupDic[modelID].MaterialsDic[mesh.MaterialRef];

                if (RenderTextures)
                {
                    //objShader.SetVector4("smxColor", item.smxEntry.SmxColor);
                    objShader.SetVector4("matColor", material.MatColor);

                    whiteTex.Use(TextureUnit.Texture0);
                    whiteTex.Use(TextureUnit.Texture1);
                    {
                        var matTexGroupName = modelGroup.MatLinkerDic[modelID].MatTexGroupName;
                        if (modelGroup.MatTexGroupDic.ContainsKey(matTexGroupName))
                        {
                            var MatTexGroup = modelGroup.MatTexGroupDic[matTexGroupName];

                            if (MatTexGroup.MatTexDic.ContainsKey(material.DiffuseMatTex))
                            {
                                var matTex = MatTexGroup.MatTexDic[material.DiffuseMatTex];
                                if (modelGroup.TextureRefDic.ContainsKey(matTex.TextureName))
                                {
                                    var texture = modelGroup.TextureRefDic[matTex.TextureName];
                                    texture.Use(TextureUnit.Texture0);
                                }
                            }

                            if (material.AsAlphaTex)
                            {
                                if (MatTexGroup.MatTexDic.ContainsKey(material.AlphaMatTex))
                                {
                                    var matTex = MatTexGroup.MatTexDic[material.AlphaMatTex];
                                    if (modelGroup.TextureRefDic.ContainsKey(matTex.TextureName))
                                    {
                                        var texture = modelGroup.TextureRefDic[matTex.TextureName];
                                        texture.Use(TextureUnit.Texture1);
                                    }
                                }
                            }

                        }
                    }

                }

                if (RenderWireframe == false && RenderOnlyFrontFace == true)
                {
                    if (item.smxEntry.FaceCulling == SmxFaceCulling.OnlyBack)
                    {
                        GL.Enable(EnableCap.CullFace);
                        GL.CullFace(CullFaceMode.Back);
                    }
                    else if (item.smxEntry.FaceCulling == SmxFaceCulling.FrontAndBack)
                    {
                        GL.CullFace(CullFaceMode.FrontAndBack);
                        GL.Disable(EnableCap.CullFace);
                    }
                    else // only front
                    {
                        GL.Enable(EnableCap.CullFace);
                        GL.CullFace(CullFaceMode.Front);
                    }
                }

                //modelo
                objShader.SetMatrix4("mRotation", item.smdEntry.Fix.GetRotation());
                objShader.SetVector3("mScale", item.smdEntry.Fix.Scale);
                objShader.SetVector3("mPosition", item.smdEntry.Fix.Position);
                mesh.Render();
            }

            GL.Disable(EnableCap.AlphaTest);
            GL.Disable(EnableCap.Blend);

            //---------------

            GL.Finish();
        }
    }
}
