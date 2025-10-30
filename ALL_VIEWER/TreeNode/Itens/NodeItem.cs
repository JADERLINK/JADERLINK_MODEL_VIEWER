using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using ViewerBase;

namespace JADERLINK_MODEL_VIEWER.src.Nodes
{
    public abstract class NodeItem : TreeNode
    {
        public NodeItem() : base() {}

        public GroupType GetParentGroup() 
        {
            if (Parent != null
                && Parent is TreeNodeGroup g)
            {
                return g.GetGroup();
            }
            return GroupType.Null;
        }

        public ResponsibilityContainer Responsibility;

        private string internalText = "";

        // a intenção aqui é ocultar a variavel original
        public string Text { 
            get { 
                return internalText;
            }
            set { 
                base.Text = "";
                base.ToolTipText = value;
                internalText = value;
            } 
        }

    }
}
