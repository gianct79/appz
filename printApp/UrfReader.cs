/*
* Copyleft 1979-2013 GTO Inc. All rights reversed.
*/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;

namespace printApp
{
    public class UrfDocument : IDisposable
    {
        private static readonly byte[] URF_HEADER = Encoding.ASCII.GetBytes("UNIRAST\0");

        private FileStream fileStream;
        private List<UrfPage> pages;
        private int currentPage;

        public int PageCount { get { return pages.Count; } }
        public int CurrentPage { get { return currentPage; } }

        public int PrevPage()
        {
            if (currentPage > 1)
                currentPage--;

            return currentPage;
        }

        public int NextPage()
        {
            if (currentPage < PageCount)
                currentPage++;

            return currentPage;
        }

        public Bitmap CreateBitmap()
        {
            UrfPage page = pages[currentPage - 1];

            Bitmap bitmap = new Bitmap(page.Header.Width, page.Header.Height, PixelFormat.Format24bppRgb);
            bitmap.SetResolution(page.Header.Resolution, page.Header.Resolution);

            int bytesPerPixel = page.Header.BitsPerPixel / 8;

            BinaryReader reader = new BinaryReader(this.fileStream);
            reader.BaseStream.Seek(page.StreamStart, SeekOrigin.Begin);

            int lineCount = 0;
            while (lineCount < page.Header.Height && reader.BaseStream.Position < reader.BaseStream.Length)
            {
                int lineRepeat = reader.ReadByte() + 1;

                int linePixelsCount = 0;
                Color[] linePixels = new Color[page.Header.Width];

                while (linePixelsCount < page.Header.Width)
                {
                    int pixelRepeat = reader.ReadByte();
                    Color pixel = Color.White;

                    if (pixelRepeat == 128)
                    {
                        // the rest of the line should be white
                        pixelRepeat = page.Header.Width - linePixelsCount;
                    }
                    else if (pixelRepeat > 128)
                    {
                        // number of non repeating pixels
                        int nonRepeatingPixels = 257 - pixelRepeat;
                        pixelRepeat = 0;

                        for (int i = 0; i < nonRepeatingPixels; i++)
                        {
                            linePixels[linePixelsCount++] = ReadPixel(reader, page.Header, bytesPerPixel);
                        }
                    }
                    else
                    {
                        // read one pixel and repeat that
                        pixel = ReadPixel(reader, page.Header, bytesPerPixel);
                        // Increasing the pixel repeat counter by one since the repeat counter is -1
                        pixelRepeat++;
                    }

                    // repeating pixels in a line
                    for (int i = 0; i < pixelRepeat; i++)
                    {
                        linePixels[linePixelsCount++] = pixel;
                    }
                }

                if (linePixelsCount > page.Header.Width)
                {
                    throw new Exception("Error Parsing document, line is bigger than expected.");
                }

                // write line to the raster output, repeating lines
                for (int y = 0; y < lineRepeat; y++)
                {
                    for (int x = 0; x < linePixels.Length; x++)
                        bitmap.SetPixel(x, lineCount, linePixels[x]);

                    lineCount++;
                }
            }

            return bitmap;
        }

        private Color ReadPixel(BinaryReader reader, UrfHeader header, int bytesPerPixel)
        {
            switch (header.ColorSpace)
            {
                case RasterColorSpace.Luminance:
                    return ReadGrayscalePixel(reader, bytesPerPixel);
                case RasterColorSpace.sRGB:
                    return ReadRgbPixel(reader, bytesPerPixel);
                default:
                    throw new Exception("This color scheme is not currently suported. (" + header.ColorSpace.ToString() + ")");
            }
        }

        private Color ReadRgbPixel(BinaryReader reader, int bytesPerPixel)
        {
            Color pixel = Color.FromArgb(reader.ReadByte(), reader.ReadByte(), reader.ReadByte());

            return pixel;
        }

        private Color ReadGrayscalePixel(BinaryReader reader, int bytesPerPixel)
        {
            Color pixel;

            if (bytesPerPixel == 1)
            {
                byte b = reader.ReadByte();
                pixel = Color.FromArgb(b, b, b);
            }
            else if (bytesPerPixel == 2)
            {
                short b = reader.ReadShort();
                pixel = Color.FromArgb(b, b, b);
            }
            else
            {
                throw new Exception("Invalid number of bytes per color. (" + bytesPerPixel + ")");
            }

            return pixel;
        }

