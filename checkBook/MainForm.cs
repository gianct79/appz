/*
* Copyleft 1979-2015 GTO Inc. All rights reversed.
*/

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace checkBook
{
    public partial class MainForm : Form
    {
        private Checkbook checkbook;

        public MainForm()
        {
            InitializeComponent();
            this.checkbook = new Checkbook();
            this.checkbookBindingSource.DataSource = this.checkbook;
        }

        private void fileExitMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fileOpenMenu_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            using (FileDialog openDialog = new OpenFileDialog())
            {
                openDialog.Filter = "XML Files (*.xml)|*.xml";
                if (openDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var xml = new XmlSerializer(typeof(Checkbook));
                        using (StreamReader sr = File.OpenText(openDialog.FileName))
                        {
                            this.checkbook = (Checkbook)xml.Deserialize(sr);

                            this.checkbookBindingSource.DataSource = null;
                            this.checkbookBindingSource.DataSource = this.checkbook;
                        }
                    }
                    catch (Exception ex)
                    {
                        this.statusLabel.Text = ex.Message;
                    }
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void fileSaveMenu_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            using (FileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "XML Files (*.xml)|*.xml";
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var xml = new XmlSerializer(typeof(Checkbook));
                        using (StreamWriter sw = File.CreateText(saveDialog.FileName))
                        {
                            xml.Serialize(sw, this.checkbook);
                        }
                    }
                    catch (Exception ex)
                    {
                        this.statusLabel.Text = ex.Message;
                    }
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void checkGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            this.statusLabel.Text = e.Exception.Message;
        }

        private void checkbookBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            Decimal sum = Decimal.Zero;
            foreach (Check check in this.checkbook)
            {
                sum += check.Value;
            }
            this.statusLabel.Text = String.Format("Total {0:C}: {1}.", sum, sum.ToLongString());
        }

        private void filePrintMenu_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            using (PrintDialog printDialog = new PrintDialog())
            {
                printDialog.UseEXDialog = true; // 64-bit issue?

                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    using (PrintDocument printDocument = new PrintDocument())
                    {
                        printDocument.PrinterSettings = printDialog.PrinterSettings;

                        PageSettings pageSettings = new PageSettings(printDocument.PrinterSettings);

                        pageSettings.Margins.Top = 0;
                        pageSettings.Margins.Bottom = 0;
                        pageSettings.Margins.Left = 0;
                        pageSettings.Margins.Right = 0;

                        printDocument.OriginAtMargins = true;
                        printDocument.DefaultPageSettings = pageSettings;

                        printDocument.PrintPage += new PrintPageEventHandler(printDocument_PrintPage);
                        printDocument.Print();
                    }
                }
            }

            Cursor.Current = Cursors.Default;
        }

        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {

            //int srcX = e.MarginBounds.X;
            //int srcY = e.MarginBounds.Y;

            //int srcWidth = this.imageViewer.Image.Width - srcX;
            //int srcHeight = this.imageViewer.Image.Height - srcY;

            //e.Graphics.DrawImage(this.imageViewer.Image, e.MarginBounds, srcX, srcY, srcWidth, srcHeight, GraphicsUnit.Pixel);

            e.HasMorePages = false;
        }

        private void CreateBitmap(string text, int width, int height, int resX, int resY)
        {
            int resX4 = resX / 4;
            int resY4 = resY / 4;

            Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            bitmap.SetResolution(resX, resY);

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.FillRectangle(Brushes.White, 0, 0, width, height);

                int centerV = width / 2;
                int centerH = height / 2;

                for (int x = centerV; x > 0; x -= resX4)
                    g.DrawLine(Pens.Black, x, 0, x, height);

                for (int x = centerV + resX4; x < width; x += resX4)
                    g.DrawLine(Pens.Black, x, 0, x, height);

                for (int y = centerH; y > 0; y -= resY4)
                    g.DrawLine(Pens.Black, 0, y, width, y);

                for (int y = centerH + resY4; y < height; y += resY4)
                    g.DrawLine(Pens.Black, 0, y, width, y);

                g.DrawLine(Pens.Gray, 0, 0, width, height);
                g.DrawLine(Pens.Gray, width, 0, 0, height);

                g.DrawEllipse(Pens.Black, centerV - resX, centerH - resY, resX * 2, resY * 2);

                FontFamily fontFamily = new FontFamily("Arial");
                using (Font font = new Font(fontFamily, resX * 0.16f, FontStyle.Regular, GraphicsUnit.Pixel))
                {
                    g.DrawString(text, font, Brushes.Black, centerV - resX * 2, centerH - resY);
                }

                using (Image ruler = CreateRuler(resX, resY))
                {
                    ruler.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    g.DrawImage(ruler, width / 2, 0);

                    ruler.RotateFlip(RotateFlipType.Rotate90FlipXY);
                    g.DrawImage(ruler, 0, height / 2);

                    ruler.RotateFlip(RotateFlipType.Rotate90FlipXY);
                    g.DrawImage(ruler, width / 2, height - ruler.Height);

                    ruler.RotateFlip(RotateFlipType.Rotate90FlipXY);
                    g.DrawImage(ruler, width - ruler.Width, height / 2);
                }
            }
        }

        private Image CreateRuler(int resX, int resY)
        {
            Bitmap ruler = new Bitmap(resX * 3, resY / 4);
            ruler.SetResolution(resX, resY);

            FontFamily fontFamily = new FontFamily("Arial");
            using (Font font = new Font(fontFamily, resX * 0.08f, FontStyle.Regular, GraphicsUnit.Pixel))
            {
                Graphics g = Graphics.FromImage(ruler);

                g.FillRectangle(Brushes.LightGray, 0, 0, ruler.Width, ruler.Height);

                int x1, x2, y1, y2;
                x1 = 0; x2 = ruler.Width; y1 = y2 = ruler.Height / 2;

                g.DrawLine(Pens.Black, x1, y1, x2, y2);
                g.DrawString("<<< To paper edge <<<", font, Brushes.Black, x1, y1 - resY * 0.12f);

                int resX2 = resX / 2;
                int resX4 = resX / 4;

                for (int x = x1; x < x2; x++)
                {
                    if (x % resX4 == 0)
                        g.DrawLine(Pens.Black, x, y1 - resY * 0.02f, x, y1 + resY * 0.02f);
                    if (x % resX2 == 0)
                        g.DrawLine(Pens.Black, x, y1 - resY * 0.04f, x, y1 + resY * 0.04f);
                    if (x % resX == 0)
                    {
                        g.DrawLine(Pens.Black, x, y1 - resY * 0.08f, x, y1 + resY * 0.08f);
                        g.DrawString((x / resX).ToString(), font, Brushes.Black, x, y1);
                    }
                }
            }
            return ruler;
        }
    }
}
