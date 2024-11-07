using System;
using System.IO;

namespace Laba3_N1_3
{
    public static class FileProcessor
    {
        // Метод для получения значений m и n от пользователя и запуска фильтрации и записи в файл
        public static void ProcessFileWithUserInput()
        {
            // Пути к файлам
            string inputPath = "txte4.txt";
            string outputPath = "newFile.txt";

            // Получение значений m и n от пользователя
            int m = Proverka.IntNum("Введите значение m: ");
            int n = Proverka.IntNum("Введите значение n: ");

            // Запуск метода фильтрации и записи
            FilterAndWriteToFile(inputPath, outputPath, m, n);
        }

        // Метод для фильтрации чисел и записи их в новый файл
        private static void FilterAndWriteToFile(string inputPath, string outputPath, int m, int n)
        {
            try
            {
                // Открываем файл для чтения
                using (StreamReader sr = new StreamReader(inputPath))
                {
                    // Создаем файл для записи
                    using (StreamWriter sw = new StreamWriter(outputPath))
                    {
                        string line;

                        // Читаем построчно из исходного файла
                        while ((line = sr.ReadLine()) != null)
                        {
                            // Разбиваем строку на отдельные числа
                            string[] numbers = line.Split(' ');

                            foreach (string numStr in numbers)
                            {
                                // Преобразуем строку в число
                                if (int.TryParse(numStr, out int num))
                                {
                                    // Проверяем условия: делится на m и не делится на n
                                    if (num % m == 0 && num % n != 0)
                                    {
                                        // Записываем число в новый файл
                                        sw.Write(num + " ");
                                    }
                                }
                            }

                            // Переход на новую строку после каждой строки из исходного файла
                            //sw.WriteLine();
                        }
                    } // StreamWriter автоматически закрывается
                } // StreamReader автоматически закрывается

                Console.WriteLine("Данные успешно отфильтрованы и записаны в новый файл: " + outputPath);
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