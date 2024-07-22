using System.Linq;
using System;
using Accord.Statistics;
using Accord.Statistics.Analysis;

namespace PCA_RGB
{
    public class PCA 
    {

        private readonly double[][] data;
        public readonly int n_components;

        public PCA(double[][] data, int n_components)
        {
            this.data = data;
            this.n_components = n_components;
        }

        public double[][] DoPCA()
        {
            double[][] X = StandardizeData();

            PrincipalComponentAnalysis pca = new PrincipalComponentAnalysis(method: PrincipalComponentMethod.Standardize, numberOfOutputs: n_components);
            pca.Learn(X);

            double[] eigenvalues = pca.Eigenvalues;
            double[][] eigenvectors = pca.ComponentVectors;

            double[] cumulativeExplainedVariance = CumulativeExplainedVariance(eigenvalues);

            double[][] transformedData = pca.Transform(X);

            return transformedData;

        }

        private double[][] StandardizeData()
        {
            var rows = data.Length;
            var cols = data[0].Length;

            var means = new double[cols];
            var stdDevs = new double[cols];

            for (int col = 0; col < cols; col++)
            {
                var column = data.Select(row => row[col]).ToArray();
                means[col] = column.Average();
                stdDevs[col] = Measures.StandardDeviation(column);
            }

            var standardizedData = new double[rows][];

            for (int row = 0; row < rows; row++)
            {
                standardizedData[row] = new double[cols];
                for (int col = 0; col < cols; col++)
                {
                    standardizedData[row][col] = (data[row][col] - means[col]) / stdDevs[col];
                }
            }

            return standardizedData;
        }

        private double[] CumulativeExplainedVariance(double[] eigenvalues)
        {
            var totalVariance = eigenvalues.Sum();
            var cumulativeSum = 0.0;
            var cumulativeExplainedVariance = new double[eigenvalues.Length];

            for (int i = 0; i < eigenvalues.Length; i++)
            {
                cumulativeSum += eigenvalues[i];
                cumulativeExplainedVariance[i] = cumulativeSum / totalVariance;
            }

            return cumulativeExplainedVariance;
        }
    }
}