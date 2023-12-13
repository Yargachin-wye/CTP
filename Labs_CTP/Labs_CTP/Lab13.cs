using System;
using System.Linq;
using System.Collections.Generic;

namespace Labs_CTP
{
    public static class Lab13
    {
        public static void Show()
        {
            int[] valuesOfEta2 = { 300, 400, 512 };
            int n = 5; // Число программистов
            int v = 20; // Число отлаженных в день команд ассемблера

            foreach (int eta_2 in valuesOfEta2)
            {
                int i = 0;
                double totalModules = 0;
                double k = eta_2 / 8;

                if (k > 8)
                {
                    i = 1;
                    while (k > 8)
                    {
                        k /= 8;
                        i++;
                    }
                    totalModules = k * Math.Pow(8, i);
                }
                else
                {
                    totalModules = eta_2;
                }

                double N = Math.Pow(2, totalModules);
                double V = N * eta_2;
                double P = N * Math.Log(eta_2, 2) / 8;

                double Tk = V / (n * v);
                double tau = 0.5 * Tk;
                double B = tau / Tk;

                double t_n = Math.Exp(-B);

                Console.WriteLine($"Метрические характеристики для eta_2 = {eta_2}:");
                Console.WriteLine($"Число уровней иерархии: {i}");
                Console.WriteLine($"Общее число модулей в ПС: {totalModules}");
                Console.WriteLine($"Длина N программы: {N}");
                Console.WriteLine($"Объем V ПС: {V}");
                Console.WriteLine($"Длина ПС в количестве команд ассемблера P: {P}");
                Console.WriteLine($"Календарное время программирования Tk: {Tk}");
                Console.WriteLine($"Начальное количество ошибок B: {B}");
                Console.WriteLine($"Начальная надежность ПС tн: {t_n}");
                Console.WriteLine();
            }
        }
    }
}

