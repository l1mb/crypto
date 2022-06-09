
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Lab4
{
    class Program
    {
        const string English = "абвгдеёжзійклмнопрстуўфхцчшыэюя '";
        const int a = 5;
        const int b = 7;
        static string CaesarEncrypted = "";
        static string CaesarDecrypted = "";
        static string TrisemusEncrypted = "";
        static string TrisemusDecrypted = "";
        const string key = "Сяргееў";
        static char[,] table = new char[9, 3];

        static void Main(string[] args)
        {
            CaesarEncrypt();
            CaesarDecrypt();
            TrisemusEncrypt();
            TrisemusDecrypt();
        }   
        public static void CaesarEncrypt()
        {
            using (StreamReader streamReader = new StreamReader(@"D:\programming\university\3\2\crypto\4\lab4\file.txt"))
            {
                string file = streamReader.ReadToEnd().ToLower().Replace("\r", "").Replace("\n", "").Replace(" ", "");
                file = Regex.Replace(file, @"\W+", "");
                var timer = new Stopwatch();
                timer.Start();
                for (int i = 0; i < file.Length; i++)
                {
                    int y = (a * English.IndexOf(file[i].ToString().ToLower()) + b) % English.Length;
                    CaesarEncrypted += English[y];
                }
                timer.Stop();
                var ts = timer.Elapsed;
                Console.WriteLine(string.Format("\n---Ceasar encrpypt time: {0:00}:{1:00}.{2:00}---\n", ts.Minutes, ts.Seconds, ts.Milliseconds));
                File.WriteAllText("ceasar.txt", CaesarEncrypted);

                Console.WriteLine($"\n---Letter frequency--- \n");
                using var kirill = new StreamWriter("ceasarUtils.txt");
                for (int i = 0; i < English.Length; i++)
                {
                    int countLetter = file.Count(x => x == English[i]);
                    double probabilityLetters = (double)countLetter / file.Length;
                    kirill.WriteLine($"P({English[i]}): {probabilityLetters}");
                }
                kirill.WriteLine($"\n---Вероятность каждый буквы в зашифрованном тексте--- \n");
                for (int i = 0; i < English.Length; i++)
                {
                    int countLetter = CaesarEncrypted.Count(x => x == English[i]);
                    double probabilityLetters = (double)countLetter / CaesarEncrypted.Length;
                    kirill.WriteLine($"P({English[i]}): {probabilityLetters}");
                }
            }
        }
        public static void CaesarDecrypt()
        {
            var timer = new Stopwatch();
            timer.Start();
            int a1 = 0;
            for (int x = 1; x < English.Length; x++)
            {
                if ((a * x) % English.Length == 1)
                {
                    a1 = x;
                    break;
                }
            }
            for (int i = 0; i < CaesarEncrypted.Length; i++)
            {
                int x = (a1 * (English.IndexOf(CaesarEncrypted[i]) + English.Length - b)) % English.Length;
                CaesarDecrypted += English[x];
            }
            timer.Stop();
            var ts = timer.Elapsed;
            Console.WriteLine(string.Format("\n---Ceasar decrypt time: {0:00}:{1:00}.{2:00}---\n", ts.Minutes, ts.Seconds, ts.Milliseconds));
            File.WriteAllText("ceasardec.txt",CaesarDecrypted);
        }
        public static void TrisemusEncrypt()
        {
            using (StreamReader streamReader = new StreamReader(@"D:\programming\university\3\2\crypto\4\lab4\file.txt"))
            {
                string file = streamReader.ReadToEnd().ToLower().Replace("\r", "").Replace("\n", "").Replace(" ", "");
                file = Regex.Replace(file, @"\W+", "");
                var timer = new Stopwatch();
                timer.Start();
                int k = 0;
                int a = 0;
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (k < key.Length)
                        {
                            table[i, j] = key[k];
                            k++;
                        }
                        else
                        {
                            if (i == 8 && j == 2)
                            {
                                table[i, j] = ' ';
                                break;
                            }
                            if (key.IndexOf(English[a]) == -1)
                            {
                                table[i, j] = English[a];
                            }
                            else
                            {
                                if (j == 0) i--;
                                else j--;
                            }
                            a++;
                        }
                    }
                }
                for (int x = 0; x < file.Length; x++)
                {
                    for (int i = 0; i < 9; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            if (file[x] == table[i, j])
                            {
                                if (i != 8) TrisemusEncrypted += table[i + 1, j];
                                else TrisemusEncrypted += table[0, j];
                            }
                        }
                    }
                }
                timer.Stop();
                var ts = timer.Elapsed;
                Console.WriteLine(string.Format("\n---Tresemus encrypt time: {0:00}:{1:00}.{2:00}---\n", ts.Minutes, ts.Seconds, ts.Milliseconds));

                File.WriteAllText("tresemusEnc.txt", TrisemusEncrypted);
            }
        }
        public static void TrisemusDecrypt()
        {
            var timer = new Stopwatch();
            timer.Start();
            for (int x = 0; x < TrisemusEncrypted.Length; x++)
            {
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (TrisemusEncrypted[x] == table[i, j])
                        {
                            if (i != 0) TrisemusDecrypted += table[i - 1, j];
                            else TrisemusDecrypted += table[8, j];
                        }
                    }
                }
            }
            timer.Stop();
            var ts = timer.Elapsed;
            Console.WriteLine(string.Format("\n---Tresemus decrypt time: {0:00}:{1:00}.{2:00}---\n", ts.Minutes, ts.Seconds, ts.Milliseconds));
            File.WriteAllText("tresemusDec.txt", TrisemusDecrypted);
        }
    }
}