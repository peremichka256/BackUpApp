using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsoleBackUpApp
{
    /// <summary>
    /// Класс файла настройки
    /// </summary>
    public class Config
    {
        /// <summary>
        /// Путь по которому хранятся настройки
        /// </summary>
        public const string configFolder = ".\\Config.notes";

        /// <summary>
        /// Путь до исходной папки
        /// </summary>
        private string _sourceFolder;

        /// <summary>
        /// Путь до целевой папки
        /// </summary>
        private string _targetFolder;

        /// <summary>
        /// Путь до исходной папки
        /// </summary>
        public string SourceFolder
        {
            get { return _sourceFolder; }
            set
            {
                _sourceFolder = value;

                if (_sourceFolder != null)
                {
                    _sourceFolder = value.Replace("\"", "");
                }
            }
        }

        /// <summary>
        /// Путь до целевой папки
        /// </summary>
        public string TargetFolder
        {
            get { return _targetFolder; }
            set
            {
                _targetFolder = value;

                if (_targetFolder != null)
                {
                    _targetFolder = value.Replace("\"", "");
                }
            }
        }

        /// <summary>
        /// Сохраняет объект <see cref="Config"/>
        /// </summary>
        /// <param name="config">Сохраняемый объект</param>
        public static void Save(Config config)
        {
            if (!Directory.Exists(Path.GetDirectoryName(configFolder)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(configFolder));
            }
            JsonSerializer jsonSerializer = new JsonSerializer();

            using (StreamWriter stream = new StreamWriter(configFolder))
            using (JsonWriter writer = new JsonTextWriter(stream))
            {
                jsonSerializer.Serialize(writer, config);
            }
        }

        /// <summary>
        /// Загружает из файла объект <see cref="Config"/>
        /// </summary>
        /// <returns>Загруженный объект <see cref="Config"/></returns>
        public static Config Load()
        {
            Config config = new Config();

            if (!File.Exists(configFolder))
            {
                return config;
            }
            
            using (StreamReader stream = new StreamReader(configFolder))
            {
                string userConfig = stream.ReadLine();

                if (string.IsNullOrEmpty(userConfig))
                {
                    return config;
                }

                try
                {
                    config = JsonConvert.DeserializeObject<Config>(userConfig);
                }
                catch (Newtonsoft.Json.JsonReaderException)
                {
                    return config;
                }
            }
            return config;
        }

        /// <summary>
        /// Стандартный конструктор класса
        /// </summary>
        private Config()
        {
            SourceFolder = null;
            TargetFolder = null;
        }
    }
}
