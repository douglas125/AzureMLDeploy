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
            string imgBase64 = bmp2base64(bmp);

            string content = "{'payload': '" + imgBase64 + "'}";
            var response = await client.PostAsync(txtPredictEndpoint.Text, new StringContent(content, Encoding.UTF8, "application/json"));
            var responseString = await response.Content.ReadAsStringAsync();

            gbImgUpload.Text = "task id:"+ responseString;

            btnGetResults.Enabled = true;
        }

        #region Deal with images
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
        #endregion

        /// <summary>Label names, same convention as segmentation model</summary>
        List<string> label_names = new List<string>() {"background", "aeroplane", "bicycle", "bird", "boat", "bottle", "bus",
                                                        "car", "cat", "chair", "cow", "diningtable", "dog", "horse", "motorbike",
                                                        "person", "pottedplant", "sheep", "sofa", "train", "tv" };
        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
