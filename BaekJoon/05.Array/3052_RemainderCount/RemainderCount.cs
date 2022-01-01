using System;

namespace BokJaeSang
{
    public class RemainderCount
    {
        private int[] remainders;

        public RemainderCount()
        {
            GetNumberData();
        }

        private void GetNumberData()
        {
            int dividingValue = 42;
            int count = 10;
            remainders = new int[count];

            int numbersCount = 0;
            
            Console.WriteLine("Write Number Plz");

            for (int i = 0; i < count; i++)
            {
                int number = Int32.Parse(Console.ReadLine());
                int remainder = number % dividingValue;

                if (IsContainNumber(remainder, i) == false)
                {
                    numbersCount++;
                }

                remainders[i] = remainder;
            }

            Console.WriteLine($"{dividingValue}로 나누었을 때 서로 다른 나머지의 개수는 {numbersCount}");
        }

        // Array 내부에 같은 값이 포함되어 있는 지 체크하는 Method
        private bool IsContainNumber(int number, int index)
        {
            for (int i = 0; i < index; i++)
            {
                if (number == remainders[i])
                {
                    return true;
                }
            }

            return false;
        }
    }
}