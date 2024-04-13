using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JADERLINK_MODEL_VIEWER.src.Forms
{
    public partial class FormCamera : Form
    {
        private RenderControl renderControl = null;
        private bool ControlChangedIsEneable = false;

        public Action<int> TrackBarCamSpeedValueIsChanged;

        public FormCamera(RenderControl renderControl, int lastTrackBarCamSpeedValue)
        {
            this.renderControl = renderControl;
            InitializeComponent();

            trackBarCamSpeed.MouseWheel += TrackBarCamSpeed_MouseWheel;

            float newvalue = getCamSpeed(lastTrackBarCamSpeedValue);
            trackBarCamSpeed.Value = lastTrackBarCamSpeedValue;
            setLabelCamSpeedPercentageText(newvalue);

            ControlChangedIsEneable = true;
        }

        private void updateGL()
        {
            renderControl.GlControl.Invalidate();
        }

        private void UpdateCameraMatrix()
        {
            renderControl.CamMtx = renderControl.Camera.GetViewMatrix();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void ResetCamera()
        {
            ControlChangedIsEneable = false;
            renderControl.Camera.ResetCameraToZero();
            ControlChangedIsEneable = true;
            UpdateCameraMatrix();
            updateGL();
        }

        private void buttonResetCam_Click(object sender, EventArgs e)
        {
            ResetCamera();
        }

        private void TrackBarCamSpeed_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
            if (e.X >= 0 && e.Y >= 0 && e.X < trackBarCamSpeed.Width && e.Y < trackBarCamSpeed.Height)
            {
                ((HandledMouseEventArgs)e).Handled = false;
            }
        }

        private void trackBarCamSpeed_Scroll(object sender, EventArgs e)
        {
            if (ControlChangedIsEneable)
            {
                float newValue = getCamSpeed(trackBarCamSpeed.Value);
                setLabelCamSpeedPercentageText(newValue);
                renderControl.Camera.CamSpeedMultiplier = newValue / 100.0f * 3.0f;
                TrackBarCamSpeedValueIsChanged?.Invoke(trackBarCamSpeed.Value);
            }
        }

        private void setLabelCamSpeedPercentageText(float newValue) 
        {
            labelCamSpeedPercentage.Text = "Cam speed: " + ((int)newValue).ToString().PadLeft(3) + "%";
        }

        private float getCamSpeed(int trackBarCamSpeedValue) 
        {
            float newValue;
            if (trackBarCamSpeedValue > 50)
            { newValue = 100.0f + ((trackBarCamSpeedValue - 50) * 8f); }
            else
            { newValue = (trackBarCamSpeedValue / 50.0f) * 100f; }
            if (newValue < 1f)
            { newValue = 1f; }
            else if (newValue > 96f && newValue < 114f)
            { newValue = 100f; }

            return newValue;
        }


        private void buttonGetPos_Click(object sender, EventArgs e)
        {
            floatBoxCamX.Value = renderControl.Camera.Position.X;
            floatBoxCamY.Value = renderControl.Camera.Position.Y;
            floatBoxCamZ.Value = renderControl.Camera.Position.Z;
            floatBoxPitch.Value = renderControl.Camera.PitchDegrees;
            floatBoxYaw.Value = renderControl.Camera.YawDegrees;
        }

        private void buttonSetPos_Click(object sender, EventArgs e)
        {
            renderControl.Camera.Position = new OpenTK.Vector3(floatBoxCamX.Value, floatBoxCamY.Value, floatBoxCamZ.Value);
            renderControl.Camera.YawDegrees = floatBoxYaw.Value;
            renderControl.Camera.PitchDegrees = floatBoxPitch.Value;
            UpdateCameraMatrix();
            updateGL();
        }
    }
}
