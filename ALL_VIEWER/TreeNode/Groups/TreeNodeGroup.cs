using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JADERLINK_MODEL_VIEWER.src.Nodes
{
    public abstract class TreeNodeGroup : TreeNode
    {
        public TreeNodeGroup() : base() { }
        public TreeNodeGroup(string text) : base(text) { }
        public TreeNodeGroup(string text, TreeNode[] children) : base(text, children) { }
        public abstract GroupType GetGroup();
    }
}
