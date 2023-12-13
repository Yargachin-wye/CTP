#include <iostream>
#include <vector>
#include <algorithm>
#include <cmath>
#include <unordered_map>

class Lab12 {
private:
    static std::pair<int, int> FindMinimum(const std::vector<int>& array) {
        int minValue = INT_MAX;
        int minIndex = -1;

        for (int i = 0; i < array.size(); ++i) {
            if (array[i] < minValue) {
                minValue = array[i];
                minIndex = i;
            }
        }

        return std::make_pair(minValue, minIndex);
    }

    static void BubbleSort(std::vector<int>& array) {
        int n = array.size();
        for (int i = 0; i < n - 1; ++i) {
            for (int j = 0; j < n - 1 - i; ++j) {
                if (array[j] > array[j + 1]) {
                    std::swap(array[j], array[j + 1]);
                }
            }
        }
    }

    static int BinarySearch(const std::vector<int>& sortedArray, int target) {
        int left = 0;
        int right = sortedArray.size() - 1;

        while (left <= right) {
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

    static std::tuple<int, int, int> FindMinimum2D(const std::vector<std::vector<int>>& array) {
        int minValue = INT_MAX;
        int minRow = -1;
        int minCol = -1;

        for (int row = 0; row < array.size(); ++row) {
            for (int col = 0; col < array[0].size(); ++col) {
                if (array[row][col] < minValue) {
                    minValue = array[row][col];
                    minRow = row;
                    minCol = col;
                }
            }
        }

        return std::make_tuple(minValue, minRow, minCol);
    }

    static void ReverseArray(std::vector<int>& array) {
        std::reverse(array.begin(), array.end());
    }

    static void RotateArrayLeft(std::vector<int>& array, int positions) {
        int n = array.size();
        positions %= n;

        std::vector<int> temp(n);

        for (int i = 0; i < n; ++i) {
            int newPosition = (i - positions + n) % n;
            temp[newPosition] = array[i];
        }

        for (int i = 0; i < n; ++i) {
            array[i] = temp[i];
        }
    }

    static void ReplaceAll(std::vector<int>& array, int oldValue, int newValue) {
        for (int i = 0; i < array.size(); ++i) {
            if (array[i] == oldValue) {
                array[i] = newValue;
            }
        }
    }

    static void CalculateMetrics(const std::string& taskName, const std::vector<int>& array, const std::vector<std::string>& operands, const std::vector<std::string>& operators) {
        int etaStar2 = operands.size() + operators.size();
        int eta1 = operators.size();
        int eta2 = operands.size();

        std::unordered_map<int, int> vocabulary;
        for (int item : array) {
            if (vocabulary.find(item) == vocabulary.end()) {
                vocabulary[item] = 1;
            }
            else {
                vocabulary[item] += 1;
            }
        }

        int N1 = 0;
        int N2 = array.size();
        for (const auto& entry : vocabulary) {
            N1 += entry.second;
        }
        int N = eta1 + eta2;
        double NHat = etaStar2 * log2(2 + etaStar2);
        double VStar = (2 + etaStar2) * log2(2 + etaStar2);
        double V = VStar * N * log(2) / log(exp(1));
        double L = V / VStar;
        double LHat = (2.0 / 3) * (N1 + N2) * log2(2 + (N1 + N2) / 2);
        double I = (2.0 / 3) * (N1 / N2) * (eta1 + eta2) * log2(2 + (N1 / N2) * (eta1 + eta2));

        double T1Hat = V / VStar;
        double T2Hat = (log2(log2(2 + eta1) * log2(2 + eta2)) / 2);
        double T3Hat = log2(2 + eta1) * log2(2 + eta2) * N1 * N2 / 2;

        std::cout << "Метрики для " << taskName << ":\n";
        std::cout << "n*2: " << etaStar2 << "\n";
        std::cout << "n1: " << eta1 << "\n";
        std::cout << "n2: " << eta2 << "\n";
        std::cout << "Объем словарного запаса (n): " << vocabulary.size() << "\n";
        std::cout << "N1: " << N1 << "\n";
        std::cout << "N2: " << N2 << "\n";
        std::cout << "N: " << N << "\n";
        std::cout << "N^: " << NHat << "\n";
        std::cout << "V*: " << VStar << "\n";
        std::cout << "V: " << V << "\n";
        std::cout << "L: " << L << "\n";
        std::cout << "L^: " << LHat << "\n";
        std::cout << "I: " << I << "\n";
        std::cout << "T^1: " << T1Hat << "\n";
        std::cout << "T^2: " << T2Hat << "\n";
        std::cout << "T^3: " << T3Hat << "\n\n";

        // Вычисление уровня программы через потенциальный объем (λ1)
        double lambda1 = L * V;

        std::cout << "(lam)1 (Уровень через потенциальный объем) для " << taskName << ": " << lambda1 << "\n";
    }

public:
    static void Show() {
        std::vector<int> oneDimensionalArray = { 5, 3, 9, 1, 7 };
        std::vector<std::vector<int>> twoDimensionalArray = { { 5, 3, 9 }, { 1, 7, 2 } };
        int targetValue = 1;

        // Выполнение задачи 1
        auto minResult = FindMinimum(oneDimensionalArray);
        std::cout << "Минимальное значение в одномерном массиве: " << minResult.first << "\n";
        std::cout << "Индекс минимального значения: " << minResult.second << "\n";

        std::vector<std::string> task1Operands = { "minValue", "minIndex", "array", "i" };
        std::vector<std::string> task1Operators = { "for", "if" };

        CalculateMetrics("Задачи 1", oneDimensionalArray, task1Operands, task1Operators);

        // Выполнение задачи 2
        BubbleSort(oneDimensionalArray);
        std::cout << "Сортировка одномерного массива:\n";
        for (int num : oneDimensionalArray) {
            std::cout << num << " ";
        }
        std::cout << "\n";

        std::vector<std::string> task2Operands = { "temp", "i", "j" };
        std::vector<std::string> task2Operators = { "for" };

        CalculateMetrics("Задачи 2", oneDimensionalArray, task2Operands, task2Operators);

        // Выполнение задачи 3
        int binarySearchResult = BinarySearch(oneDimensionalArray, targetValue);
        if (binarySearchResult != -1) {
            std::cout << "Нашел " << targetValue << " по индексу " << binarySearchResult << "\n";
        }
        else {
            std::cout << targetValue << " не найден в одномерном массиве\n";
        }

        std::vector<std::string> task3Operands = { "left", "right", "mid" };
        std::vector<std::string> task3Operators = { "if", "while" };

        CalculateMetrics("Задачи 3", oneDimensionalArray, task3Operands, task3Operators);

        // Выполнение задачи 4
        auto minResult2D = FindMinimum2D(twoDimensionalArray);
        std::cout << "Минимальное значение в двумерном массиве: " << std::get<0>(minResult2D) << "\n";
        std::cout << "Строка минимального значения: " << std::get<1>(minResult2D) << "\n";
        std::cout << "Столбец с минимальным значением: " << std::get<2>(minResult2D) << "\n";

        std::vector<std::string> task4Operands = { "minValue", "minRow", "minCol", "array", "row", "col" };
        std::vector<std::string> task4Operators = { "if", "for", "nested for" };

        CalculateMetrics("Задачи 4", oneDimensionalArray, task4Operands, task4Operators);

        // Выполнение задачи 5
        ReverseArray(oneDimensionalArray);
        std::cout << "Обратный одномерный массив:\n";
        for (int num : oneDimensionalArray) {
            std::cout << num << " ";
        }
        std::cout << "\n";

        std::vector<std::string> task5Operands = { "temp", "i", "j" };
        std::vector<std::string> task5Operators = { "for" };

        CalculateMetrics("Задачи 5", oneDimensionalArray, task5Operands, task5Operators);

        // Выполнение задачи 6
        int positions = 2;
        RotateArrayLeft(oneDimensionalArray, positions);
        std::cout << "Вращающийся одномерный массив " << positions << " позиции слева:\n";
        for (int num : oneDimensionalArray) {
            std::cout << num << " ";
        }
        std::cout << "\n";

        std::vector<std::string> task6Operands = { "positions", "n", "temp", "i", "newPosition" };
        std::vector<std::string> task6Operators = { "for" };

        CalculateMetrics("Задачи 6", oneDimensionalArray, task6Operands, task6Operators);

        // Выполнение задачи 7
        int oldValue = 3;
        int newValue = 8;
        ReplaceAll(oneDimensionalArray, oldValue, newValue);
        std::cout << "Одномерный массив со всеми вхождениями " << oldValue << " заменен на " << newValue << ":\n";
        for (int num : oneDimensionalArray) {
            std::cout << num << " ";
        }
        std::cout << "\n";

        std::vector<std::string> task7Operands = { "oldValue", "newValue", "i" };
        std::vector<std::string> task7Operators = { "for", "if" };

        CalculateMetrics("Задачи 7", oneDimensionalArray, task7Operands, task7Operators);
    }
};

int main() {

    Lab12::Show();
    return 0;
}