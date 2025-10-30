using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RE4_SMX_TOOL
{
    public class SMX
    {
        public byte UseSMXID; //uint8_t ModelNo; // Index
        public byte Mode; // uint8_t Id; // Type (enum MOVE_TYPE)
        public byte OpacityHierarchy; //uint8_t OtType; // Render Heirarchy (enum OT_TYPES)
        public byte FaceCulling; //uint8_t CullMode; (enum CULL_MODE)
        public uint LightSwitch; //uint32_t LitSelectMask;
        //uint32_t Flag; (enum SMX_FLAGS)
        public byte AlphaHierarchy;
        public byte UnknownX09;
        public byte UnknownX0A;
        public byte UnknownX0B;
        //---------------------
        public byte[] ColorRGB; // 3 bytes //GXColor MaterialColor; (struct GXColor) no alpha
        public byte ColorAlpha; // (enum BLENDING_TYPES)

        /* "union" fields here */

        public uint UnknownU84; //GXColor SpecularColor; (struct GXColor + enum BLENDING_TYPES)
        public float TextureMovement_X; //TexU; (float value)
        public float TextureMovement_Y; //TexV; (float value)

        //----------
        //mode 0x00
        public uint UnknownU10;
        public uint UnknownU14;
        public uint UnknownU18;
        public uint UnknownU1C;
        public uint UnknownU20;
        public uint UnknownU24;
        public uint UnknownU28;
        public uint UnknownU2C;
        public uint UnknownU30;
        public uint UnknownU34;
        public uint UnknownU38;
        public uint UnknownU3C;
        public uint UnknownU40;
        public uint UnknownU44;
        public uint UnknownU48;
        public uint UnknownU4C;
        public uint UnknownU50;
        public uint UnknownU54;
        public uint UnknownU58;
        public uint UnknownU5C;
        public uint UnknownU60;
        public uint UnknownU64;
        public uint UnknownU68;
        public uint UnknownU6C;
        public uint UnknownU70;
        public uint UnknownU74;
        public uint UnknownU78;
        public uint UnknownU7C;
        public uint UnknownU80;

        //----------
        //mode 0x01

        public float RotationSpeed_X; //m_tagVec Rot; (x) float
        public float RotationSpeed_Y; //m_tagVec Rot; (y) float
        public float RotationSpeed_Z; //m_tagVec Rot; (z) float
        public float RotationSpeed_W; //m_tagVec Rot; (w) float
        public uint Unknown_GTU; //uint8_t m_Flag; (unknown type, can be 0 or 1)
        public uint Unknown_GTV; //nada, o mesmo que UnknownU20

        //----------
        //mode 0x02

        public float Swing0; //m_StartZ
        public float Swing1; //m_RangeZ
        public float Swing2; //m_SpeedZ
        public float Swing3; //m_Time
        public float Swing4; //m_StartX
        public float Swing5; //m_RangeX
        public float Swing6; //m_SpeedX
        public float Swing7; //m_StartY
        public float Swing8; //m_RangeY
        public float Swing9; //m_SpeedY
        public float SwingA; //m_InitAngX
        public float SwingB; //m_InitAngY
        public float SwingC; //m_InitAngZ

    }
}
