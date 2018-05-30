using System;
using System.Collections.Generic;
using System.Text;

namespace MyPaint
{

    class des
    {
        static double R = 6371;
        public struct point { public double X; public double Y;};
        /// <summary>
        /// 计算欧式距离
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public Double Euclidean(Double[] x, Double[] y)
        {
            Double zong = 0;

            for (int i = 0; i < x.Length; i++)
            {
                Double xy = (x[i] - y[i]) * (x[i] - y[i]);
                zong = zong + xy;
            }
            return Math.Sqrt(zong);


        }
        /// <summary>
        /// 绝对值距离
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public Double Manhattan(Double[] x, Double[] y)
        {
            Double zong = 0;
            for (int i = 0; i < x.Length; i++)
            {
                Double xy = Math.Abs(x[i] - y[i]);
                zong = zong + xy;
            }

            return zong;
        }
        /// <summary>
        /// 切式距离
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public Double Chebyshev(Double[] x, Double[] y)
        {
            Double[] chebyshev = new Double[x.Length];
            for (int n = 0; n < x.Length; n++)
            {
                chebyshev[n] = Math.Abs(x[n] - y[n]);

            }
            for (int i = 0; i < chebyshev.Length; i++)
            {
                for (int j = i + 1; j < chebyshev.Length; j++)
                {
                    if (chebyshev[i] > chebyshev[j])
                    {
                        double temp = chebyshev[i];
                        chebyshev[i] = chebyshev[j];
                        chebyshev[j] = temp;
                    }
                }
            }
            return chebyshev[x.Length - 1];
        }
        /// <summary>
        /// 明氏距离
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public Double Minkowski(Double[] x, Double[] y, int m)
        {
            double q = 1.0 / m;
            Double zong = 0;
            Double xy = 1;
            for (int i = 0; i < x.Length; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    xy = (x[i] - y[i]) * xy;
                }
                zong = zong + xy;
                xy = 1;
            }
            return Math.Pow(zong, q); ;
        }
        /// <summary>
        /// 马氏距离
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public Double Mahalanobis(Double[][] Covar2, Double[] q) //样本矩阵的每行是一个样本，每列是一个维度
        {

            Double[][] Covar6 = new Double[3][];//A的转置
            Double[][] Covar5 = new Double[3][];//中间做转换
            Double[][] Covar4 = new Double[3][];//协方差矩阵的逆矩阵
            Double[,] Cover3 = new Double[q.Length, q.Length];

            Cover3 = Covar(Covar2, q);//协方差矩阵
            Covar6 = MatrixTranspose(Covar2);
            for (int i = 0; i < q.Length; i++)
            {
                Covar2[i][0] = Covar2[i][0] - q[0];
                Covar2[i][1] = Covar2[i][1] - q[1];
                Covar2[i][2] = Covar2[i][2] - q[2];
            }//Xi-均值

            for (int i = 0; i < q.Length; i++)
            {
                Double[] a = new Double[3];
                for (int j = 0; j < q.Length; j++)
                {
                    a[j] = Cover3[i, j];
                }
                Covar5[i] = a;
            }
            Covar4 = InverseMatrix(Covar5);//协方差矩阵的逆矩阵
            return MatrixMult(MatrixMult(Covar6, Covar5), Covar2)[0][0];

        }
        /// <summary>
        /// 求协方差阵
        /// </summary>
        /// <param name="data"></param>
        /// <param name="ave"></param>
        /// <returns></returns>
        static double[,] Covar(double[][] data, double[] ave)
        {

            double[,] covar = new double[ave.Length, ave.Length];
            for (int i = 0; i < ave.Length; i++)
            {

                for (int j = 0; j < ave.Length; j++)
                {
                    double sum = 0;
                    for (int k = 0; k < data[i].Length; k++)
                    {
                        double temp = (data[i][k] - ave[i]) * (data[j][k] - ave[j]);
                        sum += temp;
                    }

                    covar[i, j] = sum / data[i].Length;

                }

            }
            return covar;


        }
        //求均值
        public static double Ave(double[] data)
        {
            double sum = 0;
            for (int i = 0; i < data.Length; i++)
            {
                sum += data[i];
            }
            double ave = sum / data.Length;
            return ave;

        }
        /// <summary>
        /// 求矩阵的逆矩阵
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static double[][] InverseMatrix(double[][] matrix)
        {
            //matrix必须为非空
            if (matrix == null || matrix.Length == 0)
            {
                return new double[][] { };
            }

            //matrix 必须为方阵
            int len = matrix.Length;
            for (int counter = 0; counter < matrix.Length; counter++)
            {
                if (matrix[counter].Length != len)
                {
                    throw new Exception("matrix 必须为方阵");
                }
            }

            //计算矩阵行列式的值
            double dDeterminant = Determinant(matrix);
            if (Math.Abs(dDeterminant) <= 1E-6)
            {
                throw new Exception("矩阵不可逆");
            }

            //制作一个伴随矩阵大小的矩阵
            double[][] result = AdjointMatrix(matrix);

            //矩阵的每项除以矩阵行列式的值，即为所求
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix.Length; j++)
                {
                    result[i][j] = result[i][j] / dDeterminant;
                }
            }

            return result;
        }
        /// <summary>
        /// 递归计算行列式的值
        /// </summary>
        /// <param name="matrix">矩阵</param>
        /// <returns></returns>
        public static double Determinant(double[][] matrix)
        {
            //二阶及以下行列式直接计算
            if (matrix.Length == 0) return 0;
            else if (matrix.Length == 1) return matrix[0][0];
            else if (matrix.Length == 2)
            {
                return matrix[0][0] * matrix[1][1] - matrix[0][1] * matrix[1][0];
            }

            //对第一行使用“加边法”递归计算行列式的值
            double dSum = 0, dSign = 1;
            for (int i = 0; i < matrix.Length; i++)
            {
                double[][] matrixTemp = new double[matrix.Length - 1][];
                for (int count = 0; count < matrix.Length - 1; count++)
                {
                    matrixTemp[count] = new double[matrix.Length - 1];
                }

                for (int j = 0; j < matrixTemp.Length; j++)
                {
                    for (int k = 0; k < matrixTemp.Length; k++)
                    {
                        matrixTemp[j][k] = matrix[j + 1][k >= i ? k + 1 : k];
                    }
                }

                dSum += (matrix[0][i] * dSign * Determinant(matrixTemp));
                dSign = dSign * -1;
            }

            return dSum;
        }
        /// <summary>
        /// 计算方阵的伴随矩阵
        /// </summary>
        /// <param name="matrix">方阵</param>
        /// <returns></returns>
        public static double[][] AdjointMatrix(double[][] matrix)
        {
            //制作一个伴随矩阵大小的矩阵
            double[][] result = new double[matrix.Length][];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = new double[matrix[i].Length];
            }

            //生成伴随矩阵
            for (int i = 0; i < result.Length; i++)
            {
                for (int j = 0; j < result.Length; j++)
                {
                    //存储代数余子式的矩阵（行、列数都比原矩阵少1）
                    double[][] temp = new double[result.Length - 1][];
                    for (int k = 0; k < result.Length - 1; k++)
                    {
                        temp[k] = new double[result[k].Length - 1];
                    }

                    //生成代数余子式
                    for (int x = 0; x < temp.Length; x++)
                    {
                        for (int y = 0; y < temp.Length; y++)
                        {
                            temp[x][y] = matrix[x < i ? x : x + 1][y < j ? y : y + 1];
                        }
                    }

                    //Console.WriteLine("代数余子式:");
                    //PrintMatrix(temp);

                    result[j][i] = ((i + j) % 2 == 0 ? 1 : -1) * Determinant(temp);
                }
            }

            //Console.WriteLine("伴随矩阵：");
            //PrintMatrix(result);

            return result;
        }
        /// <summary>
        /// 求一个矩阵的转置矩阵
        /// </summary>
        /// <param name="matrix">矩阵</param>
        /// <returns>转置矩阵</returns>
        private static double[][] MatrixTranspose(double[][] matrix)
        {
            //合法性检查
            if (!isMatrix(matrix))
            {
                throw new Exception("matrix 不是一个矩阵");
            }
            //矩阵中没有元素的情况
            if (matrix.Length == 0)
            {
                return new double[][] { };
            }
            double[][] result = new double[matrix[0].Length][];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = new double[matrix.Length];
            }
            //新矩阵生成规则： b[i,j]=a[j,i]
            for (int i = 0; i < result.Length; i++)
            {
                for (int j = 0; j < result[0].Length; j++)
                {
                    result[i][j] = matrix[j][i];
                }
            }
            return result;
        }
        /// <summary>
        /// 判断一个二维数组是否为矩阵
        /// </summary>
        /// <param name="matrix">二维数组</param>
        /// <returns>true:是矩阵 false:不是矩阵</returns>
        private static bool isMatrix(double[][] matrix)
        {
            //空矩阵是矩阵
            if (matrix.Length < 1) return true;
            //不同行列数如果不相等，则不是矩阵
            int count = matrix[0].Length;
            for (int i = 1; i < matrix.Length; i++)
            {
                if (matrix[i].Length != count)
                {
                    return false;
                }
            }
            //各行列数相等，则是矩阵
            return true;
        }
        /// <summary>
        /// 打印矩阵
        /// </summary>
        /// <param name="matrix">待打印矩阵</param>
        private static void PrintMatrix(double[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    Console.Write(matrix[i][j] + "\t");
                    //注意不能写为：Console.Write(matrix[i][j] + '\t');
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// 矩阵数乘
        /// </summary>
        /// <param name="matrix">矩阵</param>
        /// <param name="num">常数</param>
        /// <returns>积</returns>
        private static double[][] MatrixMult(double[][] matrix, double num)
        {
            //合法性检查
            if (!isMatrix(matrix))
            {
                throw new Exception("传入的参数并不是一个矩阵");
            }

            //参数为空矩阵则返回空矩阵
            if (matrix.Length == 0)
            {
                return new double[][] { };
            }

            //生成一个与matrix同型的空矩阵
            double[][] result = new double[matrix.Length][];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = new double[matrix[i].Length];
            }

            //矩阵数乘：用常数依次乘以矩阵各元素
            for (int i = 0; i < result.Length; i++)
            {
                for (int j = 0; j < result[0].Length; j++)
                {
                    result[i][j] = matrix[i][j] * num;
                }
            }

            return result;
        }
        /// <summary>
        /// 矩阵乘法
        /// </summary>
        /// <param name="matrix1">矩阵1</param>
        /// <param name="matrix2">矩阵2</param>
        /// <returns>积</returns>
        private static double[][] MatrixMult(double[][] matrix1, double[][] matrix2)
        {
            //合法性检查
            if (MatrixCR(matrix1)[1] != MatrixCR(matrix2)[0])
            {
                throw new Exception("matrix1 的列数与 matrix2 的行数不相等");
            }

            //矩阵中没有元素的情况
            if (matrix1.Length == 0 || matrix2.Length == 0)
            {
                return new double[][] { };
            }

            //matrix1是m*n矩阵，matrix2是n*p矩阵，则result是m*p矩阵
            int m = matrix1.Length, n = matrix2.Length, p = matrix2[0].Length;
            double[][] result = new double[m][];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = new double[p];
            }

            //矩阵乘法：c[i,j]=Sigma(k=1→n,a[i,k]*b[k,j])
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < p; j++)
                {
                    //对乘加法则
                    for (int k = 0; k < n; k++)
                    {
                        result[i][j] += (matrix1[i][k] * matrix2[k][j]);
                    }
                }
            }

            return result;
        }
        /// <summary>
        /// 计算一个矩阵的行数和列数
        /// </summary>
        /// <param name="matrix">矩阵</param>
        /// <returns>数组：行数、列数</returns>
        private static int[] MatrixCR(double[][] matrix)
        {
            //接收到的参数不是矩阵则报异常
            if (!isMatrix(matrix))
            {
                throw new Exception("接收到的参数不是矩阵");
            }

            //空矩阵行数列数都为0
            if (!isMatrix(matrix) || matrix.Length == 0)
            {
                return new int[2] { 0, 0 };
            }

            return new int[2] { matrix.Length, matrix[0].Length };
        }
        /// <summary>
        /// 矩阵取负
        /// </summary>
        /// <param name="matrix">矩阵</param>
        /// <returns>负矩阵</returns>
        private static double[][] NegtMatrix(double[][] matrix)
        {
            //合法性检查
            if (!isMatrix(matrix))
            {
                throw new Exception("传入的参数并不是一个矩阵");
            }

            //参数为空矩阵则返回空矩阵
            if (matrix.Length == 0)
            {
                return new double[][] { };
            }

            //生成一个与matrix同型的空矩阵
            double[][] result = new double[matrix.Length][];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = new double[matrix[i].Length];
            }

            //矩阵取负：各元素取相反数
            for (int i = 0; i < result.Length; i++)
            {
                for (int j = 0; j < result[0].Length; j++)
                {
                    result[i][j] = -matrix[i][j];
                }
            }

            return result;
        }
        /// <summary>
        /// 球面距离量算
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public Double qiu(point x, point y)
        {
            double d;
            Double A = Math.Abs((x.X - y.X) / 2);
            Double B = Math.Abs((x.Y - y.Y) / 2);
            d = 2 * R * Math.Pow(Math.Pow((Math.Sqrt(A) + Math.Sqrt(B) * Math.Cos(x.X) * Math.Cos(y.X)), 1.0 / 2), -1.0);
            return d;
        }
    }
}
