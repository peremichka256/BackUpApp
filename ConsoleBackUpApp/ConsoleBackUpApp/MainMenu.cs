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
                Console.WriteLine("|Нажмите 4, чтобы вывести логи                      |\n");
                Console.WriteLine("|Нажмите 5, для завершения работы                   |\n");
                Console.WriteLine("|___________________________________________________|\n");
                var menuButton = Int32.Parse(Console.ReadLine());

                switch (menuButton)
                {
                    case 1:
                    {
                        Console.Clear();
                        Console.WriteLine("Введите путь до сохраняемого файла\n");
                        userConfig.SourceFolder = Console.ReadLine();
                        Config.Save(userConfig);
                        break;
                    }
                    case 2:
                    {
                        Console.Clear();
                        Console.WriteLine("Введите путь до целевой папки\n");
                        userConfig.TargetFolder = Console.ReadLine();
                        Config.Save(userConfig);
                        break;
                    }
                    case 3:
                    {
                        Console.Clear();
                        BackUpProcess.Saving(userConfig.SourceFolder, userConfig.TargetFolder);
                        break;
                    }
                    case 4:
                    {
                        Console.Clear();
                        break;
                    }
                    case 5:
                    {
                        Console.Clear();
                        Console.WriteLine("Work is completing!");
                        return;
                    }
                    default:
                    {
                        Console.WriteLine("Такого варианта нет.");
                        break;
                    }
                }
            }
        }
    }
}