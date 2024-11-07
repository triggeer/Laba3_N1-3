using System;


namespace Laba3_N1_3
{
    class Program
    {
        static void Main(string[] args)
        {
            //задания с 1 по 3
            int n1 = Proverka.IntNum("Введите число строк: ");
            int m1 = Proverka.IntNum("Введите число столбцов: ");
            Array matr1 = new Array(n1, m1);
            Console.WriteLine(matr1);

            int n2 = Proverka.IntNum("Введите порядок матрицы 2: ");
            Array matr2 = new Array(n2);
            Console.WriteLine(matr2);

            int n3 = Proverka.IntNum("Введите порядок матрицы 3: ");
            Array matr3 = new Array(n3, true);
            Console.WriteLine(matr3);

            //Console.WriteLine(matr1.MaxSum());
            int n4 = Proverka.IntNum("Введите кол-во строк массива А: ");
            int m4 = Proverka.IntNum("Введите кол-во столбцов массива А: ");

            int n5 = Proverka.IntNum("Введите кол-во строк массива B: ");
            int m5 = Proverka.IntNum("Введите кол-во столбцов массива B: ");

            int n6 = Proverka.IntNum("Введите кол-во строк массива C: ");
            int m6 = Proverka.IntNum("Введите кол-во столбцов массива C: ");

            if (n4 == m5 && m5 == n6 && m4 == n5 && n5 == m6)
            {
                Array a = new Array(n4, m4);
                Console.WriteLine(a.TransponM());
                Array b = new Array(n5, m5);
                Console.WriteLine(b * 2);
                Array c = new Array(n6, m6);
                Console.WriteLine(c.TransponM());
                Console.WriteLine("Результат выполнения Ат+2*В+Ст: ");
                Console.WriteLine(a.TransponM() + b * 2 + c.TransponM());
            }
            else
            {
                Console.WriteLine("При введённых размерностях матриц невозможно вычислить Ат+2*В+Cт");
            }

            //задания с 4 оп 8
            FileProcessor.ProcessFileWithUserInput(); //Получить в новом файле все компоненты исходного файла, которые делятся на m и не делятся на n.

            MinMaxDiff.ShowMinMaxDiff(); //разница между максимальным и минимальным

            MinEl.ShowMin(); //минимальный элемент

            StartLeter.WriteLineL(); //строки с символа
        }
    }
}
