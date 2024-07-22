using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PCA_RGB
{
    public partial class ChartForm : Form
    {
        private Chart chart;

        public ChartForm(double[][] transformedData)
        {
            InitializeComponent();
            InitializeChart();
            PlotData(transformedData);
        }

        private void InitializeChart()
        {
            chart = new Chart
            {
                Dock = DockStyle.Fill
            };

            ChartArea chartArea = new ChartArea
            {
                Name = "PCAChartArea"
            };

            chart.ChartAreas.Add(chartArea);
            this.Controls.Add(chart);
            chart.Series.Clear();
            Series series = new Series
            {
                Name = "PCA",
                Color = Color.Blue,
                ChartType = SeriesChartType.Point
            };

            chart.Series.Add(series);
        }

        private void PlotData(double[][] transformedData)
        {
            Series series = chart.Series["PCA"];
            series.Points.Clear();

            for (int i = 0; i < transformedData.Length; i++)
            {
                double x = transformedData[i][0];
                double y = transformedData[i][1];
                series.Points.AddXY(x, y);
            }

            chart.Invalidate();
        }
    }
}