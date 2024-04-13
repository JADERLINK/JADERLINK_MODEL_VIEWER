using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewerBase;
using System.IO;
using System.Drawing;
using OpenTK;
using JADERLINK_MODEL_VIEWER.src.Nodes;


namespace JADERLINK_MODEL_VIEWER.src
{
    public class LoadTextures
    {
        private ModelGroup modelGroup;
        private TexturePackNodeGroup tpng;

        public LoadTextures(ModelGroup modelGroup, TexturePackNodeGroup tpng)
        {
            this.modelGroup = modelGroup;
            this.tpng = tpng;
        }

        public void Load(string[] Paths)
        {
            Dictionary<string, Bitmap> textureDic = new Dictionary<string, Bitmap>();
            foreach (var TexPath in Paths)
            {
                FileInfo fileInfo = new FileInfo(TexPath);
                string format = fileInfo.Extension.ToUpperInvariant();
                string name = fileInfo.Name.ToLowerInvariant();
                string folder = fileInfo.Directory.Name.ToLowerInvariant();
                string key = folder + "/" + name;

                if (!textureDic.ContainsKey(key))
                {
                    if (File.Exists(TexPath))
                    {
                        switch (format)
                        {
                            case ".TGA":
                                try
                                {
                                    TGASharpLib.TGA nTGA = new TGASharpLib.TGA(TexPath);
                                    textureDic.Add(key, nTGA.ToBitmap());
                                }
                                catch (Exception)
                                {
                                }
                                break;
                            case ".DDS":
                                try
                                {
                                    byte[] filedds = File.ReadAllBytes(TexPath);
                                    Bitmap bitmap = DDSReaderSharp.ToBitmap(filedds);
                                    textureDic.Add(key, bitmap);
                                }
                                catch (Exception)
                                {
                                }
                                break;
                            case ".PNG":
                            case ".GIF":
                            case ".BMP":
                            case ".JPG":
                            case ".JPEG":
                                try
                                {
                                    Stream stream = fileInfo.OpenRead();
                                    Bitmap bitmap = new Bitmap(stream, false);
                                    textureDic.Add(key, bitmap);
                                }
                                catch (Exception)
                                {
                                }
                                break;
                            default:
                                break;
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
