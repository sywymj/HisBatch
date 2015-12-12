using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Camera_NET;
using DirectShowLib;

namespace HisPatch
{
    public partial class FormCamera : Form
    {
        public FormCamera()
        {
            InitializeComponent();
        }

        private NormalizedRect _MouseSelectionRect = new NormalizedRect(0, 0, 0, 0);
        private bool _bDrawMouseSelection = false;

        // Zooming
        private bool _bZoomed = false;
        private double _fZoomValue = 1.0;

        // Camera choice
        private CameraChoice _CameraChoice = new CameraChoice();
        public bool IsHide = true;
        private void FormCamera_Load(object sender, EventArgs e)
        {
            FillCameraList();

            // Select the first one
            if (toolStripComboBoxCamera.Items.Count > 0)
            {
                toolStripComboBoxCamera.SelectedIndex = 0;
            }

            // Fill camera list combobox with available resolutions
            FillResolutionList();
        }
        private void FillResolutionList()
        {
            toolStripComboBoxResultion.Items.Clear();

            if (!cameraControl.CameraCreated)
                return;

            ResolutionList resolutions = Camera.GetResolutionList(cameraControl.Moniker);

            if (resolutions == null)
                return;


            int index_to_select = -1;

            for (int index = 0; index < resolutions.Count; index++)
            {
                toolStripComboBoxResultion.Items.Add(resolutions[index].ToString());

                if (resolutions[index].CompareTo(cameraControl.Resolution) == 0)
                {
                    index_to_select = index;
                }
            }

            // select current resolution
            if (index_to_select >= 0)
            {
                toolStripComboBoxResultion.SelectedIndex = index_to_select;
            }
        }

        private void FillCameraList()
        {
            toolStripComboBoxCamera.Items.Clear();

            _CameraChoice.UpdateDeviceList();

            foreach (var camera_device in _CameraChoice.Devices)
            {
                toolStripComboBoxCamera.Items.Add(camera_device.Name);
            }
        }

        private void FormCamera_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                cameraControl.CloseCamera();
            }
            catch (System.Exception )
            {}
        }

        private void toolStripComboBoxCamera_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (toolStripComboBoxCamera.SelectedIndex < 0)
            {
                cameraControl.CloseCamera();
            }
            else
            {
                // Set camera
                cameraControl.SetCamera(_CameraChoice.Devices[toolStripComboBoxCamera.SelectedIndex].Mon, null);
                //SetCamera(_CameraChoice.Devices[ comboBoxCameraList.SelectedIndex ].Mon, null);
            }

            FillResolutionList();
        }

        private void toolStripComboBoxResultion_SelectedIndexChanged(object sender, EventArgs e)
        {
             if (!cameraControl.CameraCreated)
                return;

            int comboBoxResolutionIndex = toolStripComboBoxResultion.SelectedIndex;
            if (comboBoxResolutionIndex < 0)
            {
                return;
            }
            ResolutionList resolutions = Camera.GetResolutionList(cameraControl.Moniker);

            if ( resolutions == null )
                return; 

            if ( comboBoxResolutionIndex >= resolutions.Count )
                return; // throw

            if (0 == resolutions[comboBoxResolutionIndex].CompareTo(cameraControl.Resolution))
            {
                // this resolution is already selected
                return;
            }

            // Recreate camera
            //SetCamera(_Camera.Moniker, resolutions[comboBoxResolutionIndex]);
            cameraControl.SetCamera(cameraControl.Moniker, resolutions[comboBoxResolutionIndex]);
        }

        private void toolStripButtonSnapshot_Click(object sender, EventArgs e)
        {
            if (!cameraControl.CameraCreated)
                return;

            Bitmap bitmap = null;
            try
            {
                bitmap = cameraControl.SnapshotSourceImage();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Error while getting a snapshot");
            }

            if (bitmap == null)
                return;
            GSetting.Avatar = bitmap;
            this.DialogResult = DialogResult.OK;
        }

        private void toolStripButtonCamSet_Click(object sender, EventArgs e)
        {
            if (cameraControl.CameraCreated)
            {
                Camera.DisplayPropertyPage_Device(cameraControl.Moniker, this.Handle);
            }
        }

        private void FormCamera_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
