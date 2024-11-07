//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Laba3_N1_3
//{
//    internal class StartLeter
//    {
//        public static void WriteLineL()
//        {
//            string inputPath = "txte4.txt";
//            string outputPath = "newFile.txt";

//            char a = ProverkaBukv.Char("Введите символ, с которого начинаются строки файла, которые вы хотите перенести в новый: ");
//            //int a = Proverka.IntNum("Введите символ, с которого начинаются строки файла, которые вы хотите перенести в новый: ");

//            FindAndWriteToFile(inputPath, outputPath, a);
//        }

//        public static void FindAndWriteToFile(string inputPath, string outputPath, char a)
//        {
//            try
//            {
//                using (StreamReader sr = new StreamReader(inputPath))
//                {
//                    using (StreamWriter sw = new StreamWriter(outputPath))
//                    {
//                        string line;
//                        while ((line = sr.ReadLine()) != null)
//                        {
//                            //string[] lines = line.Split(' ');


//                                if (line[0]  == a)
//                                {
//                                    sw.WriteLine(line + "\n");
//                                }
                            
//                        }    
//                    }
//                }
//                Console.WriteLine("Данные записаны в файл " + outputPath);
//            }
//            catch (FileNotFoundException)
//            {
//                Console.WriteLine("Файл " + inputPath + " не найден.");
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine("Произошла ошибка: " + ex.Message);
//            }
//        }
//    }
//}



using System;
using System.IO;

namespace Laba3_N1_3
{
    internal class StartLeter
    {
        public static void WriteLineL()
        {
            string inputPath = "txte4.txt";
            string outputPath = "newFile.txt";

            // Получаем символ, с которого должны начинаться строки
            char a = ProverkaBukv.Char("Введите символ, с которого начинаются строки файла, которые вы хотите перенести в новый: ");

            // Запускаем метод поиска и записи строк, начинающихся с заданного символа
            FindAndWriteToFile(inputPath, outputPath, a);
        }

        public static void FindAndWriteToFile(string inputPath, string outputPath, char a)
        {
            try
            {
                using (StreamReader sr = new StreamReader(inputPath))
                {
                    using (StreamWriter sw = new StreamWriter(outputPath))
                    {
                        string line;
                        // Читаем файл построчно
                        while ((line = sr.ReadLine()) != null)
                        {
                            // Проверяем, начинается ли строка с заданного символа
                            if (line[0] == a)
                            {
                                // Записываем строку в новый файл, если она начинается с символа 'a'
                                sw.WriteLine(line);
                            }
                        }
                    }
                }
                Console.WriteLine("Данные записаны в файл " + outputPath);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Файл " + inputPath + " не найден.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Произошла ошибка: " + ex.Message);
            }
        }
    }
}