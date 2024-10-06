using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JADERLINK_MODEL_VIEWER.src;
using ViewerBase;
using ShaderLoader;
using RE4_UHD_MODEL_VIEWER.src;
using JADERLINK_MODEL_VIEWER.src.Nodes;
using JADERLINK_MODEL_VIEWER.src.Forms;
using System.IO;
using Re4ViewerRender;
using LoadUhdPs4Ns.src;

namespace RE4_UHD_MODEL_VIEWER
{
    public partial class FormMain : Form
    {
        private RenderControl renderControl;
        private NsMultiselectTreeView.MultiselectTreeView treeViewObjs;

        private ModelNodeGroup mng;
        private TexturePackNodeGroup tpng;
        private ScenarioNodeGroup sng;

        private Color SkyColor = Color.FromArgb(0x94D2FF);

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void OnExit(object sender, EventArgs e)
        {
            foreach (TreeNode item in mng.Nodes)
            {
                if (item is NodeItem i)
                {
                    i.Responsibility.ReleaseResponsibilities();
                }
            }

            foreach (TreeNode item in tpng.Nodes)
            {
                if (item is NodeItem i)
                {
                    i.Responsibility.ReleaseResponsibilities();
                }
            }

            foreach (TreeNode item in sng.Nodes)
            {
                if (item is NodeItem i)
                {
                    i.Responsibility.ReleaseResponsibilities();
                }
            }

            whitetex?.Unload();
            whitetex2?.Unload();
        }

        public FormMain()
        {
            InitializeComponent();
            InitializeTreeView();
            Application.ApplicationExit += new EventHandler(OnExit);
            renderControl = new RenderControl();
            panelGL.Controls.Add(renderControl.GlControl);
            KeyPreview = true;
            renderControl.GlControl.Paint += GlControl_Paint;
            renderControl.GlControlLoad = GlControl_Load;

            mng = new ModelNodeGroup("BIN/TPL MODELS");
            mng.Name = "MODELGROUP";
            mng.ForeColor = Color.DarkSlateGray;
            mng.NodeFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            treeViewObjs.Nodes.Add(mng);

            tpng = new TexturePackNodeGroup("PACK TEXTURES");
            tpng.Name = "TEXTUREGROUP";
            tpng.ForeColor = Color.DarkSlateGray;
            tpng.NodeFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            treeViewObjs.Nodes.Add(tpng);


            sng = new ScenarioNodeGroup("UHD SCENARIO");
            sng.Name = "SCENARIOGROUP";
            sng.ForeColor = Color.DarkSlateGray;
            sng.NodeFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            treeViewObjs.Nodes.Add(sng);
        }

        private void InitializeTreeView() 
        {
            treeViewObjs = new NsMultiselectTreeView.MultiselectTreeView();
            treeViewObjs.BackColor = System.Drawing.SystemColors.Control;
            treeViewObjs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            treeViewObjs.Dock = System.Windows.Forms.DockStyle.Fill;
            treeViewObjs.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText;
            treeViewObjs.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            treeViewObjs.HideSelection = false;
            treeViewObjs.LineColor = System.Drawing.Color.DarkGray;
            treeViewObjs.Location = new System.Drawing.Point(0, 0);
            treeViewObjs.Name = "treeViewObjs";
            treeViewObjs.ShowNodeToolTips = true;
            treeViewObjs.Size = new System.Drawing.Size(208, 216);
            treeViewObjs.TabIndex = 0;
            treeViewObjs.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewObjs_AfterSelect);
            treeViewObjs.SelectedNodeBackColor = Color.FromArgb(0x70, 0xBB, 0xDB);
            splitContainerMain.Panel1.Controls.Add(treeViewObjs);
                
        }

