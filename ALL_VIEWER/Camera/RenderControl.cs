using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using NsCamera;

namespace JADERLINK_MODEL_VIEWER.src
{
    public class RenderControl
    {
        public GLControl GlControl { get { return glControl; } }
        public Timer MyTimer { get { return myTimer; } }

        private GLControl glControl;
        private readonly Timer myTimer = new Timer();

        #region Camera // variaveis para a camera
        public Camera Camera { get { return camera; } }
        private readonly Camera camera = new Camera();
        public Matrix4 CamMtx = Matrix4.Identity;
        public Matrix4 ProjMatrix;
        // movimentação da camera
        bool isShiftDown = false, isControlDown = false, isSpaceDown = false;
        bool isMouseDown = false, isMouseMove = false;
        bool isWDown = false, isSDown = false, isADown = false, isDDown = false;
        #endregion

        public Action<object, EventArgs> GlControlLoad;

        public RenderControl() 
        {
            glControl = new OpenTK.GLControl();
            glControl.Dock = DockStyle.Fill;
            glControl.Name = "glControl";
            glControl.TabIndex = 999;
            glControl.TabStop = false;
            glControl.Load += GlControl_Load;
            glControl.KeyDown += GlControl_KeyDown;
            glControl.KeyUp += GlControl_KeyUp;
            glControl.Leave += GlControl_Leave;
            glControl.MouseWheel += GlControl_MouseWheel;
            glControl.MouseMove += GlControl_MouseMove;
            glControl.MouseDown += GlControl_MouseDown;
            glControl.MouseUp += GlControl_MouseUp;
            glControl.MouseLeave += GlControl_MouseLeave;
            glControl.Resize += GlControl_Resize;

            myTimer.Tick += updateWASDControls;
            myTimer.Interval = 10;
            myTimer.Enabled = false;

            CamMtx = camera.GetViewMatrix();
            ProjMatrix = ReturnNewProjMatrix();
        }

        #region GlControl Events

        private Matrix4 ReturnNewProjMatrix()
        {
            return Matrix4.CreatePerspectiveFieldOfView(60 * ((float)Math.PI / 180.0f), (float)glControl.Width / (float)glControl.Height, 0.01f, 1000000f);
        }

        private void GlControl_Resize(object sender, EventArgs e)
        {
            glControl.Context.Update(glControl.WindowInfo);
            GL.Viewport(0, 0, glControl.Width, glControl.Height);
            ProjMatrix = ReturnNewProjMatrix();
            glControl.Invalidate();
        }

        private void GlControl_MouseLeave(object sender, EventArgs e)
        {
            camera.resetMouseStuff();
            isMouseDown = false;
            isMouseMove = false;
        }

        private void GlControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                camera.resetMouseStuff();
                isMouseDown = false;
                isMouseMove = false;
                camera.SaveCameraPosition();
                if (!isWDown && !isSDown && !isADown && !isDDown && !isMouseMove && !isShiftDown && !isSpaceDown)
                {
                    myTimer.Enabled = false;
                }
            }
        }

        private void GlControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                camera.resetMouseStuff();
                isMouseDown = true;
                isMouseMove = true;
                camera.SaveCameraPosition();
                myTimer.Enabled = true;
            }
        }


        private void GlControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown && e.Button == MouseButtons.Left)
            {
                camera.updateCameraOffsetMatrixWithMouse(isControlDown, e.X, e.Y);
                CamMtx = camera.GetViewMatrix();
            }
        }

        private void GlControl_MouseWheel(object sender, MouseEventArgs e)
        {
            camera.resetMouseStuff();
            camera.updateCameraMatrixWithScrollWheel((int)(e.Delta * 0.5f));
            CamMtx = camera.GetViewMatrix();
            camera.SaveCameraPosition();
            glControl.Invalidate();
        }

        private void GlControl_Leave(object sender, EventArgs e)
        {
            isWDown = false;
            isSDown = false;
            isADown = false;
            isDDown = false;
            isSpaceDown = false;
            isShiftDown = false;
            isControlDown = false;
            isMouseDown = false;
            isMouseMove = false;
            myTimer.Enabled = false;
        }

        private void GlControl_KeyUp(object sender, KeyEventArgs e)
        {
            isShiftDown = e.Shift;
            isControlDown = e.Control;
            switch (e.KeyCode)
            {
                case Keys.W: isWDown = false; break;
                case Keys.S: isSDown = false; break;
                case Keys.A: isADown = false; break;
                case Keys.D: isDDown = false; break;
                case Keys.Space: isSpaceDown = false; break;
            }
            if (!isWDown && !isSDown && !isADown && !isDDown && !isMouseMove && !isShiftDown && !isSpaceDown)
            {
                myTimer.Enabled = false;
            }
            if (isControlDown)
            {
                camera.SaveCameraPosition();
                camera.resetMouseStuff();
            }
        }

        private void GlControl_KeyDown(object sender, KeyEventArgs e)
        {
            isShiftDown = e.Shift;
            isControlDown = e.Control;
            switch (e.KeyCode)
            {
                case Keys.W:
                    isWDown = true;
                    myTimer.Enabled = true;
                    break;
                case Keys.S:
                    isSDown = true;
                    myTimer.Enabled = true;
                    break;
                case Keys.A:
                    isADown = true;
                    myTimer.Enabled = true;
                    break;
                case Keys.D:
                    isDDown = true;
                    myTimer.Enabled = true;
                    break;
                case Keys.Space:
                    isSpaceDown = true;
                    myTimer.Enabled = true;
                    break;
            }
            if (isShiftDown)
            {
                myTimer.Enabled = true;
            }
            if (isControlDown)
            {
                camera.SaveCameraPosition();
                camera.resetMouseStuff();
            }

        }

        /// <summary>
        /// Atualiza a movimentação de wasd, e cria os "frames" da renderização.
        /// </summary>
        private void updateWASDControls(object sender, EventArgs e)
        {
            if (!isControlDown && camera.CamMode == Camera.CameraMode.FLY)
            {
                if (isWDown)
                {
                    camera.updateCameraToFront();
                }
                if (isSDown)
                {
                    camera.updateCameraToBack();
                }
                if (isDDown)
                {
                    camera.updateCameraToRight();
                }
                if (isADown)
                {
                    camera.updateCameraToLeft();
                }

                if (isShiftDown)
                {
                    camera.updateCameraToDown();
                }

                if (isSpaceDown)
                {
                    camera.updateCameraToUp();
                }

                if (isWDown || isSDown || isDDown || isADown || isShiftDown || isSpaceDown || isMouseMove)
                {
                    CamMtx = camera.GetViewMatrix();
                    glControl.Invalidate();
                }

            }
            else
            {
                glControl.Invalidate();
            }
        }

        private void GlControl_Load(object sender, EventArgs e)
        {
            GL.Viewport(0, 0, glControl.Width, glControl.Height);
            GlControlLoad?.Invoke(sender, e);
            glControl.SwapBuffers();
        }

        #endregion

    }
}
