// Question: 
// 정수 N이 주어졌을 때, 소인수분해하는 프로그램을 작성하시오.

// Level: Silver 4

using System;
using System.Collections;
using System.Collections.Generic;

namespace BokJaeSang
{
    public class Factorization
    {
        public Factorization()
        {
            FindFactor(Int32.Parse(Console.ReadLine()));
        }

        private void FindFactor(int number)
        {
            while (number > 1)
            {
                for (int i = 2; i <= number; i++)
                {
                    if (number % i == 0)
                    {
                        Console.WriteLine(i);

                        number /=  i;
                        i = 1;
                    }
                }
            }
        }
    }
}