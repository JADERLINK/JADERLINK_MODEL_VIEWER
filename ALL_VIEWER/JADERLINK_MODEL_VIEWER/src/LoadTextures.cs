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
            foreach (var TexPath in Paths)
            {
                FileInfo fileInfo = new FileInfo(TexPath);
                string format = fileInfo.Extension.ToUpperInvariant();
                string name = fileInfo.Name.ToLowerInvariant();
                string folder = fileInfo.Directory.Name.ToLowerInvariant();
                string texId = folder + "/" + name;

                Bitmap bitmap = null;

                if (File.Exists(TexPath))
                {
                    switch (format)
                    {
                        case ".TGA":
                            try
                            {
                                TGASharpLib.TGA nTGA = new TGASharpLib.TGA(TexPath);
                                bitmap = nTGA.ToBitmap();
                            }
                            catch (Exception)
                            {
                            }
                            break;
                        case ".DDS":
                            try
                            {
                                byte[] filedds = File.ReadAllBytes(TexPath);
                                bitmap = DDSReaderSharp.ToBitmap(filedds);
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
                               bitmap = new Bitmap(stream, false);
                            }
                            catch (Exception)
                            {
                            }
                            break;
                        default:
                            break;
                    }

                }

                if (bitmap != null)
                {
                    // texturas
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

                    // GL das texturas
                    modelGroup.AddTextureRef(new Dictionary<string, Bitmap> { { texId, bitmap} });
                }

            }

        }

    }
}
