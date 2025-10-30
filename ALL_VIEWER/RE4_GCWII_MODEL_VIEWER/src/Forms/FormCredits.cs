using System;
using System.Windows.Forms;

namespace JADERLINK_MODEL_VIEWER.src.Forms
{
    public partial class FormCredits : Form
    {
        public FormCredits()
        {
            InitializeComponent();
        }

        private void FormCredits_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Close();
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void linkLabelProjectGitHub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MultiPlatformOS.OpenLink.To("https://github.com/JADERLINK/JADERLINK_MODEL_VIEWER");
        }

        private void linkLabelJaderLinkBlog_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MultiPlatformOS.OpenLink.To("https://jaderlink.blogspot.com/");
        }

        private void linkLabelJaderLinkGitHub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MultiPlatformOS.OpenLink.To("https://github.com/JADERLINK");
        }

        private void linkLabelSiteOpenTK_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MultiPlatformOS.OpenLink.To("https://opentk.net/");
        }

        private void linkLabelNugetOpenTK_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MultiPlatformOS.OpenLink.To("https://www.nuget.org/packages/OpenTK/");
        }

        private void linkLabelNugetGLControl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MultiPlatformOS.OpenLink.To("https://www.nuget.org/packages/OpenTK.GLControl/");
        }

        private void linkLabelLicenseOpenTK_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MultiPlatformOS.OpenLink.To("https://github.com/opentk/opentk/blob/master/LICENSE.md");
        }

        private void linkLabelLicenseCodeProject_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MultiPlatformOS.OpenLink.To("https://www.codeproject.com/info/cpol10.aspx");
        }

        private void linkLabelMultiselectTreeView_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MultiPlatformOS.OpenLink.To("https://www.codeproject.com/Articles/20581/Multiselect-Treeview-Implementation");
        }

        private void linkLabelYoutubeJaderLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MultiPlatformOS.OpenLink.To("https://www.youtube.com/@JADERLINK");
        }

        private void linkLabelSMXTOOL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MultiPlatformOS.OpenLink.To("https://github.com/JADERLINK/RE4-SMX-TOOL");
        }

        private void linkLabelSCENARIOTOOL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MultiPlatformOS.OpenLink.To("https://github.com/JADERLINK/RE4-SCENARIO-SMD-TOOLS");
        }

        private void linkLabelBINTOOL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MultiPlatformOS.OpenLink.To("https://github.com/JADERLINK/RE4-GCWII-BIN-TOOL");
        }

        private void linkLabelDonate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MultiPlatformOS.OpenLink.To("https://jaderlink.github.io/Donate/");
        }
    }
}
