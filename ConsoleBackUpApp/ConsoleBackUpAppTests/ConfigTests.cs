using ConsoleBackUpApp;
using NUnit.Framework;
using System;
using System.Reflection;
using System.IO;
using Microsoft.VisualBasic.FileIO;


namespace ContactsAppUnitTests
{
    [TestFixture]
    public class ConfigTests
    {
        [Test(Description = "Попытка сохранения файла в несуществующую директорию")]
        public void TestSave_NotExistDirectroy()
        {
            Config testConfig = Config.Load();
            var testDirName = Path.GetDirectoryName(Config.ConfigFolder);
            var dirInfo = new DirectoryInfo(testDirName);

            if (dirInfo.Exists)
            {
                dirInfo.Delete(true);
            }

            testConfig.Save();

            Assert.IsTrue(dirInfo.Exists, 
                "Не была создана директория и файл при сохранении настроек");
        }

        [Test(Description = "Попытка загрузки несуществующего файла")]
        public void TestLoad_NotExistFile()
        {
            if (File.Exists(Config.ConfigFolder))
            {
                File.Delete(Config.ConfigFolder);
            }

            var testConfig = Config.Load();
            Assert.IsNotNull(testConfig,
                "После удаления файла с настройками не был" +
                " создан новый объект класса Config");
        }

        [Test(Description = "Загрузка после удаления файла настроек")]
        public void TestLoad_Positive()
        {
            File.Delete(Config.ConfigFolder);
            var testConfig = Config.Load();

            Assert.IsNotNull(testConfig, "При удалении файла " +
                                         "не был создан новый");
        }

        [Test(Description = "Позитивный тест на свойства путей")]
        public void TestSourceAndTargetFolder_Positive()
        {
            var testConfig = Config.Load();
            var testStringWith = "\"qwe\"";
            var testStringWithout = "qwe";
            testConfig.SourceFolder = testStringWith;
            testConfig.TargetFolder = testStringWith;

            Assert.IsTrue((testConfig.TargetFolder == testStringWithout)
                          &&(testConfig.SourceFolder == testStringWithout),
                "Кавычки не былы удалены из пути");
        }
    }
}
