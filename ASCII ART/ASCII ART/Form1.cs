using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASCII_ART
{
    public partial class Form1 : Form
    {

        

        public Form1()
        {
            InitializeComponent();
        }

        private static string[] _AsciiChars = { "#", "#", "@", "%", "=", "+", "*", ":", "-", ".", " " };

        public void button1_Click(object sender, EventArgs e)
        {

            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = opf.FileName;
                //pictureBox1.Image = new Bitmap(opf.FileName);
                pictureBox1.Image = Image.FromFile(opf.FileName);
                this.pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;

                
            }
            
            var GraphicsImage = (Bitmap)Image.FromFile(opf.FileName);
            var ascii = ConvertToAscii(GraphicsImage);
            var convert = ascii.Replace("data:image/png;base64,", "");
            File.WriteAllText(@"test.txt", convert);
            

            var urString = convert;
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(urString));
            textBox2.Text = urString;
            //var xyz = byteArrayToImage(stream);
            //var bitmap = new Bitmap(stream);
            //pictureBox2.Image = bitmap;

        }

        public Image stringToImage(string inputString)
        {
            byte[] NewBytes = Convert.FromBase64String(inputString);
            MemoryStream ms1 = new MemoryStream(NewBytes);
            Image NewImage = Image.FromStream(ms1);

            return NewImage;
        }

        private string ConvertToAscii(Bitmap image)

        {

            Boolean toggle = false;

            StringBuilder sb = new StringBuilder();



            for (int h = 0; h < image.Height/10; h++) 

            {

                for (int w = 0; w < image.Width; w++) 

                {

                    Color pixelColor = image.GetPixel(w, h);

                    int red = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;

                    int green = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;

                    int blue = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;

                    Color grayColor = Color.FromArgb(red, green, blue);


                    if (!toggle)

                    {

                        int index = (grayColor.R * 10) / 255;

                        sb.Append(_AsciiChars[index]);

                    }

                }



                if (!toggle)

                {

                    sb.Append(Environment.NewLine);

                    toggle = true;

                }

                else

                {

                    toggle = false;

                }

            }

            return sb.ToString();

        }

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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void button2_Click(object sender, EventArgs e)
        {


        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
