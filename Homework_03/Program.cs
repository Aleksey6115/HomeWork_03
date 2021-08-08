using System;

namespace Homework_03
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Необходимые переменные
            string[] username; // Массив в котором хранятся имена игроков
            int[] usertry; // Массив в котором хранятся вводимые числа игроков
            Random number = new Random(); // Генератор случайных чисел
            int gameNumber; // Загаданное число из которого вычитаются числа игроков
            bool flag = true; // Переменная для проверки условий
            int select = 1; // Переменная для выбора режима игры
            int select_level = 1; // Переменная для выбора уровня сложности
            int select_realgame = 1; // Переменная для выбора в игре с реальными игроками
            int select_PCgame; // Переменная для выбора в игре с компьютером
            int amount_users; // Колличество игрков
            int min_gameNumber; // Минимальное значение gameNumber
            int max_game_Number; // Максимальное значение gameNumber
            int max_usertry; // Максимальное значение usertry
            int result_PC; // Возможность ПК выиграть
            #endregion 

            #region  правила
            // Приветствие и правила игры
            Console.WriteLine("Рады Вас приветствовать в нашей игре!!! Ознакомтесь с правилами:\n" +
                "1. Загадывается число от 12 до 120 или в выбранном диапозоне, причём случайным образом. Назовём его gameNumber.\n" +
                "2. Игроки по очереди выбирают число в определённом диапозоне (В зависомти от уровня сложности).\n" +
                "   Пусть это число обозначается как userTry.\n" +
                "3. UserTry после каждого хода вычитается из gameNumber, а само gameNumber выводится на экран.\n" +
                "4. Если после хода игрока gameNumber равняется нулю, то походивший игрок оказывается победителем.");
            #endregion

            while (select != 3)
            {
              Console.WriteLine($"\nПожалуйста выбирете режим игры и нажмите на клавиатуре соответсвующую цифру:\n" +
                    $"1 - Игра с реальными игроками\n" +
                    $"2 - Игра с компьютером\n" +
                    $"3 - Закрыть программу");

                select = int.Parse(Console.ReadLine()); // Выбор режима игры

                switch (select)
                {
                    case 1: // Игра с реальными игроками
                        #region Игра с реальными игроками

                        #region Выбор уровня сложности
                        Console.WriteLine("\nВы выбрали игру с реальными игроками, давайте выберем уровень сложности:\n" +
                            "1 - Новичок\n" +
                            "2 - Проффесионал");

                        do
                        {
                            select_level = int.Parse(Console.ReadLine()); // Выбор уровня сложности
                            if (select_level < 1 ^ select_level > 2) Console.Write("Введите ещё раз: ");
                        }
                        while (select_level < 1 ^ select_level > 2); // Условия ввода

                        #endregion

                        switch (select_level)
                        {
                            case 1: // Уровень сложности новичок
                                #region 
                                select_realgame = 1; //Сброс значения переменной Если с главного меню повторно захотят зайти

                                    Console.Clear();
                                    Console.WriteLine("Вы выбрали уровень сложности новичок\n" +
                                        "В это режиме игры значение gameNumber находится в диапозоне от 12 до 120,\n" +
                                        "а диапозон значения UserTry от 1 до 4.\n");

                                    #region Ввод числа игроков + формирование массивов
                                    Console.Write("Сколько игроков будут играть? (Минимальное колличество игроков - 2, максимальное - 10)\n" +
                                        "Введите колличество:");

                                do
                                {
                                    amount_users = int.Parse(Console.ReadLine()); // Ввод колличества игроков
                                    if (amount_users < 2 ^ amount_users > 10) Console.Write("Введите ещё раз: ");
                                }
                                while (amount_users < 2 ^ amount_users > 10); // Условия ввода


                                    username = new string[amount_users]; // Формируем массив для имён
                                    usertry = new int[amount_users]; // Формируем массив для вводимых чисел

                                    Console.Clear();
                                    #endregion

                                    #region Знакомство с игроками
                                    Console.WriteLine("Давайте познакомимся!");

                                    for (int i = 0; i < username.Length; i++) // Знакомимся с игроками
                                    {
                                        Console.Write($"Игрок {i + 1} введите своё имя:");
                                        username[i] = Console.ReadLine();
                                    }

                                    Console.WriteLine("\nИ так начнём!");
                                #endregion

                                    #region Процесс игры
                                while (select_realgame != 2) // Цикл для того, чтобы сделать возможным реванш
                                {

                                    gameNumber = number.Next(12, 120); // Генерируем случайное число
                                    Console.WriteLine($"Текущие значение gameNumber = {gameNumber}");

                                    while (gameNumber != 0)
                                    {

                                        for (int i = 0; i < username.Length; i++)
                                        {
                                            Console.Write($"{username[i]}, введите число: ");

                                            do
                                            {
                                                usertry[i] = int.Parse(Console.ReadLine());
                                                if (usertry[i] < 1 ^ usertry[i] > 4) // Условия ввода в правильном диапозоне
                                                {
                                                    flag = false;
                                                    Console.Write("Введите ещё раз: ");
                                                }

                                                else if (usertry[i] > gameNumber) // Условия чтоб не привышало значения gamenumber
                                                {
                                                    flag = false;
                                                    Console.Write("Введите ещё раз: ");
                                                }
                                                else flag = true; // Выход из цикла
                                            }
                                            while (!flag);

                                            gameNumber -= usertry[i]; // Если пользователей не ошибся

                                            if (gameNumber == 0) // Условия победы
                                            {
                                                Console.WriteLine($"Поздравляю Вас {username[i]} ВЫ ПОБЕДИЛИ!!!");
                                                break;
                                            }

                                            else Console.WriteLine($"\nТекущие значение gameNumber = {gameNumber}");
                                        }
                                    }
                                    Console.ReadKey();
                                    #endregion

                                    #region Реванш
                                    Console.Clear();
                                    Console.WriteLine("Желаете сыграть ещё раз?\n" +
                                        "1 - да                 2 - Выход в главное меню");

                                    do
                                    {
                                        select_realgame = int.Parse(Console.ReadLine()); // Пользователь делает выбор
                                        if (select_realgame < 1 ^ select_realgame > 2) Console.Write("Введите ещё раз: ");
                                    }
                                    while (select_realgame < 1 ^ select_realgame > 2);
                                }
                                #endregion

                                #endregion
                                break;

                            case 2: // Уровень сложности проффесионал
                                #region 
                                select_realgame = 1; // Если с главного меню повторно захотят зайти

                                Console.Clear();
                                Console.WriteLine("Вы выбрали уровень сложности проффесионал\n" +
                                    "В это режиме игры значение gameNumber выбирается из диапозона указаным пользователем,\n" +
                                    "а диапозон значения UserTry начинается с 1 и заканчивается числом выбранным пользователем.\n" +
                                    "Если игрок вводит число вне диапозона, то он пропускает ход.\n");

                                #region Ввод числа игроков + формирование массивов
                                Console.Write("Сколько игроков будут играть? (Минимальное колличество игроков - 2, максимальное - 10)\n" +
                                    "Введите колличество:");

                                do
                                {
                                    amount_users = int.Parse(Console.ReadLine()); // Ввод колличества игроков
                                    if (amount_users < 2 ^ amount_users > 10) Console.Write("Введите ещё раз: ");
                                }
                                while (amount_users < 2 ^ amount_users > 10); // Условия ввода

                                username = new string[amount_users]; // Формируем массив для имён
                                usertry = new int[amount_users]; // Формируем массив для вводимых чисел

                                Console.Clear();
                                #endregion

                                #region Знакомство с игроками
                                Console.WriteLine("Давайте познакомимся!");

                                for (int i = 0; i < username.Length; i++) // Знакомимся с игроками
                                {
                                    Console.Write($"Игрок {i + 1} введите своё имя:");
                                    username[i] = Console.ReadLine();
                                }
                                #endregion

                                #region Процесс игры, установка парамметров gamenumber и usertry
                                while (select_realgame != 2) // Цикл для того, чтобы сделать возможным реванш
                                {
                                    Console.WriteLine("\nДавайте устоновим диапозон значения gameNumber:");
                                    Console.Write("Минимальное значение (Должно быть больше нуля): ");

                                    do // Проверяем правильность ввода
                                    {
                                        min_gameNumber = int.Parse(Console.ReadLine()); // Вводим минимальное значение gamenumber
                                        if (min_gameNumber <= 0) Console.Write("Введите ещё раз: ");
                                    }
                                    while (min_gameNumber <= 0);


                                    Console.Write("Максимальное значение: ");

                                    do // Проверяем правильность ввода
                                    {
                                        max_game_Number = int.Parse(Console.ReadLine()); // Вводим максимальное значение gamenumber
                                        if (max_game_Number < min_gameNumber) Console.Write("Введите ещё раз: ");
                                    }
                                    while (max_game_Number < min_gameNumber);

                                    Console.WriteLine("\nТеперь устоновим максимальное значение UserTry:");
                                    Console.Write("Максимальное значение UserTry: ");

                                    do // Проверяем правильность ввода
                                    {
                                        max_usertry = int.Parse(Console.ReadLine()); // Вводим максимальное значение usertry
                                        if (max_usertry <= 1) Console.Write("Введите ещё раз: ");
                                    }
                                    while (max_usertry <= 1);

                                    Console.WriteLine("\nИ так начнём!");

                                    gameNumber = number.Next(min_gameNumber, max_game_Number); // Генерируем случайное число
                                    Console.WriteLine($"\nТекущие значение gameNumber = {gameNumber}");

                                    while (gameNumber != 0)
                                    {
                                        for (int i = 0; i < username.Length; i++)
                                        {
                                            Console.Write($"{username[i]}, введите число: ");
                                            usertry[i] = int.Parse(Console.ReadLine());

                                            if (usertry[i] < 1 ^ usertry[i] > max_usertry) // Условия ввода в нужном диапозоне usertry
                                            {
                                                Console.WriteLine($"За нарушение правил {username[i]}, Вы пропускаете ход!!!\n");
                                                continue; //игрок пропускает ход
                                            }

                                            else if (usertry[i] > gameNumber) // Условия чтоб не привышало значения gamenumber
                                            {
                                                Console.WriteLine($"За нарушение правил {username[i]}, Вы пропускаете ход!!!\n");
                                                continue; //игрок пропускает ход
                                            }

                                            else gameNumber -= usertry[i]; // Если пользователей не ошибся

                                            if (gameNumber == 0) // Условия победы
                                            {
                                                Console.WriteLine($"Поздравляю Вас {username[i]} ВЫ ПОБЕДИЛИ!!!");
                                                break;
                                            }

                                            else Console.WriteLine($"\nТекущие значение gameNumber = {gameNumber}");
                                        }
                                    }
                                    Console.ReadKey();
                                    #endregion

                                    #region Реванш
                                    Console.Clear();
                                    Console.WriteLine("Желаете сыграть ещё раз?\n" +
                                        "1 - да                 2 - Выход в главное меню");

                                    do
                                    {
                                        select_realgame = int.Parse(Console.ReadLine()); // Пользователь делает выбор
                                        if (select_realgame < 1 ^ select_realgame > 2) Console.Write("Введите ещё раз: ");
                                    }
                                    while (select_realgame < 1 ^ select_realgame > 2);

                                }
                                #endregion

                                #endregion
                                break;
                        }

                        break;
                        #endregion

                    case 2: // Игра с компьютером
                        #region Игра с компьютером

                        #region Выбор уровня сложности
                        Console.WriteLine("\nВы выбрали игру с компьютером, давайте выберем уровень сложности:\n" +
                            "1 - Новичок\n" +
                            "2 - Проффесионал");

                        do
                        {
                            select_level = int.Parse(Console.ReadLine()); // Выбор уровня сложности
                            if (select_level < 1 ^ select_level > 2) Console.Write("Введите ещё раз: ");
                        }
                        while (select_level < 1 ^ select_level > 2); // Условия ввода

                    #endregion

                        switch (select_level)
                        {
                            case 1: // Уровень сложности новичок
                                #region
                                select_PCgame = 1; // Сброс переменной выбора
                                Console.Clear();
                                Console.WriteLine("Вы выбрали уровень сложности новичок\n" +
                                    "В это режиме игры значение gameNumber находится в диапозоне от 12 до 120,\n" +
                                    "а диапозон значения UserTry от 1 до 4.\n" +
                                    "В случае неправильного ввода компьютера, он пропускает ход\n");

                                username = new string[2]; // Формируем массив для имён
                                usertry = new int[2]; // Формируем массив для вводимых чисел

                                #region Знакомство с игроком
                                Console.WriteLine("Давайте познакомимся!");

                                    Console.Write("Игрок 1 введите своё имя:");
                                    username[0] = Console.ReadLine();

                                Console.WriteLine("\nИ так начнём!");
                                #endregion

                                #region Процесс игры
                                while (select_PCgame != 2) // Цикл для возможности реванша
                                {
                                    gameNumber = number.Next(12, 120); // Генерируем gamenumber
                                    Console.WriteLine($"\nТекущие значение gameNumber = {gameNumber}");

                                    while (gameNumber != 0)
                                    {
                                        for(; ; )
                                        {
                                            Console.Write($"{username[0]}, введите число: ");

                                            do
                                            {
                                                usertry[0] = int.Parse(Console.ReadLine());
                                                if (usertry[0] < 1 ^ usertry[0] > 4) // Условия ввода в правильном диапозоне
                                                {
                                                    flag = false;
                                                    Console.Write("Введите ещё раз: ");
                                                }

                                                else if (usertry[0] > gameNumber) // Условия чтоб не привышало значения gamenumber
                                                {
                                                    flag = false;
                                                    Console.Write("Введите ещё раз: ");
                                                }
                                                else flag = true; // Выход из цикла
                                            }
                                            while (!flag);

                                            gameNumber -= usertry[0];

                                            if (gameNumber == 0) // Условия победы
                                            {
                                                Console.WriteLine($"Поздравляю Вас {username[0]} Вы победили!!!");
                                                break;
                                            }

                                            else Console.WriteLine($"\nТекущие значение gameNumber = {gameNumber}");

                                            usertry[1] = number.Next(1, 6); // usertry компьютера
                                            Console.WriteLine($"ПК ввёл число: {usertry[1]}");

                                            if(usertry[1] < 1 ^ usertry[1] > 4) // Проверка диапозона usertry
                                            {
                                                Console.WriteLine("\nЗа нарушение правил ПК пропускает ход!!!");
                                                continue;
                                            }

                                            else if (usertry[1] > gameNumber) // Условия чтоб не привышало значения gamenumber
                                            {
                                                Console.WriteLine("\nЗа нарушение правил ПК пропускает ход!!!");
                                                continue;
                                            }

                                            else gameNumber -= usertry[1];

                                            if (gameNumber == 0) // Условия победы
                                            {
                                                {
                                                    Console.WriteLine("ПК Пбедил!!!");
                                                    break;
                                                }
                                            }
                                            else Console.WriteLine($"\nТекущие значение gameNumber = {gameNumber}");
                                        }
                                        Console.ReadKey();
                                        #endregion

                                        #region Реванш
                                        Console.Clear();
                                        Console.WriteLine("Желаете сыграть ещё раз?\n" +
                                            "1 - да                 2 - Выход в главное меню");

                                        do
                                        {
                                            select_PCgame = int.Parse(Console.ReadLine()); // Пользователь делает выбор
                                            if (select_PCgame < 1 ^ select_PCgame > 2) Console.Write("Введите ещё раз: ");
                                        }
                                        while (select_PCgame < 1 ^ select_PCgame > 2);
                                        #endregion
                                    }
                                }
                                #endregion
                                break;

                            case 2: // Уровень сложности проффесионал
                                #region
                                select_PCgame = 1; // Если с главного меню повторно захотят зайти

                                Console.Clear();
                                Console.WriteLine("Вы выбрали уровень сложности проффесионал\n" +
                                    "В это режиме игры значение gameNumber выбирается из диапозона указаным пользователем,\n" +
                                    "а диапозон значения UserTry начинается с 1 и заканчивается числом выбранным пользователем.\n");
                                    

                                username = new string[2]; // Формируем массив для имён
                                usertry = new int[2]; // Формируем массив для вводимых чисел

                                #region Знакомство с игроком
                                Console.WriteLine("Давайте познакомимся!");

                                Console.Write("Игрок 1 введите своё имя:");
                                username[0] = Console.ReadLine();

                                Console.WriteLine("\nИ так начнём!");
                                #endregion

                                #region Процесс игры, установка парамметров gamenumber и usertry  

                                while (select_PCgame != 2) // Цикл для возможности реванша
                                {
                                    Console.WriteLine("\nДавайте устоновим диапозон значения gameNumber:");
                                    Console.Write("Минимальное значение (Должно быть больше нуля): ");

                                    do // Проверяем правильность ввода
                                    {
                                        min_gameNumber = int.Parse(Console.ReadLine()); // Вводим минимальное значение gamenumber
                                        if (min_gameNumber <= 0) Console.Write("Введите ещё раз: ");
                                    }
                                    while (min_gameNumber <= 0);


                                    Console.Write("Максимальное значение: ");

                                    do // Проверяем правильность ввода
                                    {
                                        max_game_Number = int.Parse(Console.ReadLine()); // Вводим максимальное значение gamenumber
                                        if (max_game_Number < min_gameNumber) Console.Write("Введите ещё раз: ");
                                    }
                                    while (max_game_Number < min_gameNumber);

                                    Console.WriteLine("\nТеперь устоновим максимальное значение UserTry:");
                                    Console.Write("Максимальное значение UserTry: ");

                                    do // Проверяем правильность ввода
                                    {
                                        max_usertry = int.Parse(Console.ReadLine()); // Вводим максимальное значение usertry
                                        if (max_usertry <= 1) Console.Write("Введите ещё раз: ");
                                    }
                                    while (max_usertry <= 1);

                                    Console.WriteLine("\nИ так начнём!");

                                    gameNumber = number.Next(min_gameNumber, max_game_Number); // Генерируем случайное число
                                    Console.WriteLine($"\nТекущие значение gameNumber = {gameNumber}");

                                    while (gameNumber != 0)
                                    {
                                        for (; ; )
                                        {
                                            Console.Write($"{username[0]}, введите число: ");

                                            do
                                            {
                                                usertry[0] = int.Parse(Console.ReadLine());
                                                if (usertry[0] < 1 ^ usertry[0] > max_usertry) // Условия ввода в правильном диапозоне
                                                {
                                                    flag = false;
                                                    Console.Write("Введите ещё раз: ");
                                                }

                                                else if (usertry[0] > gameNumber) // Условия чтоб не привышало значения gamenumber
                                                {
                                                    flag = false;
                                                    Console.Write("Введите ещё раз: ");
                                                }
                                                else flag = true; // Выход из цикла
                                            }
                                            while (!flag);

                                            gameNumber -= usertry[0];

                                            if (gameNumber == 0) // Условия победы
                                            {
                                                Console.WriteLine($"Поздравляю Вас {username[0]} Вы победили!!!");
                                                break;
                                            }

                                            else Console.WriteLine($"\nТекущие значение gameNumber = {gameNumber}");

                                            usertry[1] = number.Next(1, max_usertry+1); // usertry компьютера
                                            Console.WriteLine($"ПК ввёл число: {usertry[1]}");

                                            if (max_usertry >= gameNumber) // Компьютер может победить и уже не случайно
                                            {
                                                flag = false;
                                                while (!flag)
                                                {
                                                    usertry[1] = number.Next(1, max_usertry+1); // usertry компьютера
                                                    result_PC = gameNumber - usertry[1];
                                                    if (result_PC == 0)
                                                    {
                                                        gameNumber -= usertry[1];
                                                        flag = true;
                                                    }
                                                    else flag = false;
                                                }
                                            }

                                            else gameNumber -= usertry[1];

                                            if (gameNumber == 0) // Условия победы
                                            {
                                                {
                                                    Console.WriteLine("ПК Победил!!!");
                                                    break;
                                                }
                                            }
                                            else Console.WriteLine($"\nТекущие значение gameNumber = {gameNumber}");
                                        }
                                        Console.ReadKey();
                                        #endregion

                                        #region Реванш
                                        Console.Clear();
                                        Console.WriteLine("Желаете сыграть ещё раз?\n" +
                                            "1 - да                 2 - Выход в главное меню");

                                        do
                                        {
                                            select_PCgame = int.Parse(Console.ReadLine()); // Пользователь делает выбор
                                            if (select_PCgame < 1 ^ select_PCgame > 2) Console.Write("Введите ещё раз: ");
                                        }
                                        while (select_PCgame < 1 ^ select_PCgame > 2);
                                        #endregion
                                    }
                                }
                                #endregion
                                break;
                        }

                        break;

                    #endregion

                    case 3: // Выход из программы
                        #region Выход из программы
                        Console.WriteLine("Жаль что покидаете игру");
                        break;
                        #endregion

                    default: 
                        Console.WriteLine("Попробуйте ввести ещё раз");
                        break;
                }
            }

            Console.ReadKey();
        }
    }
}
