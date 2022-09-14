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
        [Test(Description = "������� ���������� ����� � �������������� ����������")]
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
                "�� ���� ������� ���������� � ���� ��� ���������� ��������");
        }

        [Test(Description = "������� �������� ��������������� �����")]
        public void TestLoad_NotExistFile()
        {
            if (File.Exists(Config.ConfigFolder))
            {
                File.Delete(Config.ConfigFolder);
            }

            var testConfig = Config.Load();
            Assert.IsNotNull(testConfig,
                "����� �������� ����� � ����������� �� ���" +
                " ������ ����� ������ ������ Config");
        }

        [Test(Description = "�������� ����� �������� ����� ��������")]
        public void TestLoad_Positive()
        {
            File.Delete(Config.ConfigFolder);
            var testConfig = Config.Load();

            Assert.IsNotNull(testConfig, "��� �������� ����� " +
                                         "�� ��� ������ �����");
        }

        [Test(Description = "���������� ���� �� �������� �����")]
        public void TestSourceAndTargetFolder_Positive()
        {
            var testConfig = Config.Load();
            var testStringWith = "\"qwe\"";
            var testStringWithout = "qwe";
            testConfig.SourceFolder = testStringWith;
            testConfig.TargetFolder = testStringWith;

            Assert.IsTrue((testConfig.TargetFolder == testStringWithout)
                          &&(testConfig.SourceFolder == testStringWithout),
                "������� �� ���� ������� �� ����");
        }
    }
}
