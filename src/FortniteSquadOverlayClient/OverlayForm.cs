using System;
using System.Drawing;
using System.Windows.Forms;

namespace FortniteSquadOverlayClient
{
    public partial class OverlayForm : Form
    {
        public OverlayForm()
        {
            InitializeComponent();
        }

        // ****************************************************************************************************
        // HELPER METHODS
        // ****************************************************************************************************
        public Image GetDebugOverlay()
        {
            return debugPictureBox.Image;
        }

        public void SetDebugOverlay(Bitmap bmp)
        {
            SetControlProperty(debugPictureBox, "Image", bmp);
        }

        public void SetSquadGear(int index, Bitmap bmp)
        {
            switch (index)
            {
                case 0:
                    SetControlProperty(squadmateGearPictureBox1, "Image", bmp);
                    break;
                case 1:
                    SetControlProperty(squadmateGearPictureBox2, "Image", bmp);
                    break;
                case 2:
                    SetControlProperty(squadmateGearPictureBox3, "Image", bmp);
                    break;
                default:
                    throw new Exception("Invalid index in SetSquadGear");
            }
        }

        public void SetOverlayOpacity(int opacity)
        {
            double dec = (double)opacity / 100;
            Opacity = dec;
        }
        
        public void SetHudScale(float scale)
        {
            SetImagePositions(this.Width, this.Height, scale);
        }

        public static void SetControlProperty(Control control, string propertyName, object data)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new MethodInvoker(delegate { control.GetType().GetProperty(propertyName).SetValue(control, data); }));
            }
            else
            {
                control.GetType().GetProperty(propertyName).SetValue(control, data);
            }
        }

        private void SetImagePositions(int width, int height, float scale)
        {
            var imageWidth  = (int)(width  * 0.12500000000 * scale);
            var imageHeight = (int)(height * 0.05555555555 * scale);
            var imageX      = (int)(width  * 0.16796875000 * scale);
            var imageY      = (int)(height * 0.08333333333 * scale);
            
            var imageSize = new System.Drawing.Size(imageWidth, imageHeight);

            squadmateGearPictureBox1.Size     = imageSize;
            squadmateGearPictureBox1.Location = new Point(imageX, imageY);
            squadmateGearPictureBox2.Size     = imageSize;
            squadmateGearPictureBox2.Location = new Point(imageX, imageY + imageHeight);
            squadmateGearPictureBox3.Size     = imageSize;
            squadmateGearPictureBox3.Location = new Point(imageX, imageY + (imageHeight * 2));
        }

        // ****************************************************************************************************
        // CONTROL EVENT HANDLERS
        // ****************************************************************************************************
        private void OverlayForm_Resize(object sender, EventArgs e)
        {
            var form       = (OverlayForm)sender;
            var width  = form.Size.Width;
            var height = form.Size.Height;
            var scale = (float)(Program.Config?.HudScale ?? 100) / 100;
            
            SetImagePositions(width, height, scale);
        }
    }
}
