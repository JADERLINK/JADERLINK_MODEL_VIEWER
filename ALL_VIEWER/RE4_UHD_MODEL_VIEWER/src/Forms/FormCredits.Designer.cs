
namespace JADERLINK_MODEL_VIEWER.src.Forms
{
    partial class FormCredits
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCredits));
            this.buttonClose = new System.Windows.Forms.Button();
            this.groupBoxCodeproject = new System.Windows.Forms.GroupBox();
            this.linkLabelMultiselectTreeView = new System.Windows.Forms.LinkLabel();
            this.linkLabelLicenseCodeProject = new System.Windows.Forms.LinkLabel();
            this.groupBoxAPIs = new System.Windows.Forms.GroupBox();
            this.linkLabelLicenseDDS = new System.Windows.Forms.LinkLabel();
            this.linkLabelDdsGitLab = new System.Windows.Forms.LinkLabel();
            this.linkLabelDdsGitHub = new System.Windows.Forms.LinkLabel();
            this.labelZelenskyi2 = new System.Windows.Forms.Label();
            this.labelDDSReaderSharp = new System.Windows.Forms.Label();
            this.linkLabelLicenseOpenTK = new System.Windows.Forms.LinkLabel();
            this.linkLabelNugetGLControl = new System.Windows.Forms.LinkLabel();
            this.linkLabelNugetOpenTK = new System.Windows.Forms.LinkLabel();
            this.linkLabelSiteOpenTK = new System.Windows.Forms.LinkLabel();
            this.labelOpenTK = new System.Windows.Forms.Label();
            this.linkLabelLicenseTGA = new System.Windows.Forms.LinkLabel();
            this.linkLabelTgaGitLab = new System.Windows.Forms.LinkLabel();
            this.linkLabelTgaGitHub = new System.Windows.Forms.LinkLabel();
            this.labelZelenskyi = new System.Windows.Forms.Label();
            this.labelTGASharpLib = new System.Windows.Forms.Label();
            this.groupBoxAuthors = new System.Windows.Forms.GroupBox();
            this.textBoxJaderLinkEmail = new System.Windows.Forms.TextBox();
            this.linkLabelYoutubeJaderLink = new System.Windows.Forms.LinkLabel();
            this.linkLabelJaderLinkGitHub = new System.Windows.Forms.LinkLabel();
            this.labelMainAuthor = new System.Windows.Forms.Label();
            this.linkLabelJaderLinkBlog = new System.Windows.Forms.LinkLabel();
            this.groupBoxProjectLinks = new System.Windows.Forms.GroupBox();
            this.linkLabelProjectGitHub = new System.Windows.Forms.LinkLabel();
            this.groupBoxTools = new System.Windows.Forms.GroupBox();
            this.linkLabelBINTOOL = new System.Windows.Forms.LinkLabel();
            this.linkLabelSCENARIOTOOL = new System.Windows.Forms.LinkLabel();
            this.linkLabelSMXTOOL = new System.Windows.Forms.LinkLabel();
            this.linkLabelDonate = new System.Windows.Forms.LinkLabel();
            this.groupBoxCodeproject.SuspendLayout();
            this.groupBoxAPIs.SuspendLayout();
            this.groupBoxAuthors.SuspendLayout();
            this.groupBoxProjectLinks.SuspendLayout();
            this.groupBoxTools.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonClose
            // 
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.Location = new System.Drawing.Point(648, 355);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 0;
            this.buttonClose.Text = "CLOSE";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // groupBoxCodeproject
            // 
            this.groupBoxCodeproject.Controls.Add(this.linkLabelMultiselectTreeView);
            this.groupBoxCodeproject.Controls.Add(this.linkLabelLicenseCodeProject);
            this.groupBoxCodeproject.Location = new System.Drawing.Point(6, 190);
            this.groupBoxCodeproject.Name = "groupBoxCodeproject";
            this.groupBoxCodeproject.Size = new System.Drawing.Size(304, 75);
            this.groupBoxCodeproject.TabIndex = 3;
            this.groupBoxCodeproject.TabStop = false;
            this.groupBoxCodeproject.Text = "Used codes of www.codeproject.com";
            // 
            // linkLabelMultiselectTreeView
            // 
            this.linkLabelMultiselectTreeView.ActiveLinkColor = System.Drawing.Color.Black;
            this.linkLabelMultiselectTreeView.AutoSize = true;
            this.linkLabelMultiselectTreeView.LinkColor = System.Drawing.Color.Navy;
            this.linkLabelMultiselectTreeView.Location = new System.Drawing.Point(8, 52);
            this.linkLabelMultiselectTreeView.Name = "linkLabelMultiselectTreeView";
            this.linkLabelMultiselectTreeView.Size = new System.Drawing.Size(136, 15);
            this.linkLabelMultiselectTreeView.TabIndex = 1;
            this.linkLabelMultiselectTreeView.TabStop = true;
            this.linkLabelMultiselectTreeView.Text = "MultiselectTreeView";
            this.linkLabelMultiselectTreeView.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelMultiselectTreeView_LinkClicked);
            // 
            // linkLabelLicenseCodeProject
            // 
            this.linkLabelLicenseCodeProject.ActiveLinkColor = System.Drawing.Color.Black;
            this.linkLabelLicenseCodeProject.AutoSize = true;
            this.linkLabelLicenseCodeProject.LinkColor = System.Drawing.Color.Navy;
            this.linkLabelLicenseCodeProject.Location = new System.Drawing.Point(6, 17);
            this.linkLabelLicenseCodeProject.Name = "linkLabelLicenseCodeProject";
            this.linkLabelLicenseCodeProject.Size = new System.Drawing.Size(291, 30);
            this.linkLabelLicenseCodeProject.TabIndex = 0;
            this.linkLabelLicenseCodeProject.TabStop = true;
            this.linkLabelLicenseCodeProject.Text = "License: \r\nThe Code Project Open License (CPOL) 1.02";
            this.linkLabelLicenseCodeProject.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelLicenseCodeProject_LinkClicked);
            // 
            // groupBoxAPIs
            // 
            this.groupBoxAPIs.Controls.Add(this.linkLabelLicenseDDS);
            this.groupBoxAPIs.Controls.Add(this.linkLabelDdsGitLab);
            this.groupBoxAPIs.Controls.Add(this.linkLabelDdsGitHub);
            this.groupBoxAPIs.Controls.Add(this.labelZelenskyi2);
            this.groupBoxAPIs.Controls.Add(this.labelDDSReaderSharp);
            this.groupBoxAPIs.Controls.Add(this.linkLabelLicenseOpenTK);
            this.groupBoxAPIs.Controls.Add(this.linkLabelNugetGLControl);
            this.groupBoxAPIs.Controls.Add(this.linkLabelNugetOpenTK);
            this.groupBoxAPIs.Controls.Add(this.linkLabelSiteOpenTK);
            this.groupBoxAPIs.Controls.Add(this.labelOpenTK);
            this.groupBoxAPIs.Controls.Add(this.linkLabelLicenseTGA);
            this.groupBoxAPIs.Controls.Add(this.linkLabelTgaGitLab);
            this.groupBoxAPIs.Controls.Add(this.linkLabelTgaGitHub);
            this.groupBoxAPIs.Controls.Add(this.labelZelenskyi);
            this.groupBoxAPIs.Controls.Add(this.labelTGASharpLib);
            this.groupBoxAPIs.Location = new System.Drawing.Point(316, 54);
            this.groupBoxAPIs.Name = "groupBoxAPIs";
            this.groupBoxAPIs.Size = new System.Drawing.Size(407, 295);
            this.groupBoxAPIs.TabIndex = 5;
            this.groupBoxAPIs.TabStop = false;
            this.groupBoxAPIs.Text = "API\'s";
            // 
            // linkLabelLicenseDDS
            // 
            this.linkLabelLicenseDDS.ActiveLinkColor = System.Drawing.Color.Black;
            this.linkLabelLicenseDDS.AutoSize = true;
            this.linkLabelLicenseDDS.LinkColor = System.Drawing.Color.Navy;
            this.linkLabelLicenseDDS.Location = new System.Drawing.Point(8, 76);
            this.linkLabelLicenseDDS.Name = "linkLabelLicenseDDS";
            this.linkLabelLicenseDDS.Size = new System.Drawing.Size(395, 15);
            this.linkLabelLicenseDDS.TabIndex = 17;
            this.linkLabelLicenseDDS.TabStop = true;
            this.linkLabelLicenseDDS.Text = "License:  MIT License - Copyright (c) 2017 DDSReaderSharp";
            this.linkLabelLicenseDDS.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelLicenseDDS_LinkClicked);
            // 
            // linkLabelDdsGitLab
            // 
            this.linkLabelDdsGitLab.ActiveLinkColor = System.Drawing.Color.Black;
            this.linkLabelDdsGitLab.AutoSize = true;
            this.linkLabelDdsGitLab.LinkColor = System.Drawing.Color.Navy;
            this.linkLabelDdsGitLab.Location = new System.Drawing.Point(116, 56);
            this.linkLabelDdsGitLab.Name = "linkLabelDdsGitLab";
            this.linkLabelDdsGitLab.Size = new System.Drawing.Size(94, 15);
            this.linkLabelDdsGitLab.TabIndex = 16;
            this.linkLabelDdsGitLab.TabStop = true;
            this.linkLabelDdsGitLab.Text = "Gitlab Project";
            this.linkLabelDdsGitLab.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelDdsGitLab_LinkClicked);
            // 
            // linkLabelDdsGitHub
            // 
            this.linkLabelDdsGitHub.ActiveLinkColor = System.Drawing.Color.Black;
            this.linkLabelDdsGitHub.AutoSize = true;
            this.linkLabelDdsGitHub.LinkColor = System.Drawing.Color.Navy;
            this.linkLabelDdsGitHub.Location = new System.Drawing.Point(7, 56);
            this.linkLabelDdsGitHub.Name = "linkLabelDdsGitHub";
            this.linkLabelDdsGitHub.Size = new System.Drawing.Size(98, 15);
            this.linkLabelDdsGitHub.TabIndex = 15;
            this.linkLabelDdsGitHub.TabStop = true;
            this.linkLabelDdsGitHub.Text = "Github Project";
            this.linkLabelDdsGitHub.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelDdsGitHub_LinkClicked);
            // 
            // labelZelenskyi2
            // 
            this.labelZelenskyi2.AutoSize = true;
            this.labelZelenskyi2.Location = new System.Drawing.Point(7, 37);
            this.labelZelenskyi2.Name = "labelZelenskyi2";
            this.labelZelenskyi2.Size = new System.Drawing.Size(319, 15);
            this.labelZelenskyi2.TabIndex = 14;
            this.labelZelenskyi2.Text = "By: Zelenskyi Alexandr (Зеленський Олександр)";
            // 
            // labelDDSReaderSharp
            // 
            this.labelDDSReaderSharp.AutoSize = true;
            this.labelDDSReaderSharp.ForeColor = System.Drawing.Color.Teal;
            this.labelDDSReaderSharp.Location = new System.Drawing.Point(7, 18);
            this.labelDDSReaderSharp.Name = "labelDDSReaderSharp";
            this.labelDDSReaderSharp.Size = new System.Drawing.Size(186, 15);
            this.labelDDSReaderSharp.TabIndex = 13;
            this.labelDDSReaderSharp.Text = "DDSReaderSharp (In code):";
            // 
            // linkLabelLicenseOpenTK
            // 
            this.linkLabelLicenseOpenTK.ActiveLinkColor = System.Drawing.Color.Black;
            this.linkLabelLicenseOpenTK.AutoSize = true;
            this.linkLabelLicenseOpenTK.LinkColor = System.Drawing.Color.Navy;
            this.linkLabelLicenseOpenTK.Location = new System.Drawing.Point(9, 238);
            this.linkLabelLicenseOpenTK.Name = "linkLabelLicenseOpenTK";
            this.linkLabelLicenseOpenTK.Size = new System.Drawing.Size(347, 30);
            this.linkLabelLicenseOpenTK.TabIndex = 12;
            this.linkLabelLicenseOpenTK.TabStop = true;
            this.linkLabelLicenseOpenTK.Text = "License:  MIT License Copyright (c) 2006-2020 \r\nStefanos Apostolopoulos for the O" +
    "pen Toolkit project.";
            this.linkLabelLicenseOpenTK.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelLicenseOpenTK_LinkClicked);
            // 
            // linkLabelNugetGLControl
            // 
            this.linkLabelNugetGLControl.ActiveLinkColor = System.Drawing.Color.Black;
            this.linkLabelNugetGLControl.AutoSize = true;
            this.linkLabelNugetGLControl.LinkColor = System.Drawing.Color.Navy;
            this.linkLabelNugetGLControl.Location = new System.Drawing.Point(123, 215);
            this.linkLabelNugetGLControl.Name = "linkLabelNugetGLControl";
            this.linkLabelNugetGLControl.Size = new System.Drawing.Size(168, 15);
            this.linkLabelNugetGLControl.TabIndex = 11;
            this.linkLabelNugetGLControl.TabStop = true;
            this.linkLabelNugetGLControl.Text = "Nuget OpenTK.GLControl";
            this.linkLabelNugetGLControl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelNugetGLControl_LinkClicked);
            // 
            // linkLabelNugetOpenTK
            // 
            this.linkLabelNugetOpenTK.ActiveLinkColor = System.Drawing.Color.Black;
            this.linkLabelNugetOpenTK.AutoSize = true;
            this.linkLabelNugetOpenTK.LinkColor = System.Drawing.Color.Navy;
            this.linkLabelNugetOpenTK.Location = new System.Drawing.Point(9, 215);
            this.linkLabelNugetOpenTK.Name = "linkLabelNugetOpenTK";
            this.linkLabelNugetOpenTK.Size = new System.Drawing.Size(104, 15);
            this.linkLabelNugetOpenTK.TabIndex = 10;
            this.linkLabelNugetOpenTK.TabStop = true;
            this.linkLabelNugetOpenTK.Text = "Nuget. OpenTK";
            this.linkLabelNugetOpenTK.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelNugetOpenTK_LinkClicked);
            // 
            // linkLabelSiteOpenTK
            // 
            this.linkLabelSiteOpenTK.ActiveLinkColor = System.Drawing.Color.Black;
            this.linkLabelSiteOpenTK.AutoSize = true;
            this.linkLabelSiteOpenTK.LinkColor = System.Drawing.Color.Navy;
            this.linkLabelSiteOpenTK.Location = new System.Drawing.Point(9, 198);
            this.linkLabelSiteOpenTK.Name = "linkLabelSiteOpenTK";
            this.linkLabelSiteOpenTK.Size = new System.Drawing.Size(107, 15);
            this.linkLabelSiteOpenTK.TabIndex = 9;
            this.linkLabelSiteOpenTK.TabStop = true;
            this.linkLabelSiteOpenTK.Text = "Site: opentk.net";
            this.linkLabelSiteOpenTK.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelSiteOpenTK_LinkClicked);
            // 
            // labelOpenTK
            // 
            this.labelOpenTK.AutoSize = true;
            this.labelOpenTK.ForeColor = System.Drawing.Color.Teal;
            this.labelOpenTK.Location = new System.Drawing.Point(9, 181);
            this.labelOpenTK.Name = "labelOpenTK";
            this.labelOpenTK.Size = new System.Drawing.Size(134, 15);
            this.labelOpenTK.TabIndex = 8;
            this.labelOpenTK.Text = "OpenTK  (.DLL file):";
            // 
            // linkLabelLicenseTGA
            // 
            this.linkLabelLicenseTGA.ActiveLinkColor = System.Drawing.Color.Black;
            this.linkLabelLicenseTGA.AutoSize = true;
            this.linkLabelLicenseTGA.LinkColor = System.Drawing.Color.Navy;
            this.linkLabelLicenseTGA.Location = new System.Drawing.Point(6, 156);
            this.linkLabelLicenseTGA.Name = "linkLabelLicenseTGA";
            this.linkLabelLicenseTGA.Size = new System.Drawing.Size(365, 15);
            this.linkLabelLicenseTGA.TabIndex = 7;
            this.linkLabelLicenseTGA.TabStop = true;
            this.linkLabelLicenseTGA.Text = "License:  MIT License - Copyright (c) 2017 TGASharpLib";
            this.linkLabelLicenseTGA.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelLicenseTGA_LinkClicked);
            // 
            // linkLabelTgaGitLab
            // 
            this.linkLabelTgaGitLab.ActiveLinkColor = System.Drawing.Color.Black;
            this.linkLabelTgaGitLab.AutoSize = true;
            this.linkLabelTgaGitLab.LinkColor = System.Drawing.Color.Navy;
            this.linkLabelTgaGitLab.Location = new System.Drawing.Point(114, 136);
            this.linkLabelTgaGitLab.Name = "linkLabelTgaGitLab";
            this.linkLabelTgaGitLab.Size = new System.Drawing.Size(94, 15);
            this.linkLabelTgaGitLab.TabIndex = 6;
            this.linkLabelTgaGitLab.TabStop = true;
            this.linkLabelTgaGitLab.Text = "Gitlab Project";
            this.linkLabelTgaGitLab.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelTgaGitLab_LinkClicked);
            // 
            // linkLabelTgaGitHub
            // 
            this.linkLabelTgaGitHub.ActiveLinkColor = System.Drawing.Color.Black;
            this.linkLabelTgaGitHub.AutoSize = true;
            this.linkLabelTgaGitHub.LinkColor = System.Drawing.Color.Navy;
            this.linkLabelTgaGitHub.Location = new System.Drawing.Point(5, 136);
            this.linkLabelTgaGitHub.Name = "linkLabelTgaGitHub";
            this.linkLabelTgaGitHub.Size = new System.Drawing.Size(98, 15);
            this.linkLabelTgaGitHub.TabIndex = 5;
            this.linkLabelTgaGitHub.TabStop = true;
            this.linkLabelTgaGitHub.Text = "Github Project";
            this.linkLabelTgaGitHub.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelTgaGitHub_LinkClicked);
            // 
            // labelZelenskyi
            // 
            this.labelZelenskyi.AutoSize = true;
            this.labelZelenskyi.Location = new System.Drawing.Point(5, 117);
            this.labelZelenskyi.Name = "labelZelenskyi";
            this.labelZelenskyi.Size = new System.Drawing.Size(319, 15);
            this.labelZelenskyi.TabIndex = 4;
            this.labelZelenskyi.Text = "By: Zelenskyi Alexandr (Зеленський Олександр)";
            // 
            // labelTGASharpLib
            // 
            this.labelTGASharpLib.AutoSize = true;
            this.labelTGASharpLib.ForeColor = System.Drawing.Color.Teal;
            this.labelTGASharpLib.Location = new System.Drawing.Point(5, 98);
            this.labelTGASharpLib.Name = "labelTGASharpLib";
            this.labelTGASharpLib.Size = new System.Drawing.Size(156, 15);
            this.labelTGASharpLib.TabIndex = 3;
            this.labelTGASharpLib.Text = "TGASharpLib (In code):";
            // 
            // groupBoxAuthors
            // 
            this.groupBoxAuthors.Controls.Add(this.textBoxJaderLinkEmail);
            this.groupBoxAuthors.Controls.Add(this.linkLabelYoutubeJaderLink);
            this.groupBoxAuthors.Controls.Add(this.linkLabelJaderLinkGitHub);
            this.groupBoxAuthors.Controls.Add(this.labelMainAuthor);
            this.groupBoxAuthors.Controls.Add(this.linkLabelJaderLinkBlog);
            this.groupBoxAuthors.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxAuthors.Location = new System.Drawing.Point(8, 54);
            this.groupBoxAuthors.Name = "groupBoxAuthors";
            this.groupBoxAuthors.Size = new System.Drawing.Size(302, 132);
            this.groupBoxAuthors.TabIndex = 2;
            this.groupBoxAuthors.TabStop = false;
            this.groupBoxAuthors.Text = "Authors";
            // 
            // textBoxJaderLinkEmail
            // 
            this.textBoxJaderLinkEmail.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxJaderLinkEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxJaderLinkEmail.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBoxJaderLinkEmail.Location = new System.Drawing.Point(18, 61);
            this.textBoxJaderLinkEmail.Name = "textBoxJaderLinkEmail";
            this.textBoxJaderLinkEmail.ReadOnly = true;
            this.textBoxJaderLinkEmail.Size = new System.Drawing.Size(275, 14);
            this.textBoxJaderLinkEmail.TabIndex = 2;
            this.textBoxJaderLinkEmail.TabStop = false;
            this.textBoxJaderLinkEmail.Text = "Contact: jaderlinkproject@gmail.com";
            // 
            // linkLabelYoutubeJaderLink
            // 
            this.linkLabelYoutubeJaderLink.ActiveLinkColor = System.Drawing.Color.Black;
            this.linkLabelYoutubeJaderLink.AutoSize = true;
            this.linkLabelYoutubeJaderLink.LinkColor = System.Drawing.Color.Navy;
            this.linkLabelYoutubeJaderLink.Location = new System.Drawing.Point(15, 104);
            this.linkLabelYoutubeJaderLink.Name = "linkLabelYoutubeJaderLink";
            this.linkLabelYoutubeJaderLink.Size = new System.Drawing.Size(278, 15);
            this.linkLabelYoutubeJaderLink.TabIndex = 4;
            this.linkLabelYoutubeJaderLink.TabStop = true;
            this.linkLabelYoutubeJaderLink.Text = "YouTube: www.youtube.com/@JADERLINK";
            this.linkLabelYoutubeJaderLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelYoutubeJaderLink_LinkClicked);
            // 
            // linkLabelJaderLinkGitHub
            // 
            this.linkLabelJaderLinkGitHub.ActiveLinkColor = System.Drawing.Color.Black;
            this.linkLabelJaderLinkGitHub.AutoSize = true;
            this.linkLabelJaderLinkGitHub.LinkColor = System.Drawing.Color.Navy;
            this.linkLabelJaderLinkGitHub.Location = new System.Drawing.Point(15, 83);
            this.linkLabelJaderLinkGitHub.Name = "linkLabelJaderLinkGitHub";
            this.linkLabelJaderLinkGitHub.Size = new System.Drawing.Size(209, 15);
            this.linkLabelJaderLinkGitHub.TabIndex = 3;
            this.linkLabelJaderLinkGitHub.TabStop = true;
            this.linkLabelJaderLinkGitHub.Text = "GitHub: github.com/JADERLINK";
            this.linkLabelJaderLinkGitHub.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelJaderLinkGitHub_LinkClicked);
            // 
            // labelMainAuthor
            // 
            this.labelMainAuthor.AutoSize = true;
            this.labelMainAuthor.ForeColor = System.Drawing.Color.Teal;
            this.labelMainAuthor.Location = new System.Drawing.Point(15, 21);
            this.labelMainAuthor.Name = "labelMainAuthor";
            this.labelMainAuthor.Size = new System.Drawing.Size(167, 15);
            this.labelMainAuthor.TabIndex = 0;
            this.labelMainAuthor.Text = "Main Author: JADERLINK";
            // 
            // linkLabelJaderLinkBlog
            // 
            this.linkLabelJaderLinkBlog.ActiveLinkColor = System.Drawing.Color.Black;
            this.linkLabelJaderLinkBlog.AutoSize = true;
            this.linkLabelJaderLinkBlog.LinkColor = System.Drawing.Color.Navy;
            this.linkLabelJaderLinkBlog.Location = new System.Drawing.Point(15, 39);
            this.linkLabelJaderLinkBlog.Name = "linkLabelJaderLinkBlog";
            this.linkLabelJaderLinkBlog.Size = new System.Drawing.Size(221, 15);
            this.linkLabelJaderLinkBlog.TabIndex = 1;
            this.linkLabelJaderLinkBlog.TabStop = true;
            this.linkLabelJaderLinkBlog.Text = "Blog Link: jaderlink.blogspot.com";
            this.linkLabelJaderLinkBlog.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelJaderLinkBlog_LinkClicked);
            // 
            // groupBoxProjectLinks
            // 
            this.groupBoxProjectLinks.Controls.Add(this.linkLabelDonate);
            this.groupBoxProjectLinks.Controls.Add(this.linkLabelProjectGitHub);
            this.groupBoxProjectLinks.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxProjectLinks.Location = new System.Drawing.Point(8, 6);
            this.groupBoxProjectLinks.Name = "groupBoxProjectLinks";
            this.groupBoxProjectLinks.Size = new System.Drawing.Size(715, 45);
            this.groupBoxProjectLinks.TabIndex = 1;
            this.groupBoxProjectLinks.TabStop = false;
            this.groupBoxProjectLinks.Text = "Project Links";
            // 
            // linkLabelProjectGitHub
            // 
            this.linkLabelProjectGitHub.ActiveLinkColor = System.Drawing.Color.Black;
            this.linkLabelProjectGitHub.AutoSize = true;
            this.linkLabelProjectGitHub.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelProjectGitHub.LinkColor = System.Drawing.Color.Navy;
            this.linkLabelProjectGitHub.Location = new System.Drawing.Point(10, 19);
            this.linkLabelProjectGitHub.Name = "linkLabelProjectGitHub";
            this.linkLabelProjectGitHub.Size = new System.Drawing.Size(100, 15);
            this.linkLabelProjectGitHub.TabIndex = 0;
            this.linkLabelProjectGitHub.TabStop = true;
            this.linkLabelProjectGitHub.Text = "Project GitHub";
            this.linkLabelProjectGitHub.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelProjectGitHub_LinkClicked);
            // 
            // groupBoxTools
            // 
            this.groupBoxTools.Controls.Add(this.linkLabelBINTOOL);
            this.groupBoxTools.Controls.Add(this.linkLabelSCENARIOTOOL);
            this.groupBoxTools.Controls.Add(this.linkLabelSMXTOOL);
            this.groupBoxTools.Location = new System.Drawing.Point(6, 270);
            this.groupBoxTools.Name = "groupBoxTools";
            this.groupBoxTools.Size = new System.Drawing.Size(304, 79);
            this.groupBoxTools.TabIndex = 4;
            this.groupBoxTools.TabStop = false;
            this.groupBoxTools.Text = "JADERLINK TOOLS";
            // 
            // linkLabelBINTOOL
            // 
            this.linkLabelBINTOOL.ActiveLinkColor = System.Drawing.Color.Black;
            this.linkLabelBINTOOL.AutoSize = true;
            this.linkLabelBINTOOL.LinkColor = System.Drawing.Color.Navy;
            this.linkLabelBINTOOL.Location = new System.Drawing.Point(6, 55);
            this.linkLabelBINTOOL.Name = "linkLabelBINTOOL";
            this.linkLabelBINTOOL.Size = new System.Drawing.Size(138, 15);
            this.linkLabelBINTOOL.TabIndex = 2;
            this.linkLabelBINTOOL.TabStop = true;
            this.linkLabelBINTOOL.Text = "RE4-UHD-BIN-TOOL";
            this.linkLabelBINTOOL.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelBINTOOL_LinkClicked);
            // 
            // linkLabelSCENARIOTOOL
            // 
            this.linkLabelSCENARIOTOOL.ActiveLinkColor = System.Drawing.Color.Black;
            this.linkLabelSCENARIOTOOL.AutoSize = true;
            this.linkLabelSCENARIOTOOL.LinkColor = System.Drawing.Color.Navy;
            this.linkLabelSCENARIOTOOL.Location = new System.Drawing.Point(6, 37);
            this.linkLabelSCENARIOTOOL.Name = "linkLabelSCENARIOTOOL";
            this.linkLabelSCENARIOTOOL.Size = new System.Drawing.Size(220, 15);
            this.linkLabelSCENARIOTOOL.TabIndex = 1;
            this.linkLabelSCENARIOTOOL.TabStop = true;
            this.linkLabelSCENARIOTOOL.Text = "RE4-UHD-SCENARIO-SMD-TOOL";
            this.linkLabelSCENARIOTOOL.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelSCENARIOTOOL_LinkClicked);
            // 
            // linkLabelSMXTOOL
            // 
            this.linkLabelSMXTOOL.ActiveLinkColor = System.Drawing.Color.Black;
            this.linkLabelSMXTOOL.AutoSize = true;
            this.linkLabelSMXTOOL.LinkColor = System.Drawing.Color.Navy;
            this.linkLabelSMXTOOL.Location = new System.Drawing.Point(6, 18);
            this.linkLabelSMXTOOL.Name = "linkLabelSMXTOOL";
            this.linkLabelSMXTOOL.Size = new System.Drawing.Size(110, 15);
            this.linkLabelSMXTOOL.TabIndex = 0;
            this.linkLabelSMXTOOL.TabStop = true;
            this.linkLabelSMXTOOL.Text = "RE4-SMX-TOOL";
            this.linkLabelSMXTOOL.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelSMXTOOL_LinkClicked);
            // 
            // linkLabelDonate
            // 
            this.linkLabelDonate.ActiveLinkColor = System.Drawing.Color.Black;
            this.linkLabelDonate.AutoSize = true;
            this.linkLabelDonate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelDonate.LinkColor = System.Drawing.Color.Navy;
            this.linkLabelDonate.Location = new System.Drawing.Point(288, 19);
            this.linkLabelDonate.Name = "linkLabelDonate";
            this.linkLabelDonate.Size = new System.Drawing.Size(423, 15);
            this.linkLabelDonate.TabIndex = 1;
            this.linkLabelDonate.TabStop = true;
            this.linkLabelDonate.Text = "To donate to JADERLINK go to: https://jaderlink.github.io/Donate/";
            this.linkLabelDonate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelDonate_LinkClicked);
            // 
            // FormCredits
            // 
            this.AcceptButton = this.buttonClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonClose;
            this.ClientSize = new System.Drawing.Size(731, 388);
            this.Controls.Add(this.groupBoxTools);
            this.Controls.Add(this.groupBoxCodeproject);
            this.Controls.Add(this.groupBoxAPIs);
            this.Controls.Add(this.groupBoxAuthors);
            this.Controls.Add(this.groupBoxProjectLinks);
            this.Controls.Add(this.buttonClose);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FormCredits";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Credits";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormCredits_KeyDown);
            this.groupBoxCodeproject.ResumeLayout(false);
            this.groupBoxCodeproject.PerformLayout();
            this.groupBoxAPIs.ResumeLayout(false);
            this.groupBoxAPIs.PerformLayout();
            this.groupBoxAuthors.ResumeLayout(false);
            this.groupBoxAuthors.PerformLayout();
            this.groupBoxProjectLinks.ResumeLayout(false);
            this.groupBoxProjectLinks.PerformLayout();
            this.groupBoxTools.ResumeLayout(false);
            this.groupBoxTools.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.GroupBox groupBoxCodeproject;
        private System.Windows.Forms.LinkLabel linkLabelMultiselectTreeView;
        private System.Windows.Forms.LinkLabel linkLabelLicenseCodeProject;
        private System.Windows.Forms.GroupBox groupBoxAPIs;
        private System.Windows.Forms.LinkLabel linkLabelLicenseOpenTK;
        private System.Windows.Forms.LinkLabel linkLabelNugetGLControl;
        private System.Windows.Forms.LinkLabel linkLabelNugetOpenTK;
        private System.Windows.Forms.LinkLabel linkLabelSiteOpenTK;
        private System.Windows.Forms.Label labelOpenTK;
        private System.Windows.Forms.LinkLabel linkLabelLicenseTGA;
        private System.Windows.Forms.LinkLabel linkLabelTgaGitLab;
        private System.Windows.Forms.LinkLabel linkLabelTgaGitHub;
        private System.Windows.Forms.Label labelZelenskyi;
        private System.Windows.Forms.Label labelTGASharpLib;
        private System.Windows.Forms.GroupBox groupBoxAuthors;
        private System.Windows.Forms.TextBox textBoxJaderLinkEmail;
        private System.Windows.Forms.LinkLabel linkLabelYoutubeJaderLink;
        private System.Windows.Forms.LinkLabel linkLabelJaderLinkGitHub;
        private System.Windows.Forms.Label labelMainAuthor;
        private System.Windows.Forms.LinkLabel linkLabelJaderLinkBlog;
        private System.Windows.Forms.GroupBox groupBoxProjectLinks;
        private System.Windows.Forms.LinkLabel linkLabelProjectGitHub;
        private System.Windows.Forms.GroupBox groupBoxTools;
        private System.Windows.Forms.LinkLabel linkLabelBINTOOL;
        private System.Windows.Forms.LinkLabel linkLabelSCENARIOTOOL;
        private System.Windows.Forms.LinkLabel linkLabelSMXTOOL;
        private System.Windows.Forms.LinkLabel linkLabelLicenseDDS;
        private System.Windows.Forms.LinkLabel linkLabelDdsGitLab;
        private System.Windows.Forms.LinkLabel linkLabelDdsGitHub;
        private System.Windows.Forms.Label labelZelenskyi2;
        private System.Windows.Forms.Label labelDDSReaderSharp;
        private System.Windows.Forms.LinkLabel linkLabelDonate;
    }
}