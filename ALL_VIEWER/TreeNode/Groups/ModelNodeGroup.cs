using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace JADERLINK_MODEL_VIEWER.src.Nodes
{
    public class ModelNodeGroup : TreeNodeGroup, NsMultiselectTreeView.IAltNode
    {
        public ModelNodeGroup(string text) : base(text) { }

        public override GroupType GetGroup()
        {
            return GroupType.Model;
        }

        public string AltText { get { return Text; } }

        public Color AltForeColor { get { return ForeColor; } }
    }
}
