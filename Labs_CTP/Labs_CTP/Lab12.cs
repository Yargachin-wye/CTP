using System;
using System.Linq;
using System.Collections.Generic;

namespace Labs_CTP
{
    public static class Lab12
    {
        private static (int, int) FindMinimum(int[] array)
        {
            int minValue = int.MaxValue;
            int minIndex = -1;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < minValue)
                {
                    minValue = array[i];
                    minIndex = i;
                }
            }

            return (minValue, minIndex);
        }

        private static void BubbleSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }

        private static int BinarySearch(int[] sortedArray, int target)
        {
            int left = 0;
            int right = sortedArray.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (sortedArray[mid] == target)
                    return mid;

                if (sortedArray[mid] < target)
                    left = mid + 1;
                else
                    right = mid - 1;
            }

            return -1;
        }

        private static (int, int, int) FindMinimum2D(int[,] array)
        {
            int minValue = int.MaxValue;
            int minRow = -1;
            int minCol = -1;

            for (int row = 0; row < array.GetLength(0); row++)
            {
                for (int col = 0; col < array.GetLength(1); col++)
                {
                    if (array[row, col] < minValue)
                    {
                        minValue = array[row, col];
                        minRow = row;
                        minCol = col;
                    }
                }
            }

            return (minValue, minRow, minCol);
        }

        private static void ReverseArray(int[] array)
        {
            Array.Reverse(array);
        }

        private static void RotateArrayLeft(int[] array, int positions)
        {
            int n = array.Length;
            positions %= n;

            int[] temp = new int[n];

            for (int i = 0; i < n; i++)
            {
                int newPosition = (i - positions + n) % n;
                temp[newPosition] = array[i];
            }

            for (int i = 0; i < n; i++)
            {
                array[i] = temp[i];
            }
        }

        private static void ReplaceAll(int[] array, int oldValue, int newValue)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == oldValue)
                {
                    array[i] = newValue;
                }
            }
        }

        private static void CalculateMetrics(string taskName, int[] array, string[] operands, string[] operators)
        {
            int etaStar2 = operands.Length + operators.Length;
            int eta1 = operators.Length;
            int eta2 = operands.Length;

            var vocabulary = new Dictionary<int, int>();
            foreach (int item in array)
            {
                if (!vocabulary.ContainsKey(item))
                {
                    vocabulary[item] = 1;
                }
                else
                {
                    vocabulary[item] += 1;
                }
            }

            int N1 = 0;
            int N2 = array.Length;
            foreach (int operand in vocabulary.Keys)
            {
                N1 += vocabulary[operand];
            }
            int N = eta1 + eta2;
            double NHat = etaStar2 * Math.Log(2 + etaStar2, 2);
            double VStar = (2 + etaStar2) * Math.Log(2 + etaStar2, 2);
            double V = VStar * N * Math.Log(2, Math.E);
            double L = V / VStar;
            double LHat = (2 / 3.0) * (N1 + N2) * Math.Log(2 + (N1 + N2) / 2, 2);
            double I = (2 / 3.0) * (N1 / N2) * (eta1 + eta2) * Math.Log(2 + (N1 / N2) * (eta1 + eta2), 2);

            double T1Hat = V / VStar;
            double T2Hat = (Math.Log(Math.Log(2 + eta1, 2) * Math.Log(2 + eta2, 2), 2) / 2);
            double T3Hat = Math.Log(2 + eta1, 2) * Math.Log(2 + eta2, 2) * N1 * N2 / 2;

            Console.WriteLine("Метрики для " + taskName + ":");
            Console.WriteLine($"n*2: {etaStar2}");
            Console.WriteLine($"n1: {eta1}");
            Console.WriteLine($"n2: {eta2}");
            Console.WriteLine($"Объем словарного запаса (n): {vocabulary.Count}");
            Console.WriteLine($"N1: {N1}");
            Console.WriteLine($"N2: {N2}");
            Console.WriteLine($"N: {N}");
            Console.WriteLine($"N^: {NHat}");
            Console.WriteLine($"V*: {VStar}");
            Console.WriteLine($"V: {V}");
            Console.WriteLine($"L: {L}");
            Console.WriteLine($"L^: {LHat}");
            Console.WriteLine($"I: {I}");
            Console.WriteLine($"T^1: {T1Hat}");
            Console.WriteLine($"T^2: {T2Hat}");
            Console.WriteLine($"T^3: {T3Hat}");
            Console.WriteLine();

            // Вычисление уровня программы через потенциальный объем (λ1)
            double lambda1 = L * V;

            Console.WriteLine($"(lam)1 (Уровень через потенциальный объем) для {taskName}: {lambda1}");
        }

        public static void Show()
        {
            int[] oneDimensionalArray = { 5, 3, 9, 1, 7 };
            int[,] twoDimensionalArray = { { 5, 3, 9 }, { 1, 7, 2 } };
            int targetValue = 1;

            // Выполнение задачи 1
            var minResult = FindMinimum(oneDimensionalArray);
            Console.WriteLine($"Минимальное значение в одномерном массиве: {minResult.Item1}");
            Console.WriteLine($"Индекс минимального значения: {minResult.Item2}");

            string[] task1Operands = { "minValue", "minIndex", "array", "i" };
            string[] task1Operators = { "for", "if" };

            CalculateMetrics("Задачи 1", oneDimensionalArray, task1Operands, task1Operators);

            // Выполнение задачи 2
            BubbleSort(oneDimensionalArray);
            Console.WriteLine("Сортировка одномерного массива:");
            foreach (var num in oneDimensionalArray)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();

            string[] task2Operands = { "temp", "i", "j" };
            string[] task2Operators = { "for" };

            CalculateMetrics("Задачи 2", oneDimensionalArray, task2Operands, task2Operators);

            // Выполнение задачи 3
            int binarySearchResult = BinarySearch(oneDimensionalArray, targetValue);
            if (binarySearchResult != -1)
            {
                Console.WriteLine($"Нашел {targetValue} по индексу {binarySearchResult}");
            }
            else
            {
                Console.WriteLine($"{targetValue} не найден в одномерном массиве");
            }

            string[] task3Operands = { "left", "right", "mid" };
            string[] task3Operators = { "if", "while" };

            CalculateMetrics("Задачи 3", oneDimensionalArray, task3Operands, task3Operators);

            // Выполнение задачи 4
            var minResult2D = FindMinimum2D(twoDimensionalArray);
            Console.WriteLine($"Минимальное значение в двумерном массиве: {minResult2D.Item1}");
            Console.WriteLine($"Строка минимального значения: {minResult2D.Item2}");
            Console.WriteLine($"Столбец с минимальным значением: {minResult2D.Item3}");
            string[] task4Operands = { "minValue", "minRow", "minCol", "array", "row", "col" };
            string[] task4Operators = { "if", "for", "nested for" };

            CalculateMetrics("Задачи 4", oneDimensionalArray, task4Operands, task4Operators);

            // Выполнение задачи 5
            ReverseArray(oneDimensionalArray);
            Console.WriteLine("Обратный одномерный массив:");
            foreach (var num in oneDimensionalArray)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();

            string[] task5Operands = { "temp", "i", "j" };
            string[] task5Operators = { "for" };

            CalculateMetrics("Задачи 5", oneDimensionalArray, task5Operands, task5Operators);

            // Выполнение задачи 6
            int positions = 2;
            RotateArrayLeft(oneDimensionalArray, positions);
            Console.WriteLine($"Вращающийся одномерный массив {positions} позиции слева:");
            foreach (var num in oneDimensionalArray)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();

            string[] task6Operands = { "positions", "n", "temp", "i", "newPosition" };
            string[] task6Operators = { "for" };

            CalculateMetrics("Задачи 6", oneDimensionalArray, task6Operands, task6Operators);

            // Выполнение задачи 7
            int oldValue = 3;
            int newValue = 8;
            ReplaceAll(oneDimensionalArray, oldValue, newValue);
            Console.WriteLine($"Одномерный массив со всеми вхождениями {oldValue} заменен на {newValue}:");
            foreach (var num in oneDimensionalArray)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();

            string[] task7Operands = { "oldValue", "newValue", "i" };
            string[] task7Operators = { "for", "if" };

            CalculateMetrics("Задачи 7", oneDimensionalArray, task7Operands, task7Operators);
        }
    }

}
