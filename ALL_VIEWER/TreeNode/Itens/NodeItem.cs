using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using ViewerBase;

namespace JADERLINK_MODEL_VIEWER.src.Nodes
{
    public abstract class NodeItem : TreeNode
    {
        public NodeItem() : base() { }
        public NodeItem(string text) : base(text) { }
        public NodeItem(string text, TreeNode[] children) : base(text, children) { }
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
    }
}
