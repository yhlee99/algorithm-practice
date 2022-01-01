// Question:
// 어떤 양의 정수 X의 각 자리가 등차수열을 이룬다면, 그 수를 한수라고 한다. 
// 등차수열은 연속된 두 개의 수의 차이가 일정한 수열을 말한다. N이 주어졌을 때, 1보다 크거나 같고, N보다 작거나 같은 한수의 개수를 출력하는 프로그램을 작성하시오. 

// Level: Silver 4

using System;
using System.Collections.Generic;

namespace BokJaeSang
{
    public class HanSu
    {
        public HanSu()
        {
            GetNumberData();
        }

        private void GetNumberData()
        {
            Console.WriteLine("write number plz");
            int maxNumber = Int32.Parse(Console.ReadLine());

            CheckHansuCount(maxNumber);
        }

        private void CheckHansuCount(int maxNumber)
        {
            int hanSuCount = 0;

            for (int i = 1; i <= maxNumber; i++)
            {
                if (isHansu(i) == true)
                {
                    hanSuCount++;
                }
            }

            Console.WriteLine($"한수의 수는 {hanSuCount}");
        }

        // 한수이면 true, 아니면 false 반환 하는 Method
        private bool isHansu(int number)
        {
            char[] numberPiece = number.ToString().ToCharArray();
            int digit = CalculateDigit(number);

            if (digit <= 2) // 두자릿수 까지는 무조건 한수이다.
            {
                return true;
            }
            else
            {
                List<int> differences = new List<int>();

                for (int i = 0; i < numberPiece.Length - 1; i++)
                {
                    int difference = Int32.Parse(numberPiece[i].ToString()) - Int32.Parse(numberPiece[i + 1].ToString());
                    differences.Add(difference);
                }

                return isDifferencesSame(differences);
            }
        }

        // List 값 중 하나라도 서로 다른게 있다면 false 반환하는 Method
        private bool isDifferencesSame(List<int> differences)
        {
            for (int i = 0; i < differences.Count - 1; i++)
            {
                if (differences[i] != differences[i + 1])
                {
                    return false;
                }
            }

            return true;
        }

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