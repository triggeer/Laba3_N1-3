using System;
using System.IO;

namespace Laba3_N1_3
{
    internal class MinMaxDiff
    {
        public static void ShowMinMaxDiff()
        {
            string inputPath = "txte4.txt";
            string outputPath = "newFile.txt";

            FindMinMaxDiff(inputPath, outputPath);
        }

        // Метод для нахождения разности максимального и минимального значения в файле
        public static void FindMinMaxDiff(string inputPath, string outputPath)
        {
            try
            {
                int maxnum = int.MinValue; // Начальное значение для поиска максимума
                int minnum = int.MaxValue; // Начальное значение для поиска минимума

                // Открываем файл для чтения
                using (StreamReader sr = new StreamReader(inputPath))
                {
                    string line;
                    // Читаем файл построчно
                    while ((line = sr.ReadLine()) != null)
                    {
                        // Преобразуем строку в число
                        if (int.TryParse(line, out int num))
                        {
                            // Проверяем, является ли число текущим максимумом или минимумом
                            if (num > maxnum)
                            {
                                maxnum = num;
                            }
                            if (num < minnum)
                            {
                                minnum = num;
                            }
                        }
                    }
                }

                // Вычисляем разность между максимальным и минимальным значением
                int diff = maxnum - minnum;

                // Записываем результат в выходной файл
                using (StreamWriter sw = new StreamWriter(outputPath))
                {
                    sw.WriteLine("Разность между максимальным и минимальным элементами: " + diff);
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