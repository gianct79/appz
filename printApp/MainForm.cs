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
                CreateBitmap(2481, 3507, 300, 300);
            }
            else if (selectedMenu.Equals(editCreateBitmapA4600Menu))
            {
            }
            else if (selectedMenu.Equals(editCreateBitmapLetter300Menu))
            {
            }
            else
            {
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

        private void CreateBitmap(int width, int height, float resX, float resY)
        {
            int colWidth = width / 100;
            int rowHeight = height / 100;

            Bitmap checks = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            checks.SetResolution(resX, resY);

            for (int columns = 0; columns < 100; columns++)
            {
                for (int rows = 0; rows < 100; rows++)
                {
                    Color color;
                    if (columns % 2 == 0)
                        color = rows % 2 == 0 ? Color.Black : Color.White;
                    else
                        color = rows % 2 == 0 ? Color.White : Color.Black;

                    for (int j = columns * colWidth; j < (columns * colWidth) + colWidth; j++)
                    {
                        for (int k = rows * rowHeight; k < (rows * rowHeight) + rowHeight; k++)
                        {
                            checks.SetPixel(j, k, color);
                        }
                    }
                    this.imageViewer.Image = checks;
                }
            }
        }
    }
}
