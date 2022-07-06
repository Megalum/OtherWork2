using System;

namespace OtherWork2
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo continie;
            string[] nameCurrency = { "RUB", "USD", "EUR", "BYN" };
            double[] currency = { 12542.13, 354.21, 135.99, 652.65 };
            double[,] converter = new double[,]
            {
                { 1.0,    0.017091,  0.016622,  0.0466 },
                { 58.51,  1.0,       0.9779,    2.67   },
                { 60.16,  1.02,      1.0,       1.74   },
                { 21.44,  0.37518,   0.36444,   1.0    }
            };
           
            do
            {
                Console.Clear();
                Console.WriteLine("1. RUB = {0:0.00}", currency[0]);
                Console.WriteLine("2. USD = {0:0.00}", currency[1]);
                Console.WriteLine("3. EUR = {0:0.00}", currency[2]);
                Console.WriteLine("4. BYN = {0:0.00}", currency[3]);
                Console.WriteLine();

                int currencyFirst = InputInt("Введите номер валюты с которой хотите поменять ") - 1;
                int currencySecond = InputInt("Введите номер валюты в которую хотите поменять ") - 1;
                double count = InputDouble("Введите сумму которую хотите поменять ");

                try
                {
                    if (count <= currency[currencyFirst])
                    {
                        Console.WriteLine();
                        double result = count * converter[currencyFirst, currencySecond];
                        continie = Permission($"Для подтверждения операции: перевод {count:0.00} {nameCurrency[currencyFirst]}" +
                            $" --> {result:0.00} {nameCurrency[currencySecond]}, нажмите (y/n) ");
                        if (continie.Key.ToString() == "Y")
                        {
                            currency[currencySecond] += result;
                            currency[currencyFirst] -= count;
                        }
                    }
                    else
                        Console.WriteLine("Недостаточно средств на счете");
                }
                catch (Exception)
                {
                    Console.WriteLine("Что-то пошло не так :(");
                }

                Console.WriteLine();
                continie = Permission("Желаете продолжить (y/n) ");
            } while (continie.Key.ToString() != "N");

            double InputDouble(string str)
            {
                Console.Write(str);
                return Convert.ToDouble(Console.ReadLine());
            }

            int InputInt(string str)
            {
                Console.Write(str);
                return int.Parse(Console.ReadLine());
            }

            ConsoleKeyInfo Permission(string str)
            {
                bool flag = true;
                Console.Write(str);
                ConsoleKeyInfo key;
                do
                {
                    key = Console.ReadKey();
                    if (key.Key.ToString() == "N" || key.Key.ToString() == "Y")
                        flag = false;
                } while (flag);
                return key;
            }

        }
    }
}
