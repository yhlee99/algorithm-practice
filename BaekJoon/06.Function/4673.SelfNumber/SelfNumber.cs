// Question: 
// 셀프 넘버는 1949년 인도 수학자 D.R. Kaprekar가 이름 붙였다. 양의 정수 n에 대해서 d(n)을 n과 n의 각 자리수를 더하는 함수라고 정의하자. 예를 들어, d(75) = 75+7+5 = 87이다.
// 양의 정수 n이 주어졌을 때, 이 수를 시작해서 n, d(n), d(d(n)), d(d(d(n))), ...과 같은 무한 수열을 만들 수 있다. 
// 예를 들어, 33으로 시작한다면 다음 수는 33 + 3 + 3 = 39이고, 그 다음 수는 39 + 3 + 9 = 51, 다음 수는 51 + 5 + 1 = 57이다. 이런식으로 다음과 같은 수열을 만들 수 있다.
// 33, 39, 51, 57, 69, 84, 96, 111, 114, 120, 123, 129, 141, ...
// n을 d(n)의 생성자라고 한다. 위의 수열에서 33은 39의 생성자이고, 39는 51의 생성자, 51은 57의 생성자이다. 생성자가 한 개보다 많은 경우도 있다. 예를 들어, 101은 생성자가 2개(91과 100) 있다. 
// 생성자가 없는 숫자를 셀프 넘버라고 한다. 100보다 작은 셀프 넘버는 총 13개가 있다. 1, 3, 5, 7, 9, 20, 31, 42, 53, 64, 75, 86, 97
// 10000보다 작거나 같은 셀프 넘버를 한 줄에 하나씩 출력하는 프로그램을 작성하시오.

// Level: Silver 5

using System;
using System.Linq;
using System.Collections.Generic;

namespace BokJaeSang
{
    public class SelfNumber
    {
        private List<bool> isSelfNumbers;
        private int maxNumber = 10000;

        public SelfNumber()
        {
            SetNumber();
        }

        private void SetNumber()
        {
            isSelfNumbers = Enumerable.Repeat(false, maxNumber + 1).ToList(); // 전부 false로 초기화 + 10000도 포함되야 하니 size는 max + 1

            for (int i = 0; i <= maxNumber; i++)
            {
                CheckSelfNumber(i);
            }

            for (int i = 0; i < isSelfNumbers.Count; i++)
            {
                if (isSelfNumbers[i] == false)
                {
                    Console.WriteLine(i.ToString());
                }
            }
        }

        private void CheckSelfNumber(int number)
        {
            int generatedNumber = 0;
            int digit = CalculateDigit(number);

            generatedNumber += number;

            for (int i = digit - 1; i > 0; i--)
            {
                int quotient = (int)Math.Truncate(number / Math.Pow(10, i));
                generatedNumber += quotient;

                double remainder = number % Math.Pow(10, i);
                number = (int)remainder;
            }

            generatedNumber += number; // 마지막 나머지

            if (generatedNumber <= maxNumber)
            {
                isSelfNumbers[generatedNumber] = true;
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

// Feedback: 처음에는 List<int>로 만든 후 Self Number가 아닌 값을 찾아가 하나씩 지움 --> 매번 List에 접근해 해당하는 값이 있는 지 끝까지 Check해야 하기 때문에 매우 비효율적
// 숫자가 남아 있는지만 Check하면 됨으로 List에서 추가로 지우는 일이 필요 없이 bool 값을 통해 지워진 값인 지를 체크만 하면 됨

// 아래 잘못 만든 코드 남겨둠
// namespace BokJaeSang
    // {
    //     public class SelfNumber
    //     {
    //         private List<int> numbers = new List<int>();
    //         private int maxNumber = 10000;

    //         public SelfNumber()
    //         {
    //             SetNumber();
    //         }

    //         private void SetNumber()
    //         {
    //             for (int i = 0; i <= maxNumber; i++)
    //             {
    //                 numbers.Add(i);
    //             }

    //             for (int i = 0; i <= maxNumber; i++)
    //             {
    //                 CheckSelfNumber(i);
    //             }

    //             foreach (var item in numbers)
    //             {
    //                 Console.WriteLine(item.ToString());
    //             }
    //         }

    //         private void CheckSelfNumber(int number)
    //         {
    //             int generatedNumber = 0;
    //             int digit = CalculateDigit(number);

    //             generatedNumber += number;

    //             for (int i = digit - 1; i > 0; i--)
    //             {
    //                 int quotient = (int)Math.Truncate(number / Math.Pow(10, i));
    //                 generatedNumber += quotient;

    //                 double remainder = number % Math.Pow(10, i);
    //                 number = (int)remainder;
    //             }

    //             generatedNumber += number; // 마지막 나머지

    //             if (generatedNumber <= maxNumber)
    //             {
    //                 numbers.Remove(generatedNumber);
    //             }
    //         }

    //         // 자릿수를 반환하는 Method 예 7: 자릿수 1개, 17: 자릿수 2개
    //         private int CalculateDigit(int number)
    //         {
    //             int digit = 1;

    //             while(true)
    //             {
    //                 if (number >= 10)
    //                 {
    //                     number /= 10;
    //                     digit++;
    //                 }
    //                 else
    //                 {
    //                     return digit;
    //                 }
    //             }
    //         }
    //     }
    // }