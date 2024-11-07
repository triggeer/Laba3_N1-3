using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba3_N1_3
{
    internal class MinEl
    {
        public static void ShowMin()
        {
            string inputPath = "txte4.txt";
            string outputPath = "newFile.txt";

            FindMin(inputPath, outputPath);
        }

        public static void FindMin(string inputPath, string outputPath)
        {
            try
            {
                int minnum = int.MaxValue;

                using (StreamReader sr = new StreamReader(inputPath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (int.TryParse(line, out int num))
                        {
                            if (num < minnum)
                            {
                                minnum = num;
                            }
                        }
                    }
                }
                using (StreamWriter sw = new StreamWriter(outputPath))
                {
                    sw.WriteLine("Минимальный элемент: " + minnum);
                }

                Console.WriteLine("Результат записан в файл: " + outputPath);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Файл " + inputPath + " не найден");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
        }
    }
}
