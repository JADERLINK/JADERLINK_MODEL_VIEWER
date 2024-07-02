using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//https://stackoverflow.com/questions/4580263/how-to-open-in-default-browser-in-c-sharp

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

        private void To(string url)
        {
            try { System.Diagnostics.Process.Start("explorer.exe", url); } catch (Exception) { }
        }

        private void linkLabelProjectGitHub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            To("https://github.com/JADERLINK/JADERLINK_MODEL_VIEWER");
        }

        private void linkLabelJaderLinkBlog_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            To("https://jaderlink.blogspot.com/");
        }

        private void linkLabelJaderLinkGitHub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            To("https://github.com/JADERLINK");
        }

        private void linkLabelTgaGitHub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            To("https://github.com/ALEXGREENALEX/TGASharpLib");
        }

        private void linkLabelTgaGitLab_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            To("https://gitlab.com/Alex_Green/TGASharpLib");
        }

        private void linkLabelLicenseTGA_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            To("https://github.com/ALEXGREENALEX/TGASharpLib/blob/master/LICENSE");
        }

        private void linkLabelSiteOpenTK_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            To("https://opentk.net/");
        }

        private void linkLabelNugetOpenTK_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            To("https://www.nuget.org/packages/OpenTK/");
        }

        private void linkLabelNugetGLControl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            To("https://www.nuget.org/packages/OpenTK.GLControl/");
        }

        private void linkLabelLicenseOpenTK_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            To("https://github.com/opentk/opentk/blob/master/LICENSE.md");
        }

        private void linkLabelLicenseCodeProject_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            To("https://www.codeproject.com/info/cpol10.aspx");
        }

        private void linkLabelMultiselectTreeView_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            To("https://www.codeproject.com/Articles/20581/Multiselect-Treeview-Implementation");
        }

 
        private void linkLabelYoutubeJaderLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            To("https://www.youtube.com/@JADERLINK");
        }

        private void linkLabelSMXTOOL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            To("https://github.com/JADERLINK/RE4-SMX-TOOL");
        }

        private void linkLabelSCENARIOTOOL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            To("https://github.com/JADERLINK/RE4-UHD-SCENARIO-SMD-TOOL");
        }

        private void linkLabelBINTOOL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            To("https://github.com/JADERLINK/RE4-UHD-BIN-TOOL");
        }

        private void linkLabelDdsGitHub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            To("https://github.com/ALEXGREENALEX/DDSReaderSharp");
        }

        private void linkLabelDdsGitLab_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            To("https://gitlab.com/Alex_Green/DDSReaderSharp");
        }

        private void linkLabelLicenseDDS_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            To("https://github.com/ALEXGREENALEX/DDSReaderSharp/blob/master/LICENSE");
        }

        private void linkLabelDonate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            To("https://jaderlink.github.io/Donate/");
        }
    }
}
