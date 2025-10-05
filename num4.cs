using System;

class NumberGuesser
{
    static void Main()
    {
        Console.WriteLine("Задание 4: Угадай число");
        Console.WriteLine("Загадайте число от 0 до 63. Я попробую его угадать.");
        Console.WriteLine("Отвечайте '1' (да) или '0' (нет) на мои вопросы.");

        int lower = 0;
        int upper = 63;
        int guess = 0;

        // Используем бинарный поиск (6 вопросов)
        for (int i = 5; i >= 0; i--)
        {
            int currentBit = (int)Math.Pow(2, i);
            Console.Write($"Ваше число больше или равно {lower + currentBit}? (1/0): ");
            
            string answer = Console.ReadLine();
            
            if (answer == "1")
            {
                lower += currentBit;
                guess += currentBit;
            }
            else
            {
                upper = lower + currentBit - 1;
            }
        }

        Console.WriteLine($"Ваше число: {guess}");
        Console.WriteLine("Я угадал?");
    }
}