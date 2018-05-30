using System;
using System.Collections.Generic;
using System.Text;

namespace MyPaint
{
    //用于计算三角形的外接圆
    class triwaijie
    {
        public struct point
        {
            public double X;
            public double Y;
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
        public double[] waijieyuan(point a,point b,point c)
        {
            double[][] A = new double[2][];
            A[0] = new double[2] { (a.X - b.X), (a.Y - b.Y) };
            A[1] = new double[2]{(a.X - c.X) ,(a.Y - c.Y)};
            double[][] W = new double[2][];
            W[0] = new double[1]{(pingfang(a.X) - pingfang(b.X) + pingfang(a.Y) - pingfang(b.Y)) / 2};
            W[1] = new double[1]{(pingfang(a.X) - pingfang(c.X) + pingfang(a.Y) - pingfang(c.Y)) / 2};
            double[][] A_ = new double[2][];
            A_ = InverseMatrix(A);
            double[] relust = new double[2];
            relust[0]=MatrixMult(A_, W)[0][0];
            relust[1] = MatrixMult(A_, W)[1][0];
            return relust;
        }
        public double banjing(double[] dian, point b)
        {
            point dain;
            double zong=0;
            Double xy=0, xy2=0;
            dain.X = dian[0]; dain.Y = dian[1];

                xy = (dain.X - b.X) * (dain.X -b.X);

         
                  xy2 = (dain.Y - b.Y) * (dain.Y - b.Y);
  
             zong = xy + xy2;
            return Math.Sqrt(zong);
             
        }
        public double mianji(point a, point b, point c)
        {
            double R=banjing(waijieyuan(a, b, c),a);
            return Math.PI * R * R;

        }
        public double pingfang(double a)
        {
            return a * a;
        }
    }
}
