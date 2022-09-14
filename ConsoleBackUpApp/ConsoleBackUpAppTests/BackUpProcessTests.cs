using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleBackUpApp;
using NUnit.Framework;

namespace ConsoleBackUpAppTests
{
    [TestFixture]
    internal class BackUpProcessTests
    {
        /// <summary>
        /// Поле с путем до исходной директории
        /// </summary>
        private string sourceFolder = ".\\Source";

        /// <summary>
        /// Поле с путем до целевой директории
        /// </summary>
        private string targetFolder = ".\\Target";

        /// <summary>
        /// Поле с путе до исходного файла
        /// </summary>
        private string sourceFile = ".\\Source\\File.txt";

        /// <summary>
        /// Поле с путем до скопированного файла
        /// </summary>
        private string copyFile = ".\\Target\\File.txt";

        [Test(Description = "Позитивный тест на копирование")]
        public void TestSaving_Positive()
        {
            CreateTestData();
            BackUpProcess.IsSaving(sourceFolder, targetFolder);

            Assert.IsTrue(File.Exists(sourceFile), "Файл не был перенесен в целевую папку");
            File.Delete(copyFile);
        }

        [Test(Description = "Негативный тест на копирование")]
        public void TestSaving_Negative()
        {
            var notExistFolder = ".\\NotExistFolder";
            BackUpProcess.IsSaving(notExistFolder, targetFolder);

            Assert.IsFalse(BackUpProcess.IsSaving(notExistFolder, targetFolder),
                "Был загружен файл из несуществующей директории");
            File.Delete(copyFile);
        }

        /// <summary>
        /// Создание тестовых директорий и файлов
        /// </summary>
        private void CreateTestData()
        {
            File.Delete(copyFile);
            Directory.CreateDirectory(sourceFolder);
            Directory.CreateDirectory(targetFolder);
            File.Create(sourceFile);
        }
    }
}
