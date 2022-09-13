using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;

namespace ConsoleBackUpApp
{
    /// <summary>
    /// Класс осуществляющий сохранение файлов
    /// </summary>
    public static class BackUpProcess
    {
        /// <summary>
        /// Путь до архива в который сохраняются исходные файлы
        /// </summary>
        public const string tempZipFile = ".\\Temp.zip";

        /// <summary>
        /// Метод осуществляющий копирование из исходной папки в целевую
        /// </summary>
        /// <param name="sourceFolder">Путь до исходной папки</param>
        /// <param name="targetFolder">Путь до целевой папки</param>
        /// <returns>Результат выполнения метода</returns>
        public static string Saving(string sourceFolder, string targetFolder)
        {
            if (Directory.Exists(sourceFolder) && Directory.Exists(targetFolder))
            {
                File.Delete(tempZipFile);
                ZipFile.CreateFromDirectory(sourceFolder, tempZipFile);
                ZipFile.ExtractToDirectory(tempZipFile, targetFolder);
                return "The file was successfully copied";
            }
            return "The file not exist";
        }
    }
}
