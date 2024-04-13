﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewerBase;
using TGASharpLib;
using System.IO;
using System.Drawing;
using OpenTK;
using JADERLINK_MODEL_VIEWER.src.Nodes;


namespace RE4_2007_MODEL_VIEWER.src
{
    public class LoadTGA
    {
        private ModelGroup modelGroup;
        private TexturePackNodeGroup tpng;

        public LoadTGA(ModelGroup modelGroup, TexturePackNodeGroup tpng)
        {
            this.modelGroup = modelGroup;
            this.tpng = tpng;
        }

        public void LoadTga(string[] TGAPath)
        {
            Dictionary<string, Bitmap> textureDic = new Dictionary<string, Bitmap>();
            foreach (var TexPath in TGAPath)
            {
                string key = new FileInfo(TexPath).Name.ToLowerInvariant();

                if (!textureDic.ContainsKey(key))
                {
                    if (File.Exists(TexPath))
                    {
                        try
                        {
                            TGASharpLib.TGA nTGA = new TGASharpLib.TGA(TexPath);
                            textureDic.Add(key, nTGA.ToBitmap());
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
            }

            //------
            // texturas
            foreach (var texId in textureDic.Keys)
            {
                if (modelGroup.TextureRefDic.ContainsKey(texId))
                {
                    var node = tpng.Nodes.Find(texId, false).FirstOrDefault();
                    ((NodeItem)node)?.Responsibility.ReleaseResponsibilities();
                    node?.Remove();
                }

                ResponsibilityContainer texContainer = new ResponsibilityContainer();
                TEX_Representation tex_representation = new TEX_Representation(texId, new List<string>() { texId });
                TextureGroupResponsibility textureGroupResponsibility = new TextureGroupResponsibility(modelGroup, tex_representation);
                texContainer.Add(textureGroupResponsibility);

                NodeTexture nodeTexture = new NodeTexture();
                nodeTexture.Name = texId;
                nodeTexture.Text = texId;
                nodeTexture.Responsibility = texContainer;
                tpng.Nodes.Add(nodeTexture);
            }

            // GL das texturas
            modelGroup.AddTextureRef(textureDic);

        }


    }
}
