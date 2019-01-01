using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AzureImageModelDeployExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Bitmap bmp;
        Bitmap mask;

        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images|*.bmp;*.png;*.jpg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                bmp = new Bitmap(ofd.FileName);
                bmp = ResizeImage(bmp, 512, 512); //we know that we want inference on this size

                picImg.Image = bmp;
                btnSendPredict.Enabled = true;
            }
        }

        private static readonly HttpClient client = new HttpClient();
        private async void btnSendPredict_Click(object sender, EventArgs e)
        {
            lbl_taskid.Text = "";
            string imgBase64 = bmp2base64(bmp);

            string content = "{'payload': '" + imgBase64 + "'}";
            var response = await client.PostAsync(txtPredictEndpoint.Text, new StringContent(content, Encoding.UTF8, "application/json"));
            var responseString = await response.Content.ReadAsStringAsync();

            lbl_taskid.Text = responseString;

            btnGetResults.Enabled = true;
        }


        private async void btnGetResults_Click(object sender, EventArgs e)
        {
            string content = "{'task_id': '" + lbl_taskid.Text + "'}";
            
            var response = await client.PostAsync(txtResultsendpoint.Text, new StringContent(content, Encoding.UTF8, "application/json"));
            var responseString = await response.Content.ReadAsStringAsync();

            if (responseString != "dGFza19pZCBub3QgZm91bmQh")
            {
                byte[] imageData = Convert.FromBase64String(responseString);
                using (var ms = new MemoryStream(imageData))
                {
                    mask = new Bitmap(ms);
                }

                drawMask();
            }
            else MessageBox.Show("Task result not found");
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            foreach(string s in label_names)
            {
                chkLayers.Items.Add(s);
            }
            for (int i = 0; i < chkLayers.Items.Count; i++) chkLayers.SetItemChecked(i, true);
            resetColors();
        }
        void resetColors()
        {
            label_colors.Clear();
            label_colors.Add(Color.Black);
            Random rnd = new Random(10);
            for (int i = 1; i < label_names.Count; i++)
            {
                Color c = Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255));
                label_colors.Add(c);
            }
        }

        private void chkLayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            drawMask();
        }

        private void chkOverlay_CheckedChanged(object sender, EventArgs e)
        {
            drawMask();
        }

        #region Deal with images
        /// <summary>Label names, same convention as segmentation model</summary>
        List<string> label_names = new List<string>() {"background", "aeroplane", "bicycle", "bird", "boat", "bottle", "bus",
                                                        "car", "cat", "chair", "cow", "diningtable", "dog", "horse", "motorbike",
                                                        "person", "pottedplant", "sheep", "sofa", "train", "tv" };
        List<Color> label_colors = new List<Color>();
        string bmp2base64(Bitmap bitmap)
        {
            using (var ms = new MemoryStream())
            {
                bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                string SigBase64 = Convert.ToBase64String(ms.GetBuffer()); //Get Base64
                return SigBase64;
            }
        }
        /// <summary>
        /// Resize the image to the specified width and height.
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="width">The width to resize to.</param>
        /// <param name="height">The height to resize to.</param>
        /// <returns>The resized image.</returns>
        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        //draw mask to image
        void drawMask()
        {
            if (mask == null) return;

            Bitmap maskdraw = new Bitmap(mask.Width, mask.Height);
            Graphics g = Graphics.FromImage(maskdraw);
            g.DrawImage(mask, 0, 0);
            int[,] classes = RemakeMask(maskdraw);
            pbMask.Image = maskdraw;

            if (bmp != null && chkOverlay.Checked)
            {
                Bitmap bmpover = (Bitmap)bmp.Clone();
                DrawOverlay(bmpover, classes);

                picImg.Image = bmpover;
            }
            else picImg.Image = bmp;
        }

        public int[,] RemakeMask(Bitmap processedBitmap)
        {
            int W = processedBitmap.Width;
            BitmapData bitmapData = processedBitmap.LockBits(new Rectangle(0, 0, processedBitmap.Width, processedBitmap.Height), ImageLockMode.ReadWrite, processedBitmap.PixelFormat);

            int[,] vals = new int[W, processedBitmap.Height];


            int bytesPerPixel = Bitmap.GetPixelFormatSize(processedBitmap.PixelFormat) / 8;
            int byteCount = bitmapData.Stride * processedBitmap.Height;
            byte[] pixels = new byte[byteCount];
            IntPtr ptrFirstPixel = bitmapData.Scan0;
            Marshal.Copy(ptrFirstPixel, pixels, 0, pixels.Length);
            int heightInPixels = bitmapData.Height;
            int widthInBytes = bitmapData.Width * bytesPerPixel;

            int xx, yy;
            yy = 0;

            for (int y = 0; y < heightInPixels; y++)
            {
                int currentLine = y * bitmapData.Stride;
                xx = 0;
                for (int x = 0; x < widthInBytes; x = x + bytesPerPixel)
                {
                    int oldBlue = pixels[currentLine + x];
                    int oldGreen = pixels[currentLine + x + 1];
                    int oldRed = pixels[currentLine + x + 2];

                    //replace with label_colors
                    byte  r = label_colors[oldBlue].R;
                    byte g = label_colors[oldBlue].G;
                    byte b = label_colors[oldBlue].B;

                    if (chkLayers.GetItemChecked(oldBlue))
                    {
                        pixels[currentLine + x] = b;
                        pixels[currentLine + x + 1] = g;
                        pixels[currentLine + x + 2] = r;
                        pixels[currentLine + x + 3] = 255;
                    }
                    else
                    {
                        pixels[currentLine + x] = 0;
                        pixels[currentLine + x + 1] = 0;
                        pixels[currentLine + x + 2] = 0;
                        pixels[currentLine + x + 3] = 255;
                    }
                    vals[xx, yy] = oldBlue;

                    xx++;
                }
                yy++;
            }

            // copy modified bytes back
            Marshal.Copy(pixels, 0, ptrFirstPixel, pixels.Length);
            processedBitmap.UnlockBits(bitmapData);

            return vals;
        }


        public void DrawOverlay(Bitmap processedBitmap, int[,] vals)
        {
            int W = processedBitmap.Width;
            BitmapData bitmapData = processedBitmap.LockBits(new Rectangle(0, 0, processedBitmap.Width, processedBitmap.Height), ImageLockMode.ReadWrite, processedBitmap.PixelFormat);

            int bytesPerPixel = Bitmap.GetPixelFormatSize(processedBitmap.PixelFormat) / 8;
            int byteCount = bitmapData.Stride * processedBitmap.Height;
            byte[] pixels = new byte[byteCount];
            IntPtr ptrFirstPixel = bitmapData.Scan0;
            Marshal.Copy(ptrFirstPixel, pixels, 0, pixels.Length);
            int heightInPixels = bitmapData.Height;
            int widthInBytes = bitmapData.Width * bytesPerPixel;

            int xx, yy;
            yy = 0;

            for (int y = 0; y < heightInPixels; y++)
            {
                int currentLine = y * bitmapData.Stride;
                xx = 0;
                for (int x = 0; x < widthInBytes; x = x + bytesPerPixel)
                {
                    int oldBlue = pixels[currentLine + x];
                    int oldGreen = pixels[currentLine + x + 1];
                    int oldRed = pixels[currentLine + x + 2];

                    //merge with label_colors
                    byte r = label_colors[vals[xx,yy]].R;
                    byte g = label_colors[vals[xx, yy]].G;
                    byte b = label_colors[vals[xx, yy]].B;

                    float maskIntens = 0.5f;
                    byte avg = (byte)(  (1-maskIntens) * (oldBlue + oldGreen + oldRed) / 3.0f);
                    r = (byte)(maskIntens * r);
                    g = (byte)(maskIntens * g);
                    b = (byte)(maskIntens * b);

                    if (chkLayers.GetItemChecked(vals[xx,yy]))
                    {
                        pixels[currentLine + x] = (byte)(avg + b);
                        pixels[currentLine + x + 1] = (byte)(avg + g);
                        pixels[currentLine + x + 2] = (byte)(avg + r);
                        pixels[currentLine + x + 3] = 255;
                    }
                    else
                    {
                        pixels[currentLine + x] = avg;
                        pixels[currentLine + x + 1] = avg;
                        pixels[currentLine + x + 2] = avg;
                        pixels[currentLine + x + 3] = 255;
                    }

                    xx++;
                }
                yy++;
            }

            // copy modified bytes back
            Marshal.Copy(pixels, 0, ptrFirstPixel, pixels.Length);
            processedBitmap.UnlockBits(bitmapData);
        }

        #endregion

        private void picImg_MouseMove(object sender, MouseEventArgs e)
        {
            if (bmp!=null && mask!=null)
            {
                Color c = mask.GetPixel(e.X, e.Y);
                gbImages.Text = label_names[c.R];
            }
        }
    }
}
