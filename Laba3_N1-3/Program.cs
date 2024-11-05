using System;

class Program
{
    static void Main(string[] args)
    {
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

        Console.WriteLine(matr1.MaxSum());
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
            Console.WriteLine(a.TransponM() + b * 2 + c.TransponM());
        }
        else
        {
            Console.WriteLine("При введённых размерностях матриц невозможно вычислить Ат+2*В+Cт");
        }  
    }
}


class Array
{
    int[,] mat; //двумерный массив

    public int[,] Mat { get => mat; set => mat = value; } //свойство

    public Array(int n, int m) //конструктор 1
    {
        mat = new int[n, m]; //массив n x m

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                mat[j, i] = Proverka.IntNum($"Введите число массива {j + 1}, {i + 1}: "); //вводим значения массива по столбцам
            }
        }
    }

    public Array(int n) //конструктор 2
    {
        Random r = new Random();

        mat = new int[n, n];

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (j < n - i - 1 && i < n - 1)
                {
                    mat[i, j] = r.Next(-12, 4565);
                }
                else
                {
                    mat[i, j] = r.Next(-1024, 1024);
                }
            }
        }
    }

    public Array(int n, bool a) //конструктор 3
    {
        mat = new int[n, n];

        int count = 1;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j <= i; j++)
            {
                mat[n - j - 1, n - i + j - 1] = count++;
            }
        }
    }

    public Array(int[,] mtr) //конструктор преобразует двумерный массив в объект класса Array
    {
        int n = mtr.GetLength(0); //кол-во элементов в n (строки)
        int m = mtr.GetLength(1); //кол-во элементов в m (столбцы)

        mat = new int[n, m];
        for (int i = 0;i < n; i++)
        {
            for (int j = 0;j < m; j++)
            {
                mat[i,j] = mtr[i,j];
            }
        }
    }

    public Array MaxSum()
    {
        int max = int.MinValue; //max = минимальному возможному значению инта
        int maxI = 0;
        int maxJ = 0;
        if (mat.GetLength(0) < 3 || mat.GetLength(1) < 3)
            throw new ArgumentException("Матрица меньше минимальной размерности");
        for (int i = 0; i < mat.GetLength(0) - 2; i++) //mat.GetLength(0) -> кол-во строк
        {
            for (int j = 0; j < mat.GetLength(1) - 2; j++) //mat.GetLength(0) -> кол-во столбцов
            {
                int sum = GetSum(i, j);
                if (sum > max)
                {
                    max = sum;
                    maxI = i;
                    maxJ = j;
                }
            }
        }

        int[,] tempArr= new int[3, 3];

        for (int i = maxI; i<maxI+3; i++)
        {
            for (int j = maxJ; j<maxJ+3; j++)
            {
                tempArr[i-maxI, j-maxJ] = mat[i, j]; 
            }
        }
        return new Array(tempArr);
    }

    int GetSum(int n, int m)
    {
        int sum = 0;
        for (int i = n; i<n+3; i++)
        {
            for (int j = m; j<m+3; j++)
            {
                sum += mat[i, j];
            }
        }
        return sum;
    }


    public override string ToString()
    {
        string str = "";
        for (int i = 0; i < mat.GetLength(0); i++) //mat.GetLength(0) -> кол-во строк
        {
            for (int j = 0; j < mat.GetLength(1); j++) //mat.GetLength(0) -> кол-во столбцов
            {
                str += mat[i, j].ToString().PadLeft(6); //прибавляем число и кол-во пробелов, чтобы по итогу было 6 символов (' -1024' -> 6 символов)
            }
            str += "\n"; //перенос строки
        }
        return str;
    }


    public Array TransponM() //метод транспонирование матриц
    {
        int n = mat.GetLength(0);
        int m = mat.GetLength(1);
        int[,] temparr = new int[m, n];

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                temparr[j, i] = mat[i, j];
            }
        }
        return new Array(temparr);
    }

    public static Array operator *(Array arr, int mult) //перегрузка *
    {
        int n = arr.mat.GetLength(0);
        int m = arr.mat.GetLength(1);
        int[,] newArr = new int[n, m];

        for (int i = 0; i < n; i++)
            for (int j = 0; j < m; j++)
                newArr[i, j] = arr.mat[i, j] * mult;

        return new Array(newArr);
    }

    public static Array operator +(Array arr1, Array arr2) //перегрузка +
    {
        int n1 = arr1.mat.GetLength(0);
        int m1 = arr1.mat.GetLength(1);
        
        int n2 = arr2.mat.GetLength(0);
        int m2 = arr2.mat.GetLength(1);
        int[,] newArr = new int[n1, m1];
        for (int i = 0; i < n1; i++)
            for (int j = 0; j < m1; j++)
                newArr[i, j] = arr1.mat[i, j] + arr2.mat[i, j];
 
        return new Array(newArr);
    }

}

class Proverka
{
    public static int IntNum(string message)
    {
        int value;
        while (true)
        {
            Console.Write(message); // Запрашиваем ввод в каждой итерации
            string input = Console.ReadLine();

            // Пытаемся преобразовать строку в целое число
            if (int.TryParse(input, out value))
            {
                return value; // Возвращаем значение, если преобразование прошло успешно
            }
            else
            {
                Console.WriteLine("Ошибка: введите корректное целое число.");
            }
        }
    }
}