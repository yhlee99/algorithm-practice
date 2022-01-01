using System;

namespace BokJaeSang
{
    public class NumbersCount
    {
        private int multiplier;
        private int[] numbersCount;

        public NumbersCount()
        {
            GetNumberData();
            CalculateNumbersCount();
        }

        private void GetNumberData()
        {
            int count = 3; // 받을 숫자의 개수
            multiplier = 1;

            Console.WriteLine("Write Number Plz");

            for (int i = 0; i < count; i++)
            {
                int number = Int32.Parse(Console.ReadLine());

                if (number >= 100 && number < 1000)
                {
                    multiplier *= number;
                }
                else
                {
                    Console.Write("number의 범위는 100 이상 1000 미만입니다");

                    return;
                }
            }
        }

        private void CalculateNumbersCount()
        {
            numbersCount = new int[]{0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
            int count = CalculateDigit(multiplier) - 1; // 곱해져 들어갈 수 있는 10의 개수 (자릿수에서 1을 뺀값)

            for (int i = count; i >= 0; i--)
            {
                int quotient = (int)Math.Truncate(multiplier / Math.Pow(10, i));
                numbersCount[quotient]++;

                double remainder = multiplier % Math.Pow(10, i);
                multiplier = (int)remainder;
            }

            for (int i = 0; i < numbersCount.Length; i++)
            {
                Console.WriteLine($"{i}의 개수는 {numbersCount[i]}");
            }
        }

        // 자릿수를 반환하는 Method 예 7: 자릿수 1개, 17: 자릿수 2개
        private int CalculateDigit(int number)
        {
            int digit = 1;

            while(true)
            {
                if (number >= 10)
                {
                    number /= 10;
                    digit++;
                }
                else
                {
                    return digit;
                }
            }
        }
    }
}