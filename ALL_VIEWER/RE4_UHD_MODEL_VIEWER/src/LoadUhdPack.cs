using System;
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
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace RE4_UHD_MODEL_VIEWER.src
{
    public class LoadUhdPack
    {
        private ModelGroup modelGroup;
        private TexturePackNodeGroup tpng;

        public LoadUhdPack(ModelGroup modelGroup, TexturePackNodeGroup tpng)
        {
            this.modelGroup = modelGroup;
            this.tpng = tpng;
        }

        public void LoadPack(string packPath) 
        {

            FileInfo fileInfo = new FileInfo(packPath);
            string FileID = fileInfo.Name.ToUpperInvariant();

            Dictionary<string, Bitmap> textureDic = new Dictionary<string, Bitmap>();
            Dictionary<string, string> textureExtension = new Dictionary<string, string>();

            try
            {
                var pack = new BinaryReader(fileInfo.OpenRead());

                uint PackID = pack.ReadUInt32();
                uint Amount = pack.ReadUInt32();

                List<uint> offsets = new List<uint>();

                for (int i = 0; i < Amount; i++)
                {
                    uint offset = pack.ReadUInt32();
                    offsets.Add(offset);
                }

                for (int i = 0; i < offsets.Count; i++)
                {
                    if (offsets[i] != 0)
                    {
                        pack.BaseStream.Position = offsets[i];
                        uint fileLength = pack.ReadUInt32();
                        uint ff_ff_ff_ff = pack.ReadUInt32();
                        uint PackID_ = pack.ReadUInt32();
                        uint Type = pack.ReadUInt32();

                        string Extension = "NULL";
                        string texkey = PackID.ToString("X8") + "/" + i.ToString("D4");

                        byte[] imagebytes = new byte[fileLength];
                        pack.BaseStream.Read(imagebytes, 0, (int)fileLength);

                        uint imagemagic = BitConverter.ToUInt32(imagebytes, 0);
                        if (imagemagic == 0x20534444)
                        {
                            Extension = "DDS";

                            try
                            {
                                Bitmap bitmap = DDSReaderSharp.ToBitmap(imagebytes);
                                textureDic.Add(texkey, bitmap);
                            }
                            catch (Exception)
                            {
                            }
                          
                        }
                        else
                        {
                            Extension = "TGA";

                            try
                            {
                                TGASharpLib.TGA nTGA = new TGASharpLib.TGA(imagebytes);
                                textureDic.Add(texkey, nTGA.ToBitmap(true));
                            }
                            catch (Exception)
                            {
                            }
                          
                        }

                        textureExtension.Add(texkey, Extension);
                    }
                }

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
                    nodeTexture.Text = texId + "." + textureExtension[texId];
                    nodeTexture.Responsibility = texContainer;
                    tpng.Nodes.Add(nodeTexture);
                }

                // GL das texturas
                modelGroup.AddTextureRef(textureDic);

                pack.Close();
            }
            catch (Exception)
            {

            }

        }
    }
}
