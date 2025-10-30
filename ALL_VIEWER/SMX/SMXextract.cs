using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SimpleEndianBinaryIO;

namespace RE4_SMX_TOOL
{
    public static class SMXextract
    {
        public static List<byte[]> Extract(Stream file)
        {
            List<byte[]> res = new List<byte[]>();

            BinaryReader br = new BinaryReader(file);

            byte magic = br.ReadByte();

            if (magic != 0x10)
            {
                throw new InvalidDataException("Incorrect file the magic must be 0x10;");
            }

            byte amount = br.ReadByte();

            int allLength = (amount * 144) + 16;
            if (file.Length < allLength)
            {
                throw new InvalidDataException("The file size is smaller than the amount of SMXentry reported;");
            }

            br.BaseStream.Position = 0x10;

            for (int i = 0; i < amount; i++)
            {
                byte[] cont = br.ReadBytes(144);
                res.Add(cont);
            }

            return res;
        }

        public static List<SMX> ToSmx(List<byte[]> lines, Endianness endianness, bool isPs2) 
        {
            List <SMX> res = new List<SMX>();
            for (int i = 0; i < lines.Count; i++)
            {
                SMX smx = new SMX();
                smx.UseSMXID = lines[i][0x00]; //uint8_t ModelNo; // Index
                smx.Mode = lines[i][0x01]; // uint8_t Id; // Type (enum MOVE_TYPE)
                smx.OpacityHierarchy = lines[i][0x02]; //uint8_t OtType; // Render Heirarchy (enum OT_TYPES)
                smx.FaceCulling = lines[i][0x03]; //uint8_t CullMode; (enum CULL_MODE)
                smx.LightSwitch = EndianBitConverter.ToUInt32(lines[i], 0x04, endianness); //uint32_t LitSelectMask;

                if (endianness == Endianness.LittleEndian) //uint32_t Flag; (enum SMX_FLAGS)
                {
                    smx.AlphaHierarchy = lines[i][0x08];
                    smx.UnknownX09 = lines[i][0x09];
                    smx.UnknownX0A = lines[i][0x0A];
                    smx.UnknownX0B = lines[i][0x0B];
                }
                else 
                {
                    smx.AlphaHierarchy = lines[i][0x0B];
                    smx.UnknownX09 = lines[i][0x0A];
                    smx.UnknownX0A = lines[i][0x09];
                    smx.UnknownX0B = lines[i][0x08];
                }

                smx.ColorRGB = new byte[3] { lines[i][0x0C], lines[i][0x0D], lines[i][0x0E] }; // 3 bytes //GXColor MaterialColor; (struct GXColor) no alpha
                smx.ColorAlpha = lines[i][0x0F]; // (enum BLENDING_TYPES)

                /* "union" fields here */

                //é sempre lido como little endian para compatibilidade;
                smx.UnknownU84 = BitConverter.ToUInt32(lines[i], 0x84); //GXColor SpecularColor; (struct GXColor + enum BLENDING_TYPES)
                
                //TextureMovement
                smx.TextureMovement_X = EndianBitConverter.ToSingle(lines[i], 0x88, endianness); //TexU; (float value)
                smx.TextureMovement_Y = EndianBitConverter.ToSingle(lines[i], 0x8C, endianness); //TexV; (float value)

                //----------
                //mode 0x00
                smx.UnknownU10 = EndianBitConverter.ToUInt32(lines[i], 0x10, endianness);
                smx.UnknownU14 = EndianBitConverter.ToUInt32(lines[i], 0x14, endianness);
                smx.UnknownU18 = EndianBitConverter.ToUInt32(lines[i], 0x18, endianness);
                smx.UnknownU1C = EndianBitConverter.ToUInt32(lines[i], 0x1C, endianness);
                smx.UnknownU20 = EndianBitConverter.ToUInt32(lines[i], 0x20, endianness);
                smx.UnknownU24 = EndianBitConverter.ToUInt32(lines[i], 0x24, endianness);
                smx.UnknownU28 = EndianBitConverter.ToUInt32(lines[i], 0x28, endianness);
                smx.UnknownU2C = EndianBitConverter.ToUInt32(lines[i], 0x2C, endianness);
                smx.UnknownU30 = EndianBitConverter.ToUInt32(lines[i], 0x30, endianness);
                smx.UnknownU34 = EndianBitConverter.ToUInt32(lines[i], 0x34, endianness);
                smx.UnknownU38 = EndianBitConverter.ToUInt32(lines[i], 0x38, endianness);
                smx.UnknownU3C = EndianBitConverter.ToUInt32(lines[i], 0x3C, endianness);
                smx.UnknownU40 = EndianBitConverter.ToUInt32(lines[i], 0x40, endianness);
                smx.UnknownU44 = EndianBitConverter.ToUInt32(lines[i], 0x44, endianness);
                smx.UnknownU48 = EndianBitConverter.ToUInt32(lines[i], 0x48, endianness);
                smx.UnknownU4C = EndianBitConverter.ToUInt32(lines[i], 0x4C, endianness);
                smx.UnknownU50 = EndianBitConverter.ToUInt32(lines[i], 0x50, endianness);
                smx.UnknownU54 = EndianBitConverter.ToUInt32(lines[i], 0x54, endianness);
                smx.UnknownU58 = EndianBitConverter.ToUInt32(lines[i], 0x58, endianness);
                smx.UnknownU5C = EndianBitConverter.ToUInt32(lines[i], 0x5C, endianness);
                smx.UnknownU60 = EndianBitConverter.ToUInt32(lines[i], 0x60, endianness);
                smx.UnknownU64 = EndianBitConverter.ToUInt32(lines[i], 0x64, endianness);
                smx.UnknownU68 = EndianBitConverter.ToUInt32(lines[i], 0x68, endianness);
                smx.UnknownU6C = EndianBitConverter.ToUInt32(lines[i], 0x6C, endianness);
                smx.UnknownU70 = EndianBitConverter.ToUInt32(lines[i], 0x70, endianness);
                smx.UnknownU74 = EndianBitConverter.ToUInt32(lines[i], 0x74, endianness);
                smx.UnknownU78 = EndianBitConverter.ToUInt32(lines[i], 0x78, endianness);
                smx.UnknownU7C = EndianBitConverter.ToUInt32(lines[i], 0x7C, endianness);
                smx.UnknownU80 = EndianBitConverter.ToUInt32(lines[i], 0x80, endianness);

                //----------
                //mode 0x02
                smx.Swing0 = EndianBitConverter.ToSingle(lines[i], 0x10, endianness); //m_StartZ
                smx.Swing1 = EndianBitConverter.ToSingle(lines[i], 0x14, endianness); //m_RangeZ
                smx.Swing2 = EndianBitConverter.ToSingle(lines[i], 0x18, endianness); //m_SpeedZ
                smx.Swing3 = EndianBitConverter.ToSingle(lines[i], 0x1C, endianness); //m_Time
                smx.Swing4 = EndianBitConverter.ToSingle(lines[i], 0x20, endianness); //m_StartX
                smx.Swing5 = EndianBitConverter.ToSingle(lines[i], 0x24, endianness); //m_RangeX
                smx.Swing6 = EndianBitConverter.ToSingle(lines[i], 0x28, endianness); //m_SpeedX
                smx.Swing7 = EndianBitConverter.ToSingle(lines[i], 0x2C, endianness); //m_StartY
                smx.Swing8 = EndianBitConverter.ToSingle(lines[i], 0x30, endianness); //m_RangeY
                smx.Swing9 = EndianBitConverter.ToSingle(lines[i], 0x34, endianness); //m_SpeedY
                smx.SwingA = EndianBitConverter.ToSingle(lines[i], 0x38, endianness); //m_InitAngX
                smx.SwingB = EndianBitConverter.ToSingle(lines[i], 0x3C, endianness); //m_InitAngY
                smx.SwingC = EndianBitConverter.ToSingle(lines[i], 0x40, endianness); //m_InitAngZ

                //---------
                //mode 0x01
                smx.RotationSpeed_X = EndianBitConverter.ToSingle(lines[i], 0x10, endianness); //m_tagVec Rot; (x) float
                smx.RotationSpeed_Y = EndianBitConverter.ToSingle(lines[i], 0x14, endianness); //m_tagVec Rot; (y) float
                smx.RotationSpeed_Z = EndianBitConverter.ToSingle(lines[i], 0x18, endianness); //m_tagVec Rot; (z) float
                if (isPs2)
                {
                    smx.RotationSpeed_W = EndianBitConverter.ToSingle(lines[i], 0x1C, endianness); //m_tagVec Rot; (w) float
                    // é sempre lido como little endian para compatibilidade;
                    smx.Unknown_GTU = BitConverter.ToUInt32(lines[i], 0x20); //uint8_t m_Flag; (unknown type, can be 0 or 1)
                    smx.Unknown_GTV = 0;
                }
                else 
                {
                    smx.RotationSpeed_W = 1.0f; //m_tagVec Rot; (w) float
                    // é sempre lido como little endian para compatibilidade;
                    smx.Unknown_GTU = BitConverter.ToUInt32(lines[i], 0x1C); //uint8_t m_Flag; (unknown type, can be 0 or 1)
                    //nada, o mesmo que UnknownU20
                    smx.Unknown_GTV = EndianBitConverter.ToUInt32(lines[i], 0x20, endianness);
                }

                res.Add(smx);
            }

            return res;
        }

    }
}
