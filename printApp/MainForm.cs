/*
* Copyleft 1979-2013 GTO Inc. All rights reversed.
*/

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace printApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void fileExitMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editCreateBitmapMenu_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            ToolStripMenuItem selectedMenu = sender as ToolStripMenuItem;

            if (selectedMenu.Equals(editCreateBitmapA4300Menu))
            {
                CreateBitmap("A4 300 dpi", 2481, 3507, 300, 300);
            }
            else if (selectedMenu.Equals(editCreateBitmapA4600Menu))
            {
                CreateBitmap("A4 600 dpi", 4962, 7014, 600, 600);
            }
            else if (selectedMenu.Equals(editCreateBitmapLetter300Menu))
            {
                CreateBitmap("Letter 300 dpi", 2550, 3300, 300, 300);
            }
            else
            {
                CreateBitmap("Letter 600 dpi", 5100, 6600, 600, 600);
            }

            Cursor.Current = Cursors.Default;
        }

        private void viewZoomMenu_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            ToolStripMenuItem selectedMenu = sender as ToolStripMenuItem;

            if (selectedMenu.Equals(viewZoom25Menu))
            {
                this.imageViewer.ZoomFactor = 0.25f;
            }
            else if (selectedMenu.Equals(viewZoom50Menu))
            {
                this.imageViewer.ZoomFactor = 0.5f;
            }
            else if (selectedMenu.Equals(viewZoom75Menu))
            {
                this.imageViewer.ZoomFactor = 0.75f;
            }
            else
            {
                this.imageViewer.ZoomFactor = 1.0f;
            }

            Cursor.Current = Cursors.Default;
        }

        private void CreateBitmap(string text, int width, int height, int resX, int resY)
        {
            Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            bitmap.SetResolution(resX, resY);

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.FillRectangle(Brushes.White, 0, 0, width, height);

                int centerV = width / 2;
                int centerH = height / 2;

                for (int x = centerV; x > 0; x -= resX)
                    g.DrawLine(Pens.Black, x, 0, x, height);

                for (int x = centerV + resX; x < width; x += resX)
                    g.DrawLine(Pens.Black, x, 0, x, height);

                for (int y = centerH; y > 0; y -= resY)
                    g.DrawLine(Pens.Black, 0, y, width, y);

                for (int y = centerH + resY; y < height; y += resY)
                    g.DrawLine(Pens.Black, 0, y, width, y);

                g.DrawLine(Pens.Gray, 0, 0, width, height);
                g.DrawLine(Pens.Gray, width, 0, 0, height);

                g.DrawEllipse(Pens.Black, centerV - resX, centerH - resY, resX * 2, resY * 2);

                FontFamily fontFamily = new FontFamily("Arial");
                Font font = new Font(fontFamily, 48, FontStyle.Regular, GraphicsUnit.Pixel);

                g.DrawString(text, font, Brushes.Black, centerV - resX * 2, centerH - resY);
            }

            this.imageViewer.Image = bitmap;
        }
    }
}
