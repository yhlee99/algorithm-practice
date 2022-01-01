using System;

namespace BokJaeSang
{
    public class MaxIndex
    {
        private int[] numbers = null;

        public MaxIndex()
        {
            GetNumberData();
            CalculateMaxAndIndex();
        }

        private void GetNumberData()
        {
            Console.WriteLine("Write Number Plz");
            string[] numberText = Console.ReadLine().Split(" ");
            int numberCount = numberText.Length;

            // numbers Memory 할당
            numbers = new int[numberCount];
            
            for (int i = 0; i < numberCount; i++)
            {
                numbers[i] = Int32.Parse(numberText[i]);
            }
        }

        private void CalculateMaxAndIndex()
        {
            int max = numbers[0];
            int maxIndex = 0;

            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] > max)
                {
                    max = numbers[i];
                    maxIndex = i;
                }
            }

            Console.WriteLine($"max: { max }");
            Console.WriteLine($"maxIndex: { maxIndex }");
        }
    }
}
