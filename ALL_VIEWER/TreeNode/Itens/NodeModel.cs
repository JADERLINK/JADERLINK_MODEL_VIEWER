﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JADERLINK_MODEL_VIEWER.src.Nodes
{
    public class NodeModel : NodeItem, NsMultiselectTreeView.IAltNode    {
        public NodeModel() : base() { }
        public NodeModel(string text) : base(text) { }
        public NodeModel(string text, TreeNode[] children) : base(text, children) { }

        public string FileID { get; private set; } = null;
        public bool ModelIsEnable { get; private set; } = true;
        public bool BlockModelHiding { get; private set; } = false;

        public void SetFileID(string FileID) 
        {
            this.FileID = FileID;
        }

        public void SetBlockModelHiding(bool BlockModelHiding)
        {
            this.BlockModelHiding = BlockModelHiding;
        }

        public void SetModelIsEnable(bool ModelIsEnable) 
        {
            if (!BlockModelHiding && !ModelIsEnable)
            {
                this.ModelIsEnable = false;
            }
            else
            {
                this.ModelIsEnable = true;
            }
        }

        public string AltText { get { return Text + (ModelIsEnable ? "" : " | Hided"); } }

        public Color AltForeColor { get { return (ModelIsEnable ? Color.Black : Color.SlateGray); } }

    }
}
