using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JADERLINK_MODEL_VIEWER.src.Nodes
{
    public abstract class TreeNodeGroup : TreeNode
    {
        public TreeNodeGroup(string text) : base() { Text = text; ToolTipText = ""; }
        public abstract GroupType GetGroup();

        private string internalText = "";

        // a intenção aqui é ocultar a variavel original
        public string Text
        {
            get
            {
                return internalText;
            }
            set
            {
                base.Text = "";
                base.ToolTipText = "";
                internalText = value;
            }
        }
    }
}
