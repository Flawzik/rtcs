using System;

class CoffeeMachine
{
    // Основные параметры напитков
    private const int AMERICANO_WATER = 300;
    private const int LATTE_WATER = 30;
    private const int LATTE_MILK = 270;

    private const int AMERICANO_PRICE = 150;
    private const int LATTE_PRICE = 170;

    private int water;
    private int milk;
    private int americanoCount = 0;
    private int latteCount = 0;
    private int totalEarnings = 0;

    public void Start()
    {
        Console.WriteLine("Задание 5: Кофейный аппарат");
        
        // Запрашиваем начальный запас ингредиентов
        Console.Write("Введите количество воды (мл): ");
        water = int.Parse(Console.ReadLine());

        Console.Write("Введите количество молока (мл): ");
        milk = int.Parse(Console.ReadLine());

        // Основной цикл обслуживания
        while (true)
        {
            Console.WriteLine("\n=== Новый заказ ===");
            Console.WriteLine("Выберите напиток:");
            Console.WriteLine("1 - Американо (150 руб)");
            Console.WriteLine("2 - Латте (170 руб)");
            Console.WriteLine("3 - Завершить работу");
            Console.Write("Ваш выбор: ");

            int choice = int.Parse(Console.ReadLine());

            if (choice == 3)
            {
                GenerateReport();
                break;
            }

            bool canMakeAmericano = water >= AMERICANO_WATER;
            bool canMakeLatte = water >= LATTE_WATER && milk >= LATTE_MILK;

            if (!canMakeAmericano && !canMakeLatte)
            {
                Console.WriteLine("Ингредиенты закончились!");
                GenerateReport();
                break;
            }

            switch (choice)
            {
                case 1:
                    MakeAmericano();
                    break;
                case 2:
                    MakeLatte();
                    break;
                default:
                    Console.WriteLine("Неверный выбор");
                    break;
            }
        }
    }

    private void MakeAmericano()
    {
        if (water >= AMERICANO_WATER)
        {
            water -= AMERICANO_WATER;
            americanoCount++;
            totalEarnings += AMERICANO_PRICE;
            Console.WriteLine("Ваш напиток готов! Американо приготовлен.");
        }
        else
        {
            Console.WriteLine("Не хватает воды для приготовления Американо");
        }
        ShowRemainingResources();
    }

    private void MakeLatte()
    {
        if (water >= LATTE_WATER && milk >= LATTE_MILK)
        {
            water -= LATTE_WATER;
            milk -= LATTE_MILK;
            latteCount++;
            totalEarnings += LATTE_PRICE;
            Console.WriteLine("Ваш напиток готов! Латте приготовлен.");
        }
        else if (water < LATTE_WATER)
        {
            Console.WriteLine("Не хватает воды для приготовления Латте");
        }
        else
        {
            Console.WriteLine("Не хватает молока для приготовления Латте");
        }
        ShowRemainingResources();
    }

    private void ShowRemainingResources()
    {
        Console.WriteLine($"Осталось воды: {water} мл");
        Console.WriteLine($"Осталось молока: {milk} мл");
    }

    private void GenerateReport()
    {
        Console.WriteLine("\n=== ОТЧЕТ ===");
        Console.WriteLine("Ингредиенты подошли к концу");
        Console.WriteLine($"Остаток воды: {water} мл");
        Console.WriteLine($"Остаток молока: {milk} мл");
        Console.WriteLine($"Всего приготовлено чашек Американо: {americanoCount}");
        Console.WriteLine($"Всего приготовлено чашек Латте: {latteCount}");
        Console.WriteLine($"Итоговый заработок: {totalEarnings} руб");
    }

    static void Main()
    {
        CoffeeMachine machine = new CoffeeMachine();
        machine.Start();
    }
}