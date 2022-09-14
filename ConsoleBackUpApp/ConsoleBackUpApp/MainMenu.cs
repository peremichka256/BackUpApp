using System;

namespace ConsoleBackUpApp
{
    /// <summary>
    /// Класс главного меню
    /// </summary>
    public class MainMenu
    {
        static void Main()
        {
            bool isExitFromWhile = true;

            while (isExitFromWhile)
            {
                Config userConfig = Config.Load();
                Console.WriteLine("________________________MENU________________________\n");
                Console.WriteLine("|Нажмите 1, чтобы изменить путь сохраняемого файла  |" +
                                  "=>" + userConfig.SourceFolder + "\n");
                Console.WriteLine("|Нажмите 2, чтобы изменить путь целевой папки       |" +
                                  "=>" + userConfig.TargetFolder + "\n");
                Console.WriteLine("|Нажмите 3, для копирования файла в архив           |\n");
                Console.WriteLine("|Нажмите 4, для завершения работы                   |\n");
                Console.WriteLine("|___________________________________________________|\n");

                var menuString = Int32.TryParse(Console.ReadLine(), out var menuButton);

                switch (menuButton)
                {
                    case 1:
                    {
                        Console.Clear();
                        Console.WriteLine("Введите путь до сохраняемого файла\n");
                        userConfig.SourceFolder = Console.ReadLine();
                        userConfig.Save();
                        break;
                    }
                    case 2:
                    {
                        Console.Clear();
                        Console.WriteLine("Введите путь до целевой папки\n");
                        userConfig.TargetFolder = Console.ReadLine();
                        userConfig.Save();
                        break;
                    }
                    case 3:
                    {
                        Console.Clear();
                        if (!BackUpProcess.IsSaving(userConfig.SourceFolder,
                                userConfig.TargetFolder))
                        {
                            Console.WriteLine("Какой-то из путей не был введен корректно" +
                                              " или некоторый файлы уже перенесены");
                        }
                        else
                        {
                            Console.WriteLine("Данные были успешно перенесены");
                        }
                        break;
                    }
                    case 4:
                    {
                        Console.Clear();
                        Console.WriteLine("Work is completing!");
                        return;
                    }
                    default:
                    {
                        Console.Clear();
                        Console.WriteLine("Такого варианта нет.");
                        break;
                    }
                }
            }
        }
    }
}