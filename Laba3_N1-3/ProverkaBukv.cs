using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba3_N1_3
{
    internal class ProverkaBukv
    {
        public static char Char(string message)
        {
            char value;
            while (true)
            {
                Console.Write(message); // Запрашиваем ввод в каждой итерации
                string input = Console.ReadLine();

                if (char.TryParse(input, out value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine("Ошибка ввода");
                }
            }
        }
    }
}
