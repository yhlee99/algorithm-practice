// Question: 
// 1/1 1/2 1/3 1/4
// 2/1 2/2 2/3
// 3/1 3/2
// 4/1
// 이와 같이 나열된 분수들을 1/1 → 1/2 → 2/1 → 3/1 → 2/2 → … 과 같은 지그재그 순서로 차례대로 1번, 2번, 3번, 4번, 5번, … 분수라고 하자.
// X가 주어졌을 때, X번째 분수를 구하는 프로그램을 작성하시오.

// Level: Bronze 1

using System;

namespace BokJaeSang
{
    public class FractionFinder
    {
        public FractionFinder()
        {
            int progessNumber = Int32.Parse(Console.ReadLine());

            AnaylzeData(progessNumber);
        }

        private void AnaylzeData(int progressNumber)
        {
            int sumMinusOne = 1;

            while (progressNumber > sumMinusOne)
            {
                progressNumber = progressNumber - sumMinusOne;
                sumMinusOne++;
            }

            GetFraction(progressNumber - 1, sumMinusOne + 1);
        }

        private void GetFraction(int progressNumber, int sum)
        {
            int son = 0;
            int mom = 0;

            if (sum % 2 == 0)
            {
                son = sum - 1;
                mom = 1;

                for (int i = 0; i < progressNumber; i++)
                {
                    son--;
                    mom++;
                }
            }
            else
            {
                son = 1;
                mom = sum - 1;

                for (int i = 0; i < progressNumber; i++)
                {
                    son++;
                    mom--;
                }
            }

            Console.WriteLine($"{son}/{mom}");
        }
    }
}