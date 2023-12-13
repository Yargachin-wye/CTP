using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs_CTP
{
    public class Matrix
    {
        int[,] matrix;
        public int I { get; set; }
        public int J { get; set; }
        public Matrix(int i, int j)
        {
            if (i <= 0)
            {
                throw new Exception(string.Format("Недопустимое значение i = {0}", i));
            }
            if (j <= 0)
            {
                throw new Exception(string.Format("Недопустимое значение j = {0}", j));
            }
            I = i;
            J = j;
            matrix = new int[i, j];
        }
        public int this[int i, int j]
        {
            get
            {
                if (i < 0 | i > I - 1)
                {
                    throw new Exception(string.Format("Неверное значение i = {0}", i));
                }
                if (j < 0 | i > J - 1)
                {
                    throw new Exception(string.Format("Неверное значение j = {0}", j));
                }
                return matrix[i, j];
            }
            set
            {
                if (i < 0 | i > I - 1)
                {
                    throw new Exception(string.Format("Неверное значение i = {0}", i));
                }
                if (j < 0 | i > J - 1)
                {
                    throw new Exception(string.Format("Неверное значение j = {0}", j));
                }
                matrix[i, j] = value;
            }
        }
        public static Matrix operator +(Matrix a, Matrix b)
        {
            if (a.I != b.I | a.J != b.J)
            {
                throw new Exception(string.Format("Размерности матриц a и b разные"));
            }
            Matrix c = new Matrix(a.I, a.J);
            for (int i = 0; i < a.I; i++)
            {
                for (int j = 0; j < a.J; j++)
                {
                    c.matrix[i, j] = a.matrix[i, j] + b.matrix[i, j];
                }
            }
            return c;
        }
        public static bool operator ==(Matrix a, Matrix b)
        {
            if (a.I != b.I | a.J != b.J)
            {
                throw new Exception(string.Format("Размерности матриц a и b разные"));
            }
            bool flag = true;
            for (int i = 0; i < a.I; i++)
            {
                for (int j = 0; j < a.J; j++)
                {
                    if (a.matrix[i, j] != b.matrix[i, j])
                    {
                        flag = false;
                        break;
                    }
                }
            }
            return flag;
        }
        public static bool operator !=(Matrix a, Matrix b)
        {
            return !(a.matrix == b.matrix);
        }
        public static Matrix operator -(Matrix a, Matrix b)
        {
            if (a.I != b.I | a.J != b.J)
            {
                throw new Exception(string.Format("Размерности матриц a и b разные"));
            }
            Matrix c = new Matrix(a.I, a.J);
            for (int i = 0; i < a.I; i++)
            {
                for (int j = 0; j < a.J; j++)
                {
                    c.matrix[i, j] = a.matrix[i, j] - b.matrix[i, j];
                }
            }
            return c;
        }
        public static Matrix operator *(Matrix a, Matrix b)
        {
            if (a.I != b.I | a.J != b.J)
            {
                throw new Exception(string.Format("Размерности матриц a и b разные"));
            }
            Matrix c = new Matrix(a.I, a.J);
            for (int i = 0; i < a.I; i++)
            {
                for (int j = 0; j < b.J; j++)
                {
                    for (int k = 0; k < a.J; k++)
                    {
                        c.matrix[i, j] += a.matrix[i, k] * b.matrix[k, j];
                    }
                }
            }
            return c;
        }
        public Matrix Transp()
        {
            if (I != J)
            {
                throw new Exception(string.Format("Число строк и столбцов должно совпадать"));
            }
            int tmp = 0;
            for (int i = 0; i < I; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    tmp = this[i, j];
                    this[i, j] = this[j, i];
                    this[j, i] = tmp;
                }
            }
            return this;
        }
        public int Min()
        {
            int minimum = this[0, 0];
            for (int i = 0; i < I; i++)
            {
                for (int j = 0; j < J; j++)
                {
                    if (this[i, j] < minimum)
                    {
                        minimum = this[i, j];
                    }
                }
            }
            return minimum;
        }

        public string MatrixStr()
        {
            string str = "{";
            string str_tmp = "";
            for (int i = 0; i < I; i++)
            {
                str_tmp += "{ ";
                for (int j = 0; j < J; j++)
                {
                    str_tmp = str_tmp + this[i, j].ToString() + " ";
                }
                str_tmp = str_tmp + "}";
            }
            str = str + str_tmp + "}";
            return str;
        }
        public int TakeElem(int n, int m)
        {
            if (n < 0 | n > I - 1)
            {
                throw new Exception(string.Format("Неверное значение n = {0}", n));
            }
            if (m < 0 | m > J - 1)
            {
                throw new Exception(string.Format("Неверное значение m = {0}", m));
            }
            int num = 0;
            for (int i = 0; i < I; i++)
            {
                for (int j = 0; j < J; j++)
                {
                    if (i == n && j == m)
                    {
                        num = this[i, j];
                    }
                }
            }
            return num;
        }
        public void WriteElem(int n, int m, int new_num)
        {
            if (n < 0 | n > I - 1)
            {
                throw new Exception(string.Format("Неверное значение n = {0}", n));
            }
            if (m < 0 | m > J - 1)
            {
                throw new Exception(string.Format("Неверное значение m = {0}", m));
            }
            for (int i = 0; i < I; i++)
            {
                for (int j = 0; j < J; j++)
                {
                    if (i == n && j == m)
                    {
                        this[i, j] = new_num;
                    }
                }
            }
        }

        public void Show()
        {
            for (int i = 0; i < I; i++)
            {
                for (int j = 0; j < J; j++)
                {
                    Console.Write("\t" + this[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        public override bool Equals(object obj)
        {
            return (this as Matrix) == (obj as Matrix);
        }
    }
}
