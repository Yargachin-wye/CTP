#include <iostream>
#include <cmath>

int main() {
    std::locale::global(std::locale("ru"));

    int valuesOfEta2[] = { 300, 400, 512 };
    int n = 5; // Число программистов
    int v = 20; // Число отлаженных в день команд ассемблера

    for (int eta_2 : valuesOfEta2) {
        int i = 0;
        double totalModules = 0;
        double k = eta_2 / 8.0;

        if (k > 8) {
            i = 1;
            while (k > 8) {
                k /= 8;
                i++;
            }
            totalModules = k * std::pow(8, i);
        }
        else {
            totalModules = eta_2;
        }

        double N = std::pow(2, totalModules);
        double V = N * eta_2;
        double P = N * std::log2(eta_2) / 8;

        double Tk = V / (n * v);
        double tau = 0.5 * Tk;
        double B = tau / Tk;

        double t_n = std::exp(-B);

        std::cout << "Метрические характеристики для eta_2: " << eta_2 << ":\n";
        std::cout << "Число уровней иерархии: " << i << "\n";
        std::cout << "Общее число модулей в ПС: " << totalModules << "\n";
        std::cout << "Длина N программы: " << N << "\n";
        std::cout << "Объем V ПС: " << V << "\n";
        std::cout << "Длина ПС в количестве команд ассемблера P: " << P << "\n";
        std::cout << "Календарное время программирования Tk: " << Tk << "\n";
        std::cout << "Начальное количество ошибок B: " << B << "\n";
        std::cout << "Начальная надежность ПС tн: " << t_n << "\n\n";
    }

    return 0;
}