        private void GlControl_Load(object sender, EventArgs e)
        {
            bool load = true;
            try
            {
                string OpenGLVersion = OpenTK.Graphics.OpenGL.GL.GetString(OpenTK.Graphics.OpenGL.StringName.Version).Trim();

                if (OpenGLVersion.StartsWith("1.")
                    || OpenGLVersion.StartsWith("2.")
                    || OpenGLVersion.StartsWith("3.0")
                    || OpenGLVersion.StartsWith("3.1")
                    || OpenGLVersion.StartsWith("3.2")
                    )
                {
                    System.Windows.Forms.MessageBox.Show(
                        "Error: You have an outdated version of OpenGL, which is not supported by this program." +
                        " The program will now exit.\n\n" +
                        "OpenGL version: [" + OpenGLVersion + "]\n",
                        "OpenGL version error:",
                        System.Windows.Forms.MessageBoxButtons.OK,
                        System.Windows.Forms.MessageBoxIcon.Error);
                    load = false;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(
                      "Error: " +
                      ex.Message,
                      "Error detecting OpenGL version:",
                      System.Windows.Forms.MessageBoxButtons.OK,
                      System.Windows.Forms.MessageBoxIcon.Error);
                load = false;
                this.Close();
            }

            if (load)
            {
                modelGroup = new ModelGroup();
                order = new RenderOrder();
                modelNodeOrder = new ModelNodeOrder(mng);
                modelNodeLinker = new ModelNodeLinker(modelGroup, mng);
                objShader = new Shader(Encoding.UTF8.GetString(Properties.Resources.ObjShaderVert), Encoding.UTF8.GetString(Properties.Resources.ObjShaderFrag));
                objShader.Use();
                objShader.SetInt("texture0", 0);
                objShader.SetInt("texture1", 1);
                whitetex = new TextureRef(Properties.Resources.WhiteTexture);
                whitetex2 = new TextureRef(Properties.Resources.WhiteTexture);// fix bind error
            }
        }

        private void GlControl_Paint(object sender, PaintEventArgs e)
        {
            
            TheRender.Render(ref renderControl.CamMtx, ref renderControl.ProjMatrix, order, modelGroup, objShader, whitetex, SkyColor, renderControl.Camera.Position); // rederiza todos os objetos do GL;
            renderControl.GlControl.SwapBuffers();
        }

        ModelGroup modelGroup;
        RenderOrder order;
        Shader objShader;
        TextureRef whitetex;
        TextureRef whitetex2;

        ModelNodeOrder modelNodeOrder;
        ModelNodeLinker modelNodeLinker;
        private void toolStripMenuItemLoadBINTPL_Click(object sender, EventArgs e)
        {
            openFileDialogBINTPL.ShowDialog();
        }

        private void toolStripMenuItemLoadScenarioSMD_Click(object sender, EventArgs e)
        {
            openFileDialogSMD.ShowDialog();
        }

        private void toolStripMenuItemLoadSmx_Click(object sender, EventArgs e)
        {
            openFileDialogSMX.ShowDialog();
        }

        private void toolStripMenuItemLoadPACK_Click(object sender, EventArgs e)
        {
            openFileDialogPACK.ShowDialog();
        }

        private void openFileDialogBINTPL_FileOk(object sender, CancelEventArgs e)
        {
            treeViewObjs.SuspendLayout();

            LoadUhdBinModel loadBinModel = new LoadUhdBinModel(modelGroup, mng, false);
            LoadUhdTpl loadTpl = new LoadUhdTpl(modelGroup, mng, false);
            for (int i = 0; i < openFileDialogBINTPL.FileNames.Length; i++)
            {
                string file = openFileDialogBINTPL.FileNames[i];
                FileInfo info = new FileInfo(file);
                string extension = info.Extension.ToUpperInvariant();
                if (extension.Contains("BIN"))
                {
                    loadBinModel.LoadUhdBIN(file);
                }
                else if (extension.Contains("TPL"))
                {
                    loadTpl.LoadUhdTPL(file);
                }

            }

            modelNodeOrder.GetNodeOrder();
            modelNodeLinker.GetNodeLinker();
            order.ToOrder(ref modelGroup, modelNodeOrder.NodeOrder);
            mng.Expand();
            tpng.Expand();
            treeViewObjs.ResumeLayout();

            renderControl.GlControl.Invalidate();
        }

        private void openFileDialogPACK_FileOk(object sender, CancelEventArgs e)
        {
            treeViewObjs.SuspendLayout();

            LoadUhdPack loadPACK = new LoadUhdPack(modelGroup, tpng);
            for (int i = 0; i < openFileDialogPACK.FileNames.Length; i++) 
            {
                string file = openFileDialogPACK.FileNames[i];
                loadPACK.LoadPack(file);
            }

            modelNodeOrder.GetNodeOrder();
            order.ToOrder(ref modelGroup, modelNodeOrder.NodeOrder);
            mng.Expand();
            tpng.Expand();
            treeViewObjs.ResumeLayout();

            renderControl.GlControl.Invalidate();
        }

        private void openFileDialogSMD_FileOk(object sender, CancelEventArgs e)
        {
            treeViewObjs.SuspendLayout();

            LoadUhdScenarioSMD loadScenarioSMD = new LoadUhdScenarioSMD(modelGroup, sng, false);
            loadScenarioSMD.LoadScenario(openFileDialogSMD.FileName);

            modelNodeOrder.GetNodeOrder();
            order.ToOrder(ref modelGroup, modelNodeOrder.NodeOrder);
            sng.Expand();
            treeViewObjs.ResumeLayout();

            renderControl.GlControl.Invalidate();
        }

        private void openFileDialogSMX_FileOk(object sender, CancelEventArgs e)
        {
            treeViewObjs.SuspendLayout();

            LoadSMX loadSMX = new LoadSMX(modelGroup, sng);
            loadSMX.LoadSmx(openFileDialogSMX.FileName, false);

            modelNodeOrder.GetNodeOrder();
            order.ToOrder(ref modelGroup, modelNodeOrder.NodeOrder);
            sng.Expand();
            treeViewObjs.ResumeLayout();

            renderControl.GlControl.Invalidate();
        }

        private void toolStripMenuItemRefresh_Click(object sender, EventArgs e)
        {
            renderControl.GlControl.Invalidate();
            treeViewObjs.Refresh();
            renderControl.GlControl.Update();
        }

        private void treeViewObjs_AfterSelect(object sender, TreeViewEventArgs e)
        {
        }

        bool splitContainerMainPanel1Show = true;

        private void toolStripMenuItemLateralMenu_Click(object sender, EventArgs e)
        {
            if (splitContainerMainPanel1Show)
            {
                splitContainerMain.Panel1Collapsed = true;
                splitContainerMainPanel1Show = false;
            }
            else 
            {
                splitContainerMain.Panel1Collapsed = false;
                splitContainerMainPanel1Show = true;
            }
        }

        private void toolStripMenuItemShowHideModel_Click(object sender, EventArgs e)
        {
            treeViewObjs.SuspendLayout();
            foreach (TreeNode item in treeViewObjs.SelectedNodes.Values)
            {
                if (item is NodeModel i)
                {
                    i.SetModelIsEnable(!i.ModelIsEnable);
                }
            }

            treeViewObjs.ResumeLayout();
            treeViewObjs.Refresh();

            modelNodeOrder.GetNodeOrder();
            order.ToOrder(ref modelGroup, modelNodeOrder.NodeOrder);
            renderControl.GlControl.Invalidate();
        }

        private void toolStripMenuItemRemoveSelected_Click(object sender, EventArgs e)
        {
            treeViewObjs.SuspendLayout();
            foreach (TreeNode item in treeViewObjs.SelectedNodes.Values)
            {
                if (item is NodeItem i)
                {
                    i.Responsibility.ReleaseResponsibilities();
                    i.Remove();
                }
            }

            treeViewObjs.ResumeLayout();
            treeViewObjs.Refresh();

            modelNodeOrder.GetNodeOrder();
            modelNodeLinker.GetNodeLinker();
            order.ToOrder(ref modelGroup, modelNodeOrder.NodeOrder);
            treeViewObjs.SelectedNodes = null;
            renderControl.GlControl.Invalidate();
        }

        private void toolStripMenuItemMoveUp_Click(object sender, EventArgs e)
        {
            treeViewObjs.SuspendLayout();

            var ordernedSelectedNodes = treeViewObjs.SelectedNodes.Values.OrderBy(n => n.Index);
            foreach (TreeNode item in ordernedSelectedNodes)
            {
                int index = item.Index;
                if (index > 0)
                {
                    var Parent = item.Parent;
                    item.Remove();
                    Parent.Nodes.Insert(index - 1, item);
                }
            }

            treeViewObjs.ResumeLayout();
            treeViewObjs.Refresh();

            modelNodeOrder.GetNodeOrder();
            modelNodeLinker.GetNodeLinker();
            order.ToOrder(ref modelGroup, modelNodeOrder.NodeOrder);
            renderControl.GlControl.Invalidate();
        }

        private void toolStripMenuItemMoveDown_Click(object sender, EventArgs e)
        {
            treeViewObjs.SuspendLayout();

            var invSelectedNodes = treeViewObjs.SelectedNodes.Values.OrderByDescending(n => n.Index);
            foreach (TreeNode item in invSelectedNodes)
            {
                int index = item.Index;
                var Parent = item.Parent;
                if (index < Parent.GetNodeCount(false) - 1)
                {
                    item.Remove();
                    Parent.Nodes.Insert(index + 1, item);
                }

            }

            treeViewObjs.ResumeLayout();
            treeViewObjs.Refresh();

            modelNodeOrder.GetNodeOrder();
            modelNodeLinker.GetNodeLinker();
            order.ToOrder(ref modelGroup, modelNodeOrder.NodeOrder);
            renderControl.GlControl.Invalidate();
        }

        private void toolStripMenuItemShowHideTextures_Click(object sender, EventArgs e)
        {
            TheRender.RenderTextures = !TheRender.RenderTextures;
            renderControl.GlControl.Invalidate();
        }

        private void toolStripMenuItemWireframe_Click(object sender, EventArgs e)
        {
            TheRender.RenderWireframe = !TheRender.RenderWireframe;
            renderControl.GlControl.Invalidate();
        }

        private void toolStripMenuItemChangeSkyColor_Click(object sender, EventArgs e)
        {
            colorDialogSkyColor.Color = SkyColor;
            colorDialogSkyColor.ShowDialog();
            SkyColor = colorDialogSkyColor.Color;
            renderControl.GlControl.Invalidate();
        }

        private void toolStripMenuItemRenderNormals_Click(object sender, EventArgs e)
        {
            TheRender.RenderNormals = !TheRender.RenderNormals;
            renderControl.GlControl.Invalidate();
        }

        private void toolStripMenuItemOnlyFrontFace_Click(object sender, EventArgs e)
        {
            TheRender.RenderOnlyFrontFace = !TheRender.RenderOnlyFrontFace;
            renderControl.GlControl.Invalidate();
        }

        private void toolStripMenuItemVertexColor_Click(object sender, EventArgs e)
        {
            TheRender.RenderVertexColor = !TheRender.RenderVertexColor;
            renderControl.GlControl.Invalidate();
        }

        private void toolStripMenuItemAlphaChannel_Click(object sender, EventArgs e)
        {
            TheRender.RenderAlphaChannel = !TheRender.RenderAlphaChannel;
            renderControl.GlControl.Invalidate();
        }

        private void toolStripMenuItemTextureNearestLinear_Click(object sender, EventArgs e)
        {
            if (TextureRef.LoadTextureLinear)
            {
                TextureRef.LoadTextureLinear = false;
                foreach (var item in modelGroup.TextureRefDic)
                {
                    item.Value.SetNearest();
                }
            }
            else
            {
                TextureRef.LoadTextureLinear = true;
                foreach (var item in modelGroup.TextureRefDic)
                {
                    item.Value.SetLinear();
                }
            }
            renderControl.GlControl.Invalidate();
        }

        FormCamera cameraForm = null;
        int lastTrackBarCamSpeedValue = 50;

        private void toolStripMenuItemCamera_Click(object sender, EventArgs e)
        {
            if (cameraForm == null)
            {
                cameraForm = new FormCamera(renderControl, lastTrackBarCamSpeedValue);
                cameraForm.FormClosed += FormCamera_FormClosed;
                cameraForm.TrackBarCamSpeedValueIsChanged = TrackBarCamSpeedValueIsChanged;
                cameraForm.Show();
            }
            else
            {
                cameraForm.Select();
            }

        }

        private void TrackBarCamSpeedValueIsChanged(int value)
        {
            lastTrackBarCamSpeedValue = value;
        }

        private void FormCamera_FormClosed(object sender, FormClosedEventArgs e)
        {
            cameraForm = null;
        }


        FormCredits creditsForm = null;

        private void toolStripMenuItemCredits_Click(object sender, EventArgs e)
        {
            if (creditsForm == null)
            {
                creditsForm = new FormCredits();
                creditsForm.FormClosed += CreditsForm_FormClosed;
                creditsForm.Show();
            }
            else
            {
                creditsForm.Select();
            }
        }

        private void CreditsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            creditsForm = null;
        }

    }
}
