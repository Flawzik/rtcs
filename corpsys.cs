using System;

class Program
{
    // Функция для вычисления факториала
    static double Factorial(int n)
    {
        if (n == 0) return 1;
        double result = 1;
        for (int i = 1; i <= n; i++)
            result *= i;
        return result;
    }

    // Функция для вычисления n-го члена ряда Маклорена для cos(x)
    static double GetNthTerm(double x, int n)
    {
        // Ряд Маклорена для cos(x): sum[(-1)^n * x^(2n) / (2n)!]
        int power = 2 * n;
        double term = Math.Pow(-1, n) * Math.Pow(x, power) / Factorial(power);
        return term;
    }

    // Функция для вычисления суммы ряда с заданной точностью
    static double CalculateSeries(double x, double epsilon)
    {
        double sum = 0;
        double term = 1; // Первый член ряда (n=0)
        int n = 0;

        while (Math.Abs(term) > epsilon)
        {
            sum += term;
            n++;
            term = GetNthTerm(x, n);
        }

        return sum;
    }

    static void Main()
    {
        Console.WriteLine("Задание 1: Вычисление cos(x) с помощью ряда Маклорена");
        
        // Вычисление с заданной точностью
        Console.WriteLine("Введите x:");
        double x = double.Parse(Console.ReadLine());

        Console.WriteLine("Введите точность (e < 0.01):");
        double epsilon = double.Parse(Console.ReadLine());
        
        if (epsilon >= 0.01)
        {
            Console.WriteLine("Точность должна быть меньше 0.01");
            return;
        }

        double result = CalculateSeries(x, epsilon);
        double exactValue = Math.Cos(x);
        Console.WriteLine($"Значение функции с точностью {epsilon}: {result}");
        Console.WriteLine($"Точное значение cos({x}): {exactValue}");
        Console.WriteLine($"Погрешность: {Math.Abs(exactValue - result)}");

        // Вычисление n-го члена
        Console.WriteLine("\nВведите номер члена ряда (n):");
        int n = int.Parse(Console.ReadLine());
        double nthTerm = GetNthTerm(x, n);
        Console.WriteLine($"Значение {n}-го члена ряда: {nthTerm}");
    }
}