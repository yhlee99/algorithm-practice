// Question: 
// 주어진 수 N개 중에서 소수가 몇 개인지 찾아서 출력하는 프로그램을 작성하시오.

// Level: Silver 4

using System;
using System.Collections;
using System.Collections.Generic;

namespace BokJaeSang
{
    public class DecimalFinder
    {
        public DecimalFinder()
        {
            GetNumberData();
        }

        private void GetNumberData()
        {
            // Get Data
            int numberCount = Int32.Parse(Console.ReadLine());
            string[] decimalCandidateText = Console.ReadLine().Split(" ");

            int decimalCount = 0;

            foreach (var text in decimalCandidateText)
            {
                if (IsDecimal(Int32.Parse(text)) == true)
                {
                    decimalCount++;
                }
            }

            Console.WriteLine(decimalCount.ToString());
        }

        private bool IsDecimal(int number)
        {
            if (number == 1)
            {
                return false;
            }
            else
            {
                for (int i = 2; i < number; i++)
                {
                    if (number % i == 0)
                    {
                        return false;
                    }
                }

                return true;
            }
        }
    }
}