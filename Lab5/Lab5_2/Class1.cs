using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Syncfusion.XlsIO;
using System.IO;


namespace Lab5_2
{
    class Class1
    {
        static void Main(string[] args)
        {
            char[] alphabet = "abcdefghijklmnopqrstuvwxyzÄÜÖß,. ".ToLower().ToCharArray();

            //размерность таблицы
            Console.WriteLine("Symbols in alphabet: " + alphabet.Length + "\n");
            int columns = 4;
            Console.Write("Columns: " + columns + "\n");
            int rows = 4;
            Console.Write("Rows: " + rows + "\n");

            //ключевое слово
            string message;
            bool isValidKeyWord;
            do
            {
                Console.Write("Message: ");
                message = Console.ReadLine().ToLower();
                isValidKeyWord = message.Length > 0 && message.Length <= alphabet.Length;
                isValidKeyWord &= !message.Except(alphabet).Any();
                if (!isValidKeyWord)
                {
                    Console.WriteLine("Invalid key");
                }
            }
            while (!isValidKeyWord);

            // Создаем таблицу
            var table = new char[rows, columns];

            int countSymbols = 0;
            char[] charStringUser = message.ToLower().ToCharArray();

            long sec = DateTime.Now.Ticks;
            // Заполнение матрицы строкой пользователя
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    table[i, j] = charStringUser[countSymbols++];
                }
            }
            ShowMatrix(table, "Init table: ");
            long sec2 = (DateTime.Now.Ticks - sec) / 1000;
            Console.WriteLine("Time of table creation: " + sec2 + "\n");

            long sc = DateTime.Now.Ticks;
            Console.WriteLine("Encrypted value: ");
            char[] arr = { table[0, 0], table[0, 1], table[0, 2], table[0, 3], table[1, 3], table[1, 2], table[1, 1], table[1, 0],
                            table[2, 0], table[2,1], table[2,2], table[2, 3], table[3, 3], table[3, 2], table[3, 1], table[3, 0]};

            Console.WriteLine(arr);
            long sc2 = (DateTime.Now.Ticks - sc) / 1000;
            Console.WriteLine("Encrypt time: " + sc2 + "\n");

            char[,] itog = new char[4,4];

            Console.ReadLine();
        }

        public static void ShowMatrix(char[,] matrix, string message)
        {
            Console.WriteLine(message);
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public static void Encrypt(int stroka, int stolb, char[,] matrix, char[,] otv)
        {
            int i, j, p = 0;
            for (j = 0; j < stroka; j++)
            {
                if (j % 2 == 0)
                {
                    for (i = 0; i < stolb; i++, p++)
                    {
                        otv[j, i] = (char)p;
                    }
                }
                if (j % 2 == 1)
                {
                    for (i = stolb, p--; i > 0; i--, p--)
                    {
                        otv[j, i] = (char)p;
                    }
                }
            }
        }

        public static void outm(int stroka, int stolb, char[,] matrix)
        {
            int i, j;
            for (j = 0; j < stroka; j++)
            {
                for (i = 0; i < stolb; i++)
                {
                    Console.WriteLine(matrix[i, j]);
                }
            }
        }
    }
}
