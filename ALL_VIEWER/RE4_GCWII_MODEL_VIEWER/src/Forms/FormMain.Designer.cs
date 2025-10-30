
namespace RE4_GCWII_MODEL_VIEWER
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
            this.menuStripMenu = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemLoadBINTPL = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemLoadScenarioSMD = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemLoadSmx = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
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
            this.toolStripMenuItemVertexColor = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAlphaChannel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemTextureNearestLinear = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemCamera = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemMisc = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemChangeSkyColor = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemCredits = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemJaderlink = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.panelGL = new System.Windows.Forms.Panel();
            this.openFileDialogBINTPL = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialogSMD = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialogSMX = new System.Windows.Forms.OpenFileDialog();
            this.colorDialogSkyColor = new System.Windows.Forms.ColorDialog();
            this.menuStripMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripMenu
            // 
            this.menuStripMenu.BackColor = System.Drawing.Color.Transparent;
            this.menuStripMenu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.menuStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemFile,
            this.toolStripMenuItemActions,
            this.toolStripMenuItemView,
            this.toolStripMenuItemMisc,
            this.toolStripMenuItemJaderlink});
            this.menuStripMenu.Location = new System.Drawing.Point(0, 0);
            this.menuStripMenu.Name = "menuStripMenu";
            this.menuStripMenu.Size = new System.Drawing.Size(784, 24);
            this.menuStripMenu.TabIndex = 0;
            this.menuStripMenu.Text = "menu";
            // 
            // toolStripMenuItemFile
            // 
            this.toolStripMenuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemLoadBINTPL,
            this.toolStripSeparator1,
            this.toolStripMenuItemLoadScenarioSMD,
            this.toolStripMenuItemLoadSmx,
            this.toolStripSeparator2,
            this.toolStripMenuItemExit});
            this.toolStripMenuItemFile.Name = "toolStripMenuItemFile";
            this.toolStripMenuItemFile.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItemFile.Text = "File";
            // 
            // toolStripMenuItemLoadBINTPL
            // 
            this.toolStripMenuItemLoadBINTPL.Name = "toolStripMenuItemLoadBINTPL";
            this.toolStripMenuItemLoadBINTPL.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.toolStripMenuItemLoadBINTPL.Size = new System.Drawing.Size(257, 22);
            this.toolStripMenuItemLoadBINTPL.Text = "Load GC/WII BIN";
            this.toolStripMenuItemLoadBINTPL.Click += new System.EventHandler(this.toolStripMenuItemLoadBINTPL_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(254, 6);
            // 
            // toolStripMenuItemLoadScenarioSMD
            // 
            this.toolStripMenuItemLoadScenarioSMD.Name = "toolStripMenuItemLoadScenarioSMD";
            this.toolStripMenuItemLoadScenarioSMD.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.toolStripMenuItemLoadScenarioSMD.Size = new System.Drawing.Size(257, 22);
            this.toolStripMenuItemLoadScenarioSMD.Text = "Load GC/WII Scenario SMD";
            this.toolStripMenuItemLoadScenarioSMD.Click += new System.EventHandler(this.toolStripMenuItemLoadScenarioSMD_Click);
            // 
            // toolStripMenuItemLoadSmx
            // 
            this.toolStripMenuItemLoadSmx.Name = "toolStripMenuItemLoadSmx";
            this.toolStripMenuItemLoadSmx.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.K)));
            this.toolStripMenuItemLoadSmx.Size = new System.Drawing.Size(257, 22);
            this.toolStripMenuItemLoadSmx.Text = "Load SMX";
            this.toolStripMenuItemLoadSmx.Click += new System.EventHandler(this.toolStripMenuItemLoadSmx_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(254, 6);
            // 
            // toolStripMenuItemExit
            // 
            this.toolStripMenuItemExit.Name = "toolStripMenuItemExit";
            this.toolStripMenuItemExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.toolStripMenuItemExit.Size = new System.Drawing.Size(257, 22);
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
            this.toolStripMenuItemVertexColor,
            this.toolStripMenuItemAlphaChannel,
            this.toolStripMenuItemTextureNearestLinear,
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
            // toolStripMenuItemVertexColor
            // 
            this.toolStripMenuItemVertexColor.Name = "toolStripMenuItemVertexColor";
            this.toolStripMenuItemVertexColor.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D5)));
            this.toolStripMenuItemVertexColor.Size = new System.Drawing.Size(278, 22);
            this.toolStripMenuItemVertexColor.Text = "Enable/Disable Vertex Color";
            this.toolStripMenuItemVertexColor.Click += new System.EventHandler(this.toolStripMenuItemVertexColor_Click);
            // 
            // toolStripMenuItemAlphaChannel
            // 
            this.toolStripMenuItemAlphaChannel.Name = "toolStripMenuItemAlphaChannel";
            this.toolStripMenuItemAlphaChannel.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D6)));
            this.toolStripMenuItemAlphaChannel.Size = new System.Drawing.Size(278, 22);
            this.toolStripMenuItemAlphaChannel.Text = "Enable/Disable Alpha Channel";
            this.toolStripMenuItemAlphaChannel.Click += new System.EventHandler(this.toolStripMenuItemAlphaChannel_Click);
            // 
            // toolStripMenuItemTextureNearestLinear
            // 
            this.toolStripMenuItemTextureNearestLinear.Name = "toolStripMenuItemTextureNearestLinear";
            this.toolStripMenuItemTextureNearestLinear.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D7)));
            this.toolStripMenuItemTextureNearestLinear.Size = new System.Drawing.Size(278, 22);
            this.toolStripMenuItemTextureNearestLinear.Text = "Use Texture Nearest/Linear";
            this.toolStripMenuItemTextureNearestLinear.Click += new System.EventHandler(this.toolStripMenuItemTextureNearestLinear_Click);
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
            // toolStripMenuItemJaderlink
            // 
            this.toolStripMenuItemJaderlink.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripMenuItemJaderlink.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripMenuItemJaderlink.Name = "toolStripMenuItemJaderlink";
            this.toolStripMenuItemJaderlink.Size = new System.Drawing.Size(314, 20);
            this.toolStripMenuItemJaderlink.Text = "Subscribe on my channel: youtube.com/@JADERLINK";
            this.toolStripMenuItemJaderlink.Click += new System.EventHandler(this.toolStripMenuItemJaderlink_Click);
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
            // openFileDialogBINTPL
            // 
            this.openFileDialogBINTPL.Filter = "BIN|*.BIN";
            this.openFileDialogBINTPL.Multiselect = true;
            this.openFileDialogBINTPL.Title = "LOAD GC/WII BIN";
            this.openFileDialogBINTPL.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialogBINTPL_FileOk);
            // 
            // openFileDialogSMD
            // 
            this.openFileDialogSMD.DefaultExt = "SMD";
            this.openFileDialogSMD.Filter = "Scenario SMD|*.SMD";
            this.openFileDialogSMD.Title = "LOAD GC/WII SCENARIO SMD";
            this.openFileDialogSMD.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialogSMD_FileOk);
            // 
            // openFileDialogSMX
            // 
            this.openFileDialogSMX.DefaultExt = "SMX";
            this.openFileDialogSMX.Filter = "SMX|*.SMX";
            this.openFileDialogSMX.Title = "LOAD SMX";
            this.openFileDialogSMX.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialogSMX_FileOk);
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
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.splitContainerMain);
            this.Controls.Add(this.menuStripMenu);
            this.Icon = global::RE4_GCWII_MODEL_VIEWER.Properties.Resources.icon;
            this.MinimumSize = new System.Drawing.Size(400, 300);
            this.Name = "FormMain";
            this.Text = "RE4 GCWII MODEL VIEWER | V.1.0.7 | YOUTUBE.COM/@JADERLINK";
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
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemLoadBINTPL;
        private System.Windows.Forms.OpenFileDialog openFileDialogBINTPL;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemLoadScenarioSMD;
        private System.Windows.Forms.OpenFileDialog openFileDialogSMD;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemLoadSmx;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemExit;
        private System.Windows.Forms.OpenFileDialog openFileDialogSMX;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemActions;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRemoveSelected;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemMoveUp;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemMoveDown;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemLateralMenu;
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
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemVertexColor;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAlphaChannel;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemTextureNearestLinear;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemJaderlink;
    }
}

