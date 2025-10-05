using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Задание 2: Проверка счастливого билета");
        
        // Получаем номер билета от пользователя
        Console.Write("Введите шестизначный номер билета: ");
        int ticket = int.Parse(Console.ReadLine());

        // Проверяем корректность ввода
        if (ticket < 100000 || ticket > 999999)
        {
            Console.WriteLine("Ошибка: введите корректный шестизначный номер");
            return;
        }

        // Извлекаем цифры без использования строк и массивов
        int digit1 = ticket / 100000;
        int digit2 = (ticket / 10000) % 10;
        int digit3 = (ticket / 1000) % 10;
        int digit4 = (ticket / 100) % 10;
        int digit5 = (ticket / 10) % 10;
        int digit6 = ticket % 10;

        // Вычисляем суммы
        int sumFirst = digit1 + digit2 + digit3;
        int sumLast = digit4 + digit5 + digit6;

        // Выводим результат
        if (sumFirst == sumLast)
        {
            Console.WriteLine("Билет счастливый!");
        }
        else
        {
            Console.WriteLine("Билет обычный.");
        }

        Console.WriteLine($"Сумма первых трех цифр: {sumFirst}");
        Console.WriteLine($"Сумма последних трех цифр: {sumLast}");
    }
}