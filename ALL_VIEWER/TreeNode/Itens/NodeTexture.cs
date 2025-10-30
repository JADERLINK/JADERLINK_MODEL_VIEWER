using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace JADERLINK_MODEL_VIEWER.src.Nodes
{
    public class NodeTexture : NodeItem, NsMultiselectTreeView.IAltNode
    {
        public NodeTexture() : base() { }

        public string AltText { get { return Text; } }

        public Color AltForeColor { get { return Color.Black; } }
    }
}
