using System;
using INIManager;

namespace MIREAConfigMPW2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (!InitConfig())
                return;

            Console.WriteLine("Repository.Source: " + Global.Repository.Source);
            Console.WriteLine("Repository.TestMode: " + Global.Repository.TestMode);
            Console.WriteLine("Package.Name: " + Global.Package.Name);
            Console.WriteLine("Package.Version: " + Global.Package.Version);
            Console.WriteLine("Output.GraphPath: " + Global.GraphPath);
        }

        /// <summary>
        /// Инициализация конфига
        /// </summary>
        /// <returns>true - если успешно, иначе false</returns>
        private static bool InitConfig()
        {
            var iniManager = new HubManager(Directory.GetCurrentDirectory() + "\\config.ini");

            if (File.Exists(Directory.GetCurrentDirectory() + "\\config.ini"))
            {
                if (iniManager.KeyExists("Repository", "Source")
                    && iniManager.KeyExists("Repository", "TestMode")
                    && iniManager.KeyExists("Package", "Name")
                    && iniManager.KeyExists("Package", "Version")
                    && iniManager.KeyExists("Output", "GraphPath"))
                {
                    Global.Repository.Source = iniManager.GetString("Repository", "Source");

                    bool testMode;
                    if (!bool.TryParse(iniManager.GetString("Repository", "TestMode"), out testMode))
                    { 
                        Console.WriteLine("Ключ TestMode содержит некорректное значение"); 
                        return false; 
                    }
                    Global.Repository.TestMode = testMode;

                    Global.Package.Name = iniManager.GetString("Package", "Name");
                    Global.Package.Version = iniManager.GetString("Package", "Version");
                    Global.GraphPath = iniManager.GetString("Output", "GraphPath");

                    return true;
                }
                else
                    Console.WriteLine("Файл конфигурации имеет некорректную структуру");
            }
            else
                Console.WriteLine("Файл конфигурации config.ini отсутствует");

            return false;
        }
    }
}
