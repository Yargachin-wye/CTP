using System;
using System.Collections.Generic;
using System.Linq;

namespace Labs_CTP
{
    public static class Lab11
    {
        static Random random = new Random();

        static List<string> GenerateVocabulary(int dictionarySize)
        {
            var vocabulary = new List<string>();
            for (int i = 0; i < dictionarySize; i++)
            {
                vocabulary.Add("op" + i);
                vocabulary.Add("operand" + i);
            }
            return vocabulary;
        }

        static Tuple<List<string>, int> SimulateProgramGeneration(int dictionarySize)
        {
            var vocabulary = GenerateVocabulary(dictionarySize);
            var program = new List<string>();

            while (vocabulary.Count > 0)
            {
                int index = random.Next(vocabulary.Count);
                string selected = vocabulary[index];
                program.Add(selected);
                vocabulary.RemoveAt(index);
            }

            int programLength = program.Count;
            return Tuple.Create(program, programLength);
        }
        public static void Show()
        {
            int[] dictionarySizes = { 16, 32, 64, 128, 256, 4096 };

            foreach (int dictionarySize in dictionarySizes)
            {
                var result = SimulateProgramGeneration(dictionarySize);
                Console.WriteLine();
                var program = result.Item1;
                int programLength = result.Item2;

                double expectedLength = 0.9 * dictionarySize * Math.Log2(dictionarySize);
                double variance = (Math.PI * Math.PI * dictionarySize * dictionarySize) / 6;
                double standardDeviation = Math.Sqrt(variance);
                double relativeError = 1.0 / (2 * Math.Log2(dictionarySize));

                Console.WriteLine($"Размер словаря (n): {dictionarySize}");
                Console.WriteLine($"Длинна программы (L): {programLength}");
                Console.WriteLine($"Математическое ожидание длины программы: {expectedLength:F2}");
                Console.WriteLine($"Дисперсия программы: {variance:F2}");
                Console.WriteLine($"Относительная ожидаемая погрешность длины программы: {standardDeviation:F2}");
                Console.WriteLine($"Относительная ожидаемая погрешность: {relativeError:F2}\n");
            }
        }
    }
}

