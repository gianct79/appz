/*
* Copyleft 1979-2015 GTO Inc. All rights reversed.
*/

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Threading;
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

            Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");

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

                        pageSettings.PaperSize = new PaperSize("Custom", 850, 1200);
                        //pageSettings.Margins = new Margins(0, 0, 0, 0);

                        //printDocument.OriginAtMargins = true;
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
            e.Graphics.PageUnit = GraphicsUnit.Millimeter;

            int x = (int)(-e.PageSettings.HardMarginX / 2.0f);
            //int y = (int)(-e.PageSettings.HardMarginY / 2.0f);
            int y = -4;

            int i = 0;
            while (i < 4)
            {
                Image check = DrawCheck(this.checkbook[i], e.Graphics.DpiX, e.Graphics.DpiY);
                e.Graphics.DrawImage(check, x, y);

                y += 79;
                i += 1;
            }

            e.HasMorePages = false;
        }

        private Image DrawCheck(Check check, float dpiX, float dpiY)
        {
            Bitmap bitmap = new Bitmap((int)(8.5f * dpiX), (int)(12.0f * dpiY));
            bitmap.SetResolution(dpiX, dpiY);

            FontFamily fontFamily = new FontFamily("Arial");
            using (Font font = new Font(fontFamily, 4.0f, FontStyle.Regular, GraphicsUnit.Millimeter))
            {
                Graphics g = Graphics.FromImage(bitmap);

                g.PageUnit = GraphicsUnit.Millimeter;

                g.DrawString(String.Format("*** {0} ***", check.Value.ToString("N2")), font, Brushes.Black, 172, 4);

                g.DrawString(check.Date.ToShortDateString(), font, Brushes.Black, 16, 12);
                g.DrawString(String.Format("              *** {0} ***", check.Value.ToLongString()), font, Brushes.Black, new Rectangle(52, 12, 140, 12));
                g.DrawString(String.Format("  {0}", check.PayTo), font, Brushes.Black, new Rectangle(16, 28, 28, 16));

                g.DrawString(check.Value.ToString("C"), font, Brushes.Black, 16, 20);
                g.DrawString(check.PayTo, font, Brushes.Black, 54, 24);

                g.DrawString(check.Place, font, Brushes.Black, new Rectangle(72, 32, 80, 4), new StringFormat { Alignment = StringAlignment.Far });
                g.DrawString(check.Date.ToString("dd"), font, Brushes.Black, 160, 32);

                g.DrawString(check.Date.ToString("MMMM"), font, Brushes.Black, new Rectangle(170, 32, 30, 4), new StringFormat { Alignment = StringAlignment.Center });
                g.DrawString(check.Date.ToString("yy"), font, Brushes.Black, 208, 32);
            }

            return bitmap;
        }
    }
}
