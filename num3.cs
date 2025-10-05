using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Задание 3: Сокращение дроби");
        
        // Ввод чисел
        Console.Write("Введите числитель M: ");
        int m = int.Parse(Console.ReadLine());

        Console.Write("Введите знаменатель N: ");
        int n = int.Parse(Console.ReadLine());

        // Проверка на нулевой знаменатель
        if (n == 0)
        {
            Console.WriteLine("Ошибка: знаменатель не может быть равен нулю");
            return;
        }

        // Находим НОД
        int gcd = FindGCD(Math.Abs(m), Math.Abs(n));

        // Сокращаем дробь
        int numerator = m / gcd;
        int denominator = n / gcd;

        // Выводим результат
        if (denominator == 1)
        {
            Console.WriteLine($"Несократимая дробь: {numerator}");
        }
        else if (denominator < 0)
        {
            // Если знаменатель отрицательный, переносим знак в числитель
            Console.WriteLine($"Несократимая дробь: {-numerator}/{-denominator}");
        }
        else
        {
            Console.WriteLine($"Несократимая дробь: {numerator}/{denominator}");
        }
    }

    // Метод для нахождения НОД (алгоритм Евклида)
    static int FindGCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }
}