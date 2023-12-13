using Labs_CTP;


class Program
{
    /*
Модульное тестирование программ на языке С# средствами Visual Studio

Модульное тестирование библиотеки классов  на C# средствами Visual Studio

Модульное тестирование программ на языке С++ в среде Visual Studio

Разработка и модульное тестирование класса Матрица на С#



Класс р-ичное число



Редактор комплексных чисел

Шаблон класса память на одно число

Шаблон класса процессор

Класс Полином

Класс Множество

Вероятностное моделирование метрических характеристик программ

Вычисление метрических характеристик реализаций алгоритмов
    */
    static void Main(string[] args)
    {

        // MatrisShow();
        // Lab11.Show();
        Lab12.Show();
        // Lab13.Show();

        Console.ReadKey();
    }
    static void MatrisShow()
    {
        try
        {
            Matrix a = new Matrix(3, 3);
            Matrix b = new Matrix(3, 3);
            Matrix c;
            for (int i = 0; i < a.I; i++)
            {
                for (int j = 0; j < a.J; j++)
                {
                    a[i, j] = a.J * i + j;
                }
            }
            Console.WriteLine("Matrix a:\n");
            a.Show();
            for (int i = 0; i < a.I; i++)
            {
                for (int j = 0; j < a.J; j++)
                {
                    b[i, j] = a.J * i + j;
                }
            }
            Console.WriteLine("Matrix b:\n");
            b.Show();

            Console.WriteLine("a + b:\n");
            c = a + b;
            c.Show();
            Console.WriteLine("\n");

            Console.WriteLine("a - b:\n");
            c = a - b;
            c.Show();
            Console.WriteLine("\n");

            Console.WriteLine("a * b:\n");
            c = a * b;
            c.Show();
            Console.WriteLine("\n\n");

            Console.WriteLine("a == b:\n");
            bool res = a == b;
            Console.WriteLine(res + "\n\n");

            Console.WriteLine("Transpose a:\n");
            a.Show();
            c = a;
            c.Transp();
            c.Show();
            Console.WriteLine("\n");

            Console.WriteLine("Minimum a:\n");
            a.Show();
            int m = a.Min();
            Console.WriteLine("Min a = " + m + "\n\n");

            Console.WriteLine("ToString a:\n");
            a.Show();
            string str = a.MatrixStr();
            Console.WriteLine("a = " + str + "\n\n");

            Console.WriteLine("Take elem a[1, 2]:\n");
            int elem = a.TakeElem(1, 2);
            Console.WriteLine("a[1, 2] = " + elem + "\n\n");

            Console.WriteLine("Write elem a[1, 1] = 7:\n");
            a.Show();
            c = a;
            c.WriteElem(2, 0, 7);
            c.Show();
            //Console.WriteLine(c + "\n\n");
        }
        catch (Exception e)
        {
            Console.WriteLine((string)e.Message);
        }

    }
}

