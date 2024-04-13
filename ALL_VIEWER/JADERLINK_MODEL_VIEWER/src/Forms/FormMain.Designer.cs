﻿
namespace JADERLINK_MODEL_VIEWER
{
    partial class FormMain
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menuStripMenu = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemLoadObj = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemLoadObjSplit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemLoadSMD = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemLoadMTL = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemTextures = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemActions = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemRemoveSelected = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemMoveUp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemMoveDown = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemShowHideModel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemView = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemLateralMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemShowHideTextures = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemWireframe = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemRenderNormals = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemOnlyFrontFace = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemCamera = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemMisc = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemChangeSkyColor = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemCredits = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.panelGL = new System.Windows.Forms.Panel();
            this.openFileDialogOBJ = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialogSMD = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialogMTL = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialogTEXTURES = new System.Windows.Forms.OpenFileDialog();
            this.colorDialogSkyColor = new System.Windows.Forms.ColorDialog();
            this.menuStripMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripMenu
            // 
            this.menuStripMenu.BackColor = System.Drawing.Color.Gainsboro;
            this.menuStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemFile,
            this.toolStripMenuItemActions,
            this.toolStripMenuItemView,
            this.toolStripMenuItemMisc});
            this.menuStripMenu.Location = new System.Drawing.Point(0, 0);
            this.menuStripMenu.Name = "menuStripMenu";
            this.menuStripMenu.Size = new System.Drawing.Size(784, 24);
            this.menuStripMenu.TabIndex = 0;
            this.menuStripMenu.Text = "menu";
            // 
            // toolStripMenuItemFile
            // 
            this.toolStripMenuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemLoadObj,
            this.toolStripMenuItemLoadObjSplit,
            this.toolStripMenuItemLoadSMD,
            this.toolStripMenuItemLoadMTL,
            this.toolStripMenuItemTextures,
            this.toolStripSeparator1,
            this.toolStripMenuItemExit});
            this.toolStripMenuItemFile.Name = "toolStripMenuItemFile";
            this.toolStripMenuItemFile.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItemFile.Text = "File";
            // 
            // toolStripMenuItemLoadObj
            // 
            this.toolStripMenuItemLoadObj.Name = "toolStripMenuItemLoadObj";
            this.toolStripMenuItemLoadObj.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.toolStripMenuItemLoadObj.Size = new System.Drawing.Size(260, 22);
            this.toolStripMenuItemLoadObj.Text = "Load OBJ (One Group)";
            this.toolStripMenuItemLoadObj.Click += new System.EventHandler(this.toolStripMenuItemLoadObj_Click);
            // 
            // toolStripMenuItemLoadObjSplit
            // 
            this.toolStripMenuItemLoadObjSplit.Name = "toolStripMenuItemLoadObjSplit";
            this.toolStripMenuItemLoadObjSplit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.toolStripMenuItemLoadObjSplit.Size = new System.Drawing.Size(260, 22);
            this.toolStripMenuItemLoadObjSplit.Text = "Load OBJ (Split Groups)";
            this.toolStripMenuItemLoadObjSplit.Click += new System.EventHandler(this.toolStripMenuItemLoadObjSplit_Click);
            // 
            // toolStripMenuItemLoadSMD
            // 
            this.toolStripMenuItemLoadSMD.Name = "toolStripMenuItemLoadSMD";
            this.toolStripMenuItemLoadSMD.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
            this.toolStripMenuItemLoadSMD.Size = new System.Drawing.Size(260, 22);
            this.toolStripMenuItemLoadSMD.Text = "Load SMD (StudioMdlData)";
            this.toolStripMenuItemLoadSMD.Click += new System.EventHandler(this.toolStripMenuItemLoadSMD_Click);
            // 
            // toolStripMenuItemLoadMTL
            // 
            this.toolStripMenuItemLoadMTL.Name = "toolStripMenuItemLoadMTL";
            this.toolStripMenuItemLoadMTL.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.toolStripMenuItemLoadMTL.Size = new System.Drawing.Size(260, 22);
            this.toolStripMenuItemLoadMTL.Text = "Load MTL (Materials)";
            this.toolStripMenuItemLoadMTL.Click += new System.EventHandler(this.toolStripMenuItemLoadMTL_Click);
            // 
            // toolStripMenuItemTextures
            // 
            this.toolStripMenuItemTextures.Name = "toolStripMenuItemTextures";
            this.toolStripMenuItemTextures.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.toolStripMenuItemTextures.Size = new System.Drawing.Size(260, 22);
            this.toolStripMenuItemTextures.Text = "Load Textures Files";
            this.toolStripMenuItemTextures.Click += new System.EventHandler(this.toolStripMenuItemTextures_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(257, 6);
            // 
            // toolStripMenuItemExit
            // 
            this.toolStripMenuItemExit.Name = "toolStripMenuItemExit";
            this.toolStripMenuItemExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.toolStripMenuItemExit.Size = new System.Drawing.Size(260, 22);
            this.toolStripMenuItemExit.Text = "Exit";
            this.toolStripMenuItemExit.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // toolStripMenuItemActions
            // 
            this.toolStripMenuItemActions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemRemoveSelected,
            this.toolStripMenuItemMoveUp,
            this.toolStripMenuItemMoveDown,
            this.toolStripMenuItemShowHideModel});
            this.toolStripMenuItemActions.Name = "toolStripMenuItemActions";
            this.toolStripMenuItemActions.Size = new System.Drawing.Size(59, 20);
            this.toolStripMenuItemActions.Text = "Actions";
            // 
            // toolStripMenuItemRemoveSelected
            // 
            this.toolStripMenuItemRemoveSelected.Name = "toolStripMenuItemRemoveSelected";
            this.toolStripMenuItemRemoveSelected.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.toolStripMenuItemRemoveSelected.Size = new System.Drawing.Size(268, 22);
            this.toolStripMenuItemRemoveSelected.Text = "Remove Selected(s) object(s)";
            this.toolStripMenuItemRemoveSelected.Click += new System.EventHandler(this.toolStripMenuItemRemoveSelected_Click);
            // 
            // toolStripMenuItemMoveUp
            // 
            this.toolStripMenuItemMoveUp.Name = "toolStripMenuItemMoveUp";
            this.toolStripMenuItemMoveUp.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Up)));
            this.toolStripMenuItemMoveUp.Size = new System.Drawing.Size(268, 22);
            this.toolStripMenuItemMoveUp.Text = "Move Object(s) To Up";
            this.toolStripMenuItemMoveUp.Click += new System.EventHandler(this.toolStripMenuItemMoveUp_Click);
            // 
            // toolStripMenuItemMoveDown
            // 
            this.toolStripMenuItemMoveDown.Name = "toolStripMenuItemMoveDown";
            this.toolStripMenuItemMoveDown.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Down)));
            this.toolStripMenuItemMoveDown.Size = new System.Drawing.Size(268, 22);
            this.toolStripMenuItemMoveDown.Text = "Move Object(s) To Down";
            this.toolStripMenuItemMoveDown.Click += new System.EventHandler(this.toolStripMenuItemMoveDown_Click);
            // 
            // toolStripMenuItemShowHideModel
            // 
            this.toolStripMenuItemShowHideModel.Name = "toolStripMenuItemShowHideModel";
            this.toolStripMenuItemShowHideModel.ShortcutKeys = System.Windows.Forms.Keys.Insert;
            this.toolStripMenuItemShowHideModel.Size = new System.Drawing.Size(268, 22);
            this.toolStripMenuItemShowHideModel.Text = "Show/Hide Selected(s)  Model(s)";
            this.toolStripMenuItemShowHideModel.Click += new System.EventHandler(this.toolStripMenuItemShowHideModel_Click);
            // 
            // toolStripMenuItemView
            // 
            this.toolStripMenuItemView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemLateralMenu,
            this.toolStripMenuItemShowHideTextures,
            this.toolStripMenuItemWireframe,
            this.toolStripMenuItemRenderNormals,
            this.toolStripMenuItemOnlyFrontFace,
            this.toolStripMenuItemCamera,
            this.toolStripMenuItemRefresh});
            this.toolStripMenuItemView.Name = "toolStripMenuItemView";
            this.toolStripMenuItemView.Size = new System.Drawing.Size(44, 20);
            this.toolStripMenuItemView.Text = "View";
            // 
            // toolStripMenuItemLateralMenu
            // 
            this.toolStripMenuItemLateralMenu.Name = "toolStripMenuItemLateralMenu";
            this.toolStripMenuItemLateralMenu.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.toolStripMenuItemLateralMenu.Size = new System.Drawing.Size(278, 22);
            this.toolStripMenuItemLateralMenu.Text = "Show/Hide Lateral Menu";
            this.toolStripMenuItemLateralMenu.Click += new System.EventHandler(this.toolStripMenuItemLateralMenu_Click);
            // 
            // toolStripMenuItemShowHideTextures
            // 
            this.toolStripMenuItemShowHideTextures.Name = "toolStripMenuItemShowHideTextures";
            this.toolStripMenuItemShowHideTextures.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D1)));
            this.toolStripMenuItemShowHideTextures.Size = new System.Drawing.Size(278, 22);
            this.toolStripMenuItemShowHideTextures.Text = "Show/Hide Textures";
            this.toolStripMenuItemShowHideTextures.Click += new System.EventHandler(this.toolStripMenuItemShowHideTextures_Click);
            // 
            // toolStripMenuItemWireframe
            // 
            this.toolStripMenuItemWireframe.Name = "toolStripMenuItemWireframe";
            this.toolStripMenuItemWireframe.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D2)));
            this.toolStripMenuItemWireframe.Size = new System.Drawing.Size(278, 22);
            this.toolStripMenuItemWireframe.Text = "Enable/Disable Wireframe";
            this.toolStripMenuItemWireframe.Click += new System.EventHandler(this.toolStripMenuItemWireframe_Click);
            // 
            // toolStripMenuItemRenderNormals
            // 
            this.toolStripMenuItemRenderNormals.Name = "toolStripMenuItemRenderNormals";
            this.toolStripMenuItemRenderNormals.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D3)));
            this.toolStripMenuItemRenderNormals.Size = new System.Drawing.Size(278, 22);
            this.toolStripMenuItemRenderNormals.Text = "Enable/Disable Normals";
            this.toolStripMenuItemRenderNormals.Click += new System.EventHandler(this.toolStripMenuItemRenderNormals_Click);
            // 
            // toolStripMenuItemOnlyFrontFace
            // 
            this.toolStripMenuItemOnlyFrontFace.Name = "toolStripMenuItemOnlyFrontFace";
            this.toolStripMenuItemOnlyFrontFace.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D4)));
            this.toolStripMenuItemOnlyFrontFace.Size = new System.Drawing.Size(278, 22);
            this.toolStripMenuItemOnlyFrontFace.Text = "Enable/Disable Only Front Face";
            this.toolStripMenuItemOnlyFrontFace.Click += new System.EventHandler(this.toolStripMenuItemOnlyFrontFace_Click);
            // 
            // toolStripMenuItemCamera
            // 
            this.toolStripMenuItemCamera.Name = "toolStripMenuItemCamera";
            this.toolStripMenuItemCamera.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.toolStripMenuItemCamera.Size = new System.Drawing.Size(278, 22);
            this.toolStripMenuItemCamera.Text = "Camera";
            this.toolStripMenuItemCamera.Click += new System.EventHandler(this.toolStripMenuItemCamera_Click);
            // 
            // toolStripMenuItemRefresh
            // 
            this.toolStripMenuItemRefresh.Name = "toolStripMenuItemRefresh";
            this.toolStripMenuItemRefresh.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.toolStripMenuItemRefresh.Size = new System.Drawing.Size(278, 22);
            this.toolStripMenuItemRefresh.Text = "Refresh Display";
            this.toolStripMenuItemRefresh.Click += new System.EventHandler(this.toolStripMenuItemRefresh_Click);
            // 
            // toolStripMenuItemMisc
            // 
            this.toolStripMenuItemMisc.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemChangeSkyColor,
            this.toolStripMenuItemCredits});
            this.toolStripMenuItemMisc.Name = "toolStripMenuItemMisc";
            this.toolStripMenuItemMisc.Size = new System.Drawing.Size(44, 20);
            this.toolStripMenuItemMisc.Text = "Misc";
            // 
            // toolStripMenuItemChangeSkyColor
            // 
            this.toolStripMenuItemChangeSkyColor.Name = "toolStripMenuItemChangeSkyColor";
            this.toolStripMenuItemChangeSkyColor.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.toolStripMenuItemChangeSkyColor.Size = new System.Drawing.Size(187, 22);
            this.toolStripMenuItemChangeSkyColor.Text = "Change Sky Color";
            this.toolStripMenuItemChangeSkyColor.Click += new System.EventHandler(this.toolStripMenuItemChangeSkyColor_Click);
            // 
            // toolStripMenuItemCredits
            // 
            this.toolStripMenuItemCredits.Name = "toolStripMenuItemCredits";
            this.toolStripMenuItemCredits.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.toolStripMenuItemCredits.Size = new System.Drawing.Size(187, 22);
            this.toolStripMenuItemCredits.Text = "Credits";
            this.toolStripMenuItemCredits.Click += new System.EventHandler(this.toolStripMenuItemCredits_Click);
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.BackColor = System.Drawing.SystemColors.ControlLight;
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 24);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainerMain.Panel1MinSize = 150;
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainerMain.Panel2.Controls.Add(this.panelGL);
            this.splitContainerMain.Size = new System.Drawing.Size(784, 437);
            this.splitContainerMain.SplitterDistance = 150;
            this.splitContainerMain.TabIndex = 1;
            this.splitContainerMain.TabStop = false;
            // 
            // panelGL
            // 
            this.panelGL.BackColor = System.Drawing.SystemColors.Control;
            this.panelGL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGL.Location = new System.Drawing.Point(0, 0);
            this.panelGL.Name = "panelGL";
            this.panelGL.Size = new System.Drawing.Size(630, 437);
            this.panelGL.TabIndex = 0;
            // 
            // openFileDialogOBJ
            // 
            this.openFileDialogOBJ.Filter = "OBJ and MTL | *.OBJ;*.MTL";
            this.openFileDialogOBJ.Multiselect = true;
            this.openFileDialogOBJ.Title = "LOAD OBJ";
            this.openFileDialogOBJ.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialogOBJ_FileOk);
            // 
            // openFileDialogSMD
            // 
            this.openFileDialogSMD.Filter = "SMD and MTL | *.SMD;*.MTL";
            this.openFileDialogSMD.Multiselect = true;
            this.openFileDialogSMD.Title = "LOAD SMD";
            this.openFileDialogSMD.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialogSMD_FileOk);
            // 
            // openFileDialogMTL
            // 
            this.openFileDialogMTL.DefaultExt = "MTL";
            this.openFileDialogMTL.Filter = "MTL | *.MTL";
            this.openFileDialogMTL.Multiselect = true;
            this.openFileDialogMTL.Title = "LOAD MTL";
            this.openFileDialogMTL.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialogMTL_FileOk);
            // 
            // openFileDialogTEXTURES
            // 
            this.openFileDialogTEXTURES.Filter = "TEXTURES| *.DDS;*.TGA;*.PNG;*.BMP;*.GIF;*.JPG;*.JPEG";
            this.openFileDialogTEXTURES.Multiselect = true;
            this.openFileDialogTEXTURES.Title = "LOAD TEXTURES";
            this.openFileDialogTEXTURES.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialogTEXTURES_FileOk);
            // 
            // colorDialogSkyColor
            // 
            this.colorDialogSkyColor.FullOpen = true;
            this.colorDialogSkyColor.SolidColorOnly = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.splitContainerMain);
            this.Controls.Add(this.menuStripMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(400, 300);
            this.Name = "FormMain";
            this.Text = "JADERLINK MODEL VIEWER | V.1.0.0 | YOUTUBE.COM/@JADERLINK";
            this.menuStripMenu.ResumeLayout(false);
            this.menuStripMenu.PerformLayout();
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemFile;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemView;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemMisc;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.Panel panelGL;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemLoadObj;
        private System.Windows.Forms.OpenFileDialog openFileDialogOBJ;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemLoadSMD;
        private System.Windows.Forms.OpenFileDialog openFileDialogSMD;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemLoadObjSplit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemLoadMTL;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemExit;
        private System.Windows.Forms.OpenFileDialog openFileDialogMTL;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemActions;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRemoveSelected;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemMoveUp;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemMoveDown;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemLateralMenu;
        private System.Windows.Forms.OpenFileDialog openFileDialogTEXTURES;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemShowHideModel;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemChangeSkyColor;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCredits;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemShowHideTextures;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemWireframe;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRefresh;
        private System.Windows.Forms.ColorDialog colorDialogSkyColor;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRenderNormals;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOnlyFrontFace;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCamera;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemTextures;
    }
}
