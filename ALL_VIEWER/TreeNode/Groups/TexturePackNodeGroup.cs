using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace JADERLINK_MODEL_VIEWER.src.Nodes
{
    public class TexturePackNodeGroup : TreeNodeGroup, NsMultiselectTreeView.IAltNode
    {
        public TexturePackNodeGroup(string text) : base(text) { }

        public override GroupType GetGroup()
        {
            return GroupType.TexturePack;
        }

        public string AltText { get { return Text; } }

        public Color AltForeColor { get { return ForeColor; } }
    }
}
