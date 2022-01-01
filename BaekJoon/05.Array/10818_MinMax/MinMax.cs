using System;

namespace BokJaeSang
{
    public class MinMax
    {
        private int numberCount;
        private int[] numbers = null;

        public MinMax()
        {
            GetNumberData();
            CalculateMinMax();
        } 

        private void GetNumberData()
        {
            Console.WriteLine("Write Number Count Plz");
            numberCount = Int32.Parse(Console.ReadLine());

            // numbers Memory 할당
            numbers = new int[numberCount];

            Console.WriteLine("Write Number Plz");
            string[] numberText = Console.ReadLine().Split(" ");
            
            if (numberText.Length == numberCount)
            {
                for (int i = 0; i < numberCount; i++)
                {
                    numbers[i] = Int32.Parse(numberText[i]);
                }
            }
            else
            {
                Console.WriteLine("Number and Length are not equal, So rewrite plz");
                GetNumberData();
            }
        }

        private void CalculateMinMax()
        {
            int min = numbers[0];
            int max = numbers[0];

            for (int i = 1; i < numberCount; i++)
            {
                if (numbers[i] < min)
                {
                    min = numbers[i];
                    continue;
                }

                if (numbers[i] > max)
                {
                    max = numbers[i];
                    continue;
                }
            }

            Console.WriteLine($"min: { min }");
            Console.WriteLine($"max: { max }");
        }
    }
}
