/*
* Copyleft 1979-2013 GTO Inc. All rights reversed.
*/

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using printApp.Properties;

namespace printApp
{
    public class ImageViewer : ScrollableControl
    {
        public ImageViewer()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            this.AutoScroll = true;
            this.Image = null;
            this.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            this.ZoomFactor = 1f;

            //if (texture == null)
            //{
            //texture = new TextureBrush(Resources.Texture);
            //texture.WrapMode = WrapMode.Tile;
            //}
        }

        private Image image;
        [Category("Appearance"), Description("The image to be displayed")]
        public Image Image
        {
            get { return image; }
            set
            {
                image = value;
                UpdateScaleFactor();
                Invalidate();
            }
        }

        private float zoomFactor = 1f;
        [Category("Appearance"), Description("The zoom factor. Less than 1 to reduce. More than 1 to magnify.")]
        public float ZoomFactor
        {
            get { return zoomFactor; }
            set
            {
                if (value < 0 || value < 1E-05)
                {
                    value = 1E-05f;
                }
                zoomFactor = value;
                UpdateScaleFactor();
                Invalidate();
            }
        }

        private void UpdateScaleFactor()
        {
            if (image == null)
            {
                this.AutoScrollMargin = this.Size;
            }
            else
            {
                this.AutoScrollMinSize = new Size(Convert.ToInt32(this.image.Width * zoomFactor), Convert.ToInt32(this.image.Height * zoomFactor));
            }
        }

        private InterpolationMode interpolationMode = InterpolationMode.High;
        [Category("Appearance"), Description("The interpolation mode used to smooth the drawing")]
        public InterpolationMode InterpolationMode
        {
            get { return interpolationMode; }
            set { interpolationMode = value; }
        }

        //private static TextureBrush texture;
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            //pevent.Graphics.FillRectangle(texture, 0, 0, this.Width, this.Height);
            pevent.Graphics.FillRectangle(Brushes.WhiteSmoke, pevent.ClipRectangle);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (image == null)
            {
                base.OnPaintBackground(e);
                return;
            }

            try
            {
                int H = image.Height;
            }
            catch (Exception)
            {
                base.OnPaintBackground(e);
                return;
            }

            Matrix mx = new Matrix(zoomFactor, 0, 0, zoomFactor, 0, 0);
            mx.Translate(this.AutoScrollPosition.X / zoomFactor, this.AutoScrollPosition.Y / zoomFactor);
            e.Graphics.Transform = mx;
            e.Graphics.InterpolationMode = interpolationMode;
            e.Graphics.DrawImage(image, new Rectangle(0, 0, this.image.Width, this.image.Height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel);
            base.OnPaint(e);
        }
    }
}
