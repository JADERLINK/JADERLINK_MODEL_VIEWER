using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using ViewerBase;
using System.IO;
using OpenTK;
using JADERLINK_MODEL_VIEWER.src.Nodes;

namespace JADERLINK_MODEL_VIEWER.src
{
    public class LoadMTL
    {
        private ModelGroup modelGroup;
        private ModelNodeGroup mng;
        private TexturePackNodeGroup tpng;

        public LoadMTL(ModelGroup modelGroup, ModelNodeGroup mng, TexturePackNodeGroup tpng)
        {
            this.modelGroup = modelGroup;
            this.mng = mng;
            this.tpng = tpng;
        }

        public void Load(string Path)
        {

            FileInfo fileInfo = new FileInfo(Path);
            string FileID = fileInfo.Name.ToUpperInvariant();
            string diretory = fileInfo.DirectoryName + "\\";

            if (modelGroup.MaterialGroupDic.ContainsKey(FileID))
            {
                var node = mng.Nodes.Find(FileID, false).FirstOrDefault();
                ((NodeItem)node)?.Responsibility.ReleaseResponsibilities();
                node?.Remove();
            }

            if (!modelGroup.MaterialGroupDic.ContainsKey(FileID))
            {
                List<ObjLoader.Loader.Data.Material> MtlMaterials = new List<ObjLoader.Loader.Data.Material>();

                try
                {
                    var mtlLoaderFactory = new ObjLoader.Loader.Loaders.MtlLoaderFactory();
                    var mtlLoader = mtlLoaderFactory.Create();
                    var streamReaderMtl = new StreamReader(fileInfo.OpenRead(), Encoding.ASCII);
                    ObjLoader.Loader.Loaders.LoadResultMtl arqMtl = mtlLoader.Load(streamReaderMtl);
                    streamReaderMtl.Close();
                    MtlMaterials = arqMtl.Materials.ToList();
                }
                catch (Exception)
                {
                }

                if (MtlMaterials.Count != 0)
                {
                    ResponsibilityContainer RContainer = new ResponsibilityContainer();
                    MatTexGroup_Representation matTexGroup_Representation = new MatTexGroup_Representation(FileID);
                    MatTexGroupResponsibility matTexGroupResponsibility = new MatTexGroupResponsibility(modelGroup, matTexGroup_Representation);
                    RContainer.Add(matTexGroupResponsibility);
                    MaterialGroup_Representation materialGroup_Representation = new MaterialGroup_Representation(FileID);
                    MaterialGroupResponsibility materialGroupResponsibility = new MaterialGroupResponsibility(modelGroup, materialGroup_Representation);
                    RContainer.Add(materialGroupResponsibility);

                    MatTexGroup matTexGroup = new MatTexGroup(FileID);
                    MaterialGroup materialGroup = new MaterialGroup(FileID);

                    List<string> texturesList = new List<string>();
                    foreach (var mat in MtlMaterials)
                    {
                        string materialName = mat.Name.ToUpperInvariant();

                        Material material = new Material(materialName);
                        material.MatColor = Vector4.One;
                        material.DiffuseMatTex = "";
                        material.AlphaMatTex = "";
                        material.AsAlphaTex = false;

                        //-- textura principal
                        if (mat.DiffuseTextureMap != null)
                        {
                            string texNameRef = "";
                            try
                            {
                                FileInfo texInfo = new FileInfo(mat.DiffuseTextureMap);
                                string texname = texInfo.Name.ToLowerInvariant();
                                string texfolder = texInfo.Directory.Name.ToLowerInvariant();
                                string texfolderToFullFolder = texInfo.Directory.Name.ToLowerInvariant() + "\\";
                                string fullfolder = texInfo.Directory.FullName;
                                if (fullfolder == Directory.GetCurrentDirectory())
                                {
                                    texfolder = fileInfo.Directory.Name.ToLowerInvariant();
                                    texfolderToFullFolder = "";
                                }
                                texNameRef = texfolder + "/" + texname;
                                string texFullFolder = diretory + texfolderToFullFolder + texname;
                                if (!texturesList.Contains(texFullFolder))
                                {
                                    texturesList.Add(texFullFolder);
                                }
                            }
                            catch (Exception)
                            {
                            }

                            material.DiffuseMatTex = texNameRef;
                            MatTex matTex = new MatTex(texNameRef);
                            matTex.TextureName = texNameRef;
                            if (!matTexGroup.MatTexDic.ContainsKey(texNameRef))
                            {
                                matTexGroup.MatTexDic.Add(texNameRef, matTex);
                            }
                          
                        }

                        //---- textura transparencia
                        if (mat.AlphaTextureMap != null)
                        {
                            string texNameRef = "";
                            try
                            {
                                FileInfo texInfo = new FileInfo(mat.AlphaTextureMap);
                                string texname = texInfo.Name.ToLowerInvariant();
                                string texfolder = texInfo.Directory.Name.ToLowerInvariant();
                                string texfolderToFullFolder = texInfo.Directory.Name.ToLowerInvariant() + "\\";
                                string fullfolder = texInfo.Directory.FullName;
                                if (fullfolder == Directory.GetCurrentDirectory())
                                {
                                    texfolder = fileInfo.Directory.Name.ToLowerInvariant();
                                    texfolderToFullFolder = "";
                                }
                                texNameRef = texfolder + "/" + texname;
                                string texFullFolder = diretory + texfolderToFullFolder + texname;
                                if (!texturesList.Contains(texFullFolder))
                                {
                                    texturesList.Add(texFullFolder);
                                }
                            }
                            catch (Exception)
                            {
                            }

                            material.AlphaMatTex = texNameRef;
                            material.AsAlphaTex = texNameRef.Length > 0;
                            MatTex matTex = new MatTex(texNameRef);
                            matTex.TextureName = texNameRef;
                            if (!matTexGroup.MatTexDic.ContainsKey(texNameRef))
                            {
                                matTexGroup.MatTexDic.Add(texNameRef, matTex);
                            }
                        }

                        if (!materialGroup.MaterialsDic.ContainsKey(materialName))
                        {
                            materialGroup.MaterialsDic.Add(materialName, material);
                        }
                     
                    }
                    
                    modelGroup.AddMatTexGroup(matTexGroup);
                    modelGroup.AddMaterialGroup(materialGroup);

                    //node
                    NodeMatRef nodeMatRef = new NodeMatRef();
                    nodeMatRef.Name = FileID;
                    nodeMatRef.SetFileID(FileID);
                    nodeMatRef.Text = fileInfo.Name;
                    nodeMatRef.Responsibility = RContainer;
                    mng.Nodes.Add(nodeMatRef);

                    // load textures

                    LoadTextures textures = new LoadTextures(modelGroup, tpng);
                    textures.Load(texturesList.ToArray());
                }


            }


        }
    }
}
