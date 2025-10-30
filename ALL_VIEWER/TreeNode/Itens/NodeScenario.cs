using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace JADERLINK_MODEL_VIEWER.src.Nodes
{
    public class NodeScenario : NodeItem, NsMultiselectTreeView.IAltNode
    {
        public NodeScenario() : base() { }

        public string AltText { get { return Text; } }

        public Color AltForeColor { get { return Color.Black; } }
    }
}
