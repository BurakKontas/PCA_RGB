using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using PCA_RGB.Adapters;
using ScottPlot;
using static System.Windows.Forms.DataVisualization.Charting.Chart;
using Image = System.Drawing.Image;

namespace PCA_RGB
{
    public partial class Form1 : Form
    {
        private bool IsDrawing = false;
        private Point startPoint;
        private Rectangle rect;
        private float X_Scale = 1;
        private float Y_Scale = 1;

        public Form1()
        {
            InitializeComponent();
        }

        private void PCA_Button_Click(object sender, EventArgs e)
        {
            double[][] rgbData = GetRgbData();

            PCA pca = new PCA(rgbData, 2);

            double[][] transformedData = pca.DoPCA();

            ChartForm chartForm = new ChartForm(transformedData);
            chartForm.Show();
        }

        private double[][] GetRgbData()
        {
            //byte[] image1Bytes = image1.ToRgbArray();

            //double[][] image1Data =  image1Bytes.ToDoubleArray(3);

            //if (image2.Image == null) return image1Data;

            byte[] image2Bytes = image2.ToRgbArray();

            double[][] image2Data = image2Bytes.ToDoubleArray(3);

            return image2Data;

            //return ConcatRGBs(image1Data, image2Data);
        }

        private void ImageMouseDown(object sender, MouseEventArgs e)
        {
            if (image1.Image == null) return;

            IsDrawing = true;
            startPoint = e.Location;
        }

        private void ImageMouseMove(object sender, MouseEventArgs e)
        {
            if (IsDrawing)
            {
                int width = Math.Abs(e.X - startPoint.X);
                int height = Math.Abs(e.Y - startPoint.Y);
                int x = Math.Min(e.X, startPoint.X);
                int y = Math.Min(e.Y, startPoint.Y);
                rect = new Rectangle(x, y, width, height);
                image1.Invalidate();
            }
        }

        private void ImageMouseUp(object sender, MouseEventArgs e)
        {
            IsDrawing = false;

            var croppedImage = CropImage(image1, rect);

            if(croppedImage == null) return;

            image2.Image = croppedImage;
            image2.Size = croppedImage.Size;

        }

        private void ImagePaint(object sender, PaintEventArgs e)
        {
            if (rect != null && rect.Width > 0 && rect.Height > 0)
            {
                e.Graphics.DrawRectangle(Pens.Red, rect);
            }
        }

        private Bitmap CropImage(PictureBox pictureBox, Rectangle cropRect)
        {
            if (pictureBox.Image == null || cropRect.Width <= 0 || cropRect.Height <= 0)
                return null;

            int scaledX = (int)(cropRect.X * X_Scale);
            int scaledY = (int)(cropRect.Y * Y_Scale);
            int scaledWidth = (int)(cropRect.Width * X_Scale);
            int scaledHeight = (int)(cropRect.Height * Y_Scale);

            Rectangle scaledRect = new Rectangle(scaledX, scaledY, scaledWidth, scaledHeight);

            Bitmap sourceBitmap = new Bitmap(pictureBox.Image);
            Bitmap croppedBitmap = new Bitmap(scaledRect.Width, scaledRect.Height);

            using (Graphics g = Graphics.FromImage(croppedBitmap))
            {
                g.DrawImage(sourceBitmap, new Rectangle(0, 0, croppedBitmap.Width, croppedBitmap.Height),
                    scaledRect,
                    GraphicsUnit.Pixel);
            }

            return croppedBitmap;
        }

        private void LoadImage1_Click(object sender, EventArgs e)
        {
            UploadImage(image1);
            image1.Size = image1.Image.Size;
        }

        private void LoadImage2_Click(object sender, EventArgs e)
        {
            UploadImage(image2);
        }

        private void UploadImage(PictureBox pictureBox, bool resizeBox = false)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image files (*.jpg, *.jpeg, *.png, *.gif, *.bmp)|*.jpg; *.jpeg; *.png; *.gif; *.bmp|All files (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true
            };

            if (openFileDialog.ShowDialog() != DialogResult.OK) return;

            try
            {
                var selectedFile = openFileDialog.FileName;

                pictureBox.Image = Image.FromFile(selectedFile);

                if (resizeBox) pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Resim yüklenirken bir hata oluştu: " + ex.Message);
            }
        }

        private double[][] ConcatRGBs(params double[][][] dataSets)
        {
            int rowCount = dataSets[0].Length;
            int totalColumns = dataSets.Length * 3;

            double[][] result = new double[rowCount][];

            for (int i = 0; i < rowCount; i++)
            {
                result[i] = new double[totalColumns];
                for (int j = 0; j < dataSets.Length; j++)
                {
                    result[i][j * 3] = dataSets[j][i][0];
                    result[i][j * 3 + 1] = dataSets[j][i][1];
                    result[i][j * 3 + 2] = dataSets[j][i][2];
                }
            }

            return result;
        }
    }
}
