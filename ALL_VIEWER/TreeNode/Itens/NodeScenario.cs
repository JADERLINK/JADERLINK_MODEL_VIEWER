using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace JADERLINK_MODEL_VIEWER.src.Nodes
{
    public class NodeScenario : NodeItem
    {
        public NodeScenario() : base() { }
        public NodeScenario(string text) : base(text) { }
        public NodeScenario(string text, TreeNode[] children) : base(text, children) { }

    }
}
