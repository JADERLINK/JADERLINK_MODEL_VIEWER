using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;


namespace JADERLINK_MODEL_VIEWER.src.Nodes
{

    public class NodeMatRef : NodeItem, NsMultiselectTreeView.IAltNode
    {
        public NodeMatRef() : base() { }

        public string FileID { get; private set; } = null;

        public void SetFileID(string FileID)
        {
            this.FileID = FileID;
        }

        public string AltText { get { return Text; } }

        public Color AltForeColor { get { return Color.Black; } }
    }
}
