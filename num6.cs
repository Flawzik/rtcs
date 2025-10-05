using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Задание 6: Лабораторный опыт");
        
        // Ввод начальных данных
        Console.Write("Введите количество бактерий (N): ");
        int bacteria = int.Parse(Console.ReadLine());

        Console.Write("Введите количество капель антибиотика (X): ");
        int x = int.Parse(Console.ReadLine());

        int hour = 0;
        int killEffectiveness = 10; // Начальная эффективность одной капли

        Console.WriteLine("\nДинамика изменения количества бактерий:");

        // Цикл моделирования процесса
        while (bacteria > 0 && killEffectiveness > 0)
        {
            hour++;

            // Бактерии удваиваются
            bacteria *= 2;

            // Антибиотик убивает бактерии
            int totalKill = x * killEffectiveness;
            bacteria -= totalKill;

            // Не может быть отрицательного количества бактерий
            if (bacteria < 0) bacteria = 0;

            // Уменьшаем эффективность антибиотика
            killEffectiveness--;

            Console.WriteLine($"Час {hour}: Бактерий = {bacteria}, " +
                            $"Эффективность антибиотика = {killEffectiveness} бактерий/капля");

            // Проверяем условия завершения
            if (bacteria == 0)
            {
                Console.WriteLine("Все бактерии уничтожены!");
                break;
            }

            if (killEffectiveness == 0)
            {
                Console.WriteLine("Антибиотик перестал действовать!");
                break;
            }
        }

        Console.WriteLine($"\nПроцесс завершен через {hour} часов");
        Console.WriteLine($"Конечное количество бактерий: {bacteria}");
    }
}