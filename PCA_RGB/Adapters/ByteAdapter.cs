using System;

namespace PCA_RGB.Adapters
{
    public static class ByteAdapter
    {
        public static double[][] ToDoubleArray(this byte[] bytes, int n_components)
        {
            int rowCount = (int)Math.Ceiling((double)bytes.Length / n_components);

            double[][] result = new double[rowCount][];

            for (int i = 0; i < rowCount; i++)
            {
                result[i] = new double[n_components];
                for (int j = 0; j < n_components; j++)
                {
                    int index = i * n_components + j;
                    if (index < bytes.Length)
                    {
                        result[i][j] = bytes[index];
                    }
                    else
                    {
                        result[i][j] = double.NaN;
                    }
                }
            }

            return result;
        }
    }
}