        public UrfDocument(string filePath)
        {
            this.fileStream = File.OpenRead(filePath);
            this.currentPage = 1;

            BinaryReader reader = new BinaryReader(this.fileStream);
            byte[] header = new byte[8];
            header = reader.ReadBytes(header.Length);

            if (!URF_HEADER.SequenceEqual(header))
            {
                throw new ArgumentException(string.Format("Cannot render {0}: it is not a supported format", filePath));
            }

            int pageCount = reader.ReadInt();
            this.pages = new List<UrfPage>(pageCount);

            while (reader.BaseStream.Position < reader.BaseStream.Length)
            {
                UrfPage currentPage = new UrfPage();

                currentPage.Header = new UrfHeader(reader);
                currentPage.StreamStart = reader.BaseStream.Position;

                int bytesPerPixel = currentPage.Header.BitsPerPixel / 8;

                int lineCount = 0;
                while (lineCount < currentPage.Header.Height && reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    int lineRepeat = reader.ReadByte() + 1;

                    int linePixelsCount = 0;
                    while (linePixelsCount < currentPage.Header.Width)
                    {
                        int pixelRepeat = reader.ReadByte();

                        if (pixelRepeat == 128)
                        {
                            // rest of the line should be white
                            pixelRepeat = currentPage.Header.Width - linePixelsCount;
                        }
                        else if (pixelRepeat > 128)
                        {
                            // number of non repeating pixels
                            int nonRepeatingPixels = 257 - pixelRepeat;
                            pixelRepeat = 0;

                            for (int i = 0; i < nonRepeatingPixels; i++)
                            {
                                reader.BaseStream.Seek(bytesPerPixel, SeekOrigin.Current);
                                linePixelsCount++;
                            }
                        }
                        else
                        {
                            // read one pixel and repeat that
                            reader.BaseStream.Seek(bytesPerPixel, SeekOrigin.Current);
                            // increasing the pixel repeat counter by one since the repeat counter is -1
                            pixelRepeat++;
                        }

                        // repeating pixels in a line
                        linePixelsCount += pixelRepeat;
                    }

                    if (linePixelsCount > currentPage.Header.Width)
                    {
                        throw new Exception("Error Parsing document, line is bigger than expected");
                    }

                    lineCount += lineRepeat;
                }
                currentPage.StreamEnd = reader.BaseStream.Position;

                this.pages.Add(currentPage);
                for (int i = 1; i < currentPage.Header.Copies; i++)
                    this.pages.Add(currentPage);
            }
        }

        public void Dispose()
        {
            if (this.fileStream != null)
            {
                this.fileStream.Close();
                this.fileStream.Dispose();

                this.fileStream = null;
                GC.SuppressFinalize(this);
            }
        }

        public class UrfPage
        {
            public UrfHeader Header { get; set; }

            public long StreamStart { get; set; }
            public long StreamEnd { get; set; }
        }

        public class UrfHeader
        {
            public byte BitsPerPixel { get; set; }
            public RasterColorSpace ColorSpace { get; set; }
            public byte DuplexMode { get; set; }
            public byte PrintQuality { get; set; }

            public byte MediaType { get; set; }
            public byte InputSlot { get; set; }
            public byte OutputBin { get; set; }
            public byte Copies { get; set; }

            public int Finishings { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }
            public int Resolution { get; set; }

            public UrfHeader(BinaryReader reader)
            {
                this.BitsPerPixel = reader.ReadByte();
                this.ColorSpace = ParseColorSpace(reader.ReadByte());
                this.DuplexMode = reader.ReadByte();
                this.PrintQuality = reader.ReadByte();

                this.MediaType = reader.ReadByte();
                this.InputSlot = reader.ReadByte();
                this.OutputBin = reader.ReadByte();
                this.Copies = reader.ReadByte();

                this.Finishings = reader.ReadInt();
                this.Width = reader.ReadInt();
                this.Height = reader.ReadInt();
                this.Resolution = reader.ReadInt();

                // setting the position to the end of the page header
                reader.BaseStream.Seek(8, SeekOrigin.Current);
            }

            private RasterColorSpace ParseColorSpace(int colorspc)
            {
                int cs = colorspc & 0xff;

                switch (cs)
                {
                    case 0: // Luminance w/ gamma 2.2
                        return RasterColorSpace.Luminance;
                    case 1: // sRGB
                        return RasterColorSpace.sRGB;
                    case 3: // Adobe RGB
                        return RasterColorSpace.AdobeRGB;
                    case 4: // DeviceW
                        return RasterColorSpace.DeviceW;
                    case 5: // Device RGB
                        return RasterColorSpace.DeviceRGB;
                    case 6: // Device CMYK
                        return RasterColorSpace.DeviceCMYK;
                    default:
                        return RasterColorSpace.sRGB;
                }
            }
        }

        public enum RasterColorSpace
        {
            Luminance = 0,
            sRGB = 1,
            AdobeRGB = 3,
            DeviceW = 4,
            DeviceRGB = 5,
            DeviceCMYK = 6
        }
    }
}
