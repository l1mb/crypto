using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{

    class Program
    {
        public static int n = 477;
        public static int m = 447;
        private static int nodForTwoNumbers(int a, int b)
        {
            while (a != 0 && b != 0)
            {
                if (a > b)
                {
                    a = a % b;
                }
                else
                {
                    b = b % a;
                }
            }
            return a + b;
        }
        private static void simpleNumbers(int a)
        {
            int div = 2;
            string result = "";
            while (a > 1)
            {
                if (a % div == 0)
                {
                    result += div + "*";
                    a /= div;
                    div = 2;
                }
                else
                {
                    div++;
                }
            }
            Console.WriteLine(result.Remove(result.Length - 1, 1));
        }
        private static bool isSimple(int a)
        {
            if (a > 1)
            {
                for (int i = 2; i <= (a / 2); i++)
                {
                    if (a % i == 0)
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
            return true;
        }
        private static int nodForThreeNumbers(int a, int b, int c)
        {
            return nodForTwoNumbers(nodForTwoNumbers(a, b), c);
        }
        private static void Evklid(int a, int m)
        {
            a = a % m;
            for (int x = 1; x < m; x++)
            {
                if ((a * x) % m == 1)
                {
                    Console.WriteLine($"mod равен: {x}");
                    break;
                }
            }
        }
        static void Main(string[] args)
        {
            for (; ; )
            {
                Console.WriteLine("\nВыберите операцию:");
                Console.WriteLine($"1. Вычисление НОД для m={m} n={n}", m, n);
                Console.WriteLine($"2. Числа m={m} и n={n} в виде произведения простых множителей", m, n);
                Console.WriteLine($"3. Проверка, является ли число, состоящее из конкатенации цифр m={m} и n={n}, простым");
                Console.WriteLine($"4. Количество простых чисел между m={m} n={n}", m, n);
                Console.WriteLine($"5. Количество простых чисел между m=2 n={n}", n);
                Console.WriteLine("6. Вычисление НОД для двух чисел");
                Console.WriteLine("7. Вычисление НОД для трех чисел");
                Console.WriteLine("8. Поиск простых чисел в заданном интервале");
                Console.WriteLine("9. Нахождение обратного по модулю");
                Console.Write("Выберите пункт: ");
                int a = int.Parse(Console.ReadLine());
                Console.WriteLine();

                switch (a)
                {
                    case 1:
                        Console.WriteLine($"НОД равен: {nodForTwoNumbers(n, m)}");
                        break;
                    case 2:
                        simpleNumbers(n);
                        simpleNumbers(m);
                        break;
                    case 3:
                        int result = Convert.ToInt32(string.Concat(m.ToString(), n.ToString()));
                        if (isSimple(result))
                        {
                            Console.WriteLine($"Число {result} простое");
                        }
                        else
                        {
                            Console.WriteLine($"Число {result} не простое");
                        }
                        break;
                    case 4:
                        int countCaseFour = 0;
                        for (int i = m; i <= n; i++)
                        {
                            if (isSimple(i))
                            {
                                countCaseFour++;
                            }
                        }
                        Console.WriteLine($"Количество {countCaseFour} ", countCaseFour);
                        break;
                    case 5:
                        int countCaseFive = 0;
                        for (int i = 2; i <= n; i++)
                        {
                            if (isSimple(i))
                            {
                                countCaseFive++;
                            }
                        }
                        Console.WriteLine($"Количество {countCaseFive} ", countCaseFive);
                        break;
                    case 6:
                        Console.WriteLine("Введите 2 числа:");
                        int firstNumber = int.Parse(Console.ReadLine());
                        int secondNumber = int.Parse(Console.ReadLine());
                        Console.WriteLine($"НОД равен: {nodForTwoNumbers(firstNumber, secondNumber)}");
                        break;
                    case 7:
                        Console.WriteLine("Введите 3 числа:");
                        int first = int.Parse(Console.ReadLine());
                        int second = int.Parse(Console.ReadLine());
                        int third = int.Parse(Console.ReadLine());
                        Console.WriteLine($"НОД равен: {nodForThreeNumbers(first, second, third)}");
                        break;
                    case 8:
                        Console.WriteLine("Введите диапазон чисел:");
                        int startNumber = int.Parse(Console.ReadLine());
                        int maxNumber = int.Parse(Console.ReadLine());
                        for (int i = startNumber; i <= maxNumber; i++)
                        {
                            if (isSimple(i))
                            {
                                Console.Write(i.ToString() + " ");
                            }
                        }
                        break;
                    case 9:
                        Console.WriteLine("Введите число к которому хотите найти обратный");
                        int firstNum = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите модуль");
                        int secNum = int.Parse(Console.ReadLine());
                        int isSimpleNumber = nodForTwoNumbers(firstNum, secNum);
                        if (isSimpleNumber.Equals(1))
                        {
                            Evklid(firstNum, secNum);
                        }
                        else
                        {
                            Console.WriteLine("Не взаимнопростые");
                        }
                        break;
                    default:
                        Console.WriteLine("Вы ошиблись");
                        break;
                }

            }
        }
    }
}
