using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace JADERLINK_MODEL_VIEWER.src.Nodes
{
    public class ScenarioNodeGroup : TreeNodeGroup, NsMultiselectTreeView.IAltNode
    {
        public ScenarioNodeGroup(string text) : base(text) { }

        public override GroupType GetGroup()
        {
            return GroupType.Scenario;
        }

        public string AltText { get { return Text; } }

        public Color AltForeColor { get { return ForeColor; } }
    }
}
