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
using static System.Windows.Forms.DataVisualization.Charting.Chart;

namespace PCA_RGB
{
    public partial class Form1 : Form
    {
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
            byte[] image1Bytes = image1.ToRgbArray();

            double[][] image1Data =  image1Bytes.ToDoubleArray(3);

            if (image2.Image == null) return image1Data;

            byte[] image2Bytes = image2.ToRgbArray();

            double[][] image2Data = image2Bytes.ToDoubleArray(3);

            return ConcatRGBs(image1Data, image2Data);
        }

        private void LoadImage1_Click(object sender, EventArgs e)
        {
            UploadImage(image1);
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
