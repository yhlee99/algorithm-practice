// Question: 
// 그룹 단어란 단어에 존재하는 모든 문자에 대해서, 각 문자가 연속해서 나타나는 경우만을 말한다. 
// 예를 들면, ccazzzzbb는 c, a, z, b가 모두 연속해서 나타나고, kin도 k, i, n이 연속해서 나타나기 때문에 그룹 단어이지만, aabbbccb는 b가 떨어져서 나타나기 때문에 그룹 단어가 아니다.
// 단어 N개를 입력으로 받아 그룹 단어의 개수를 출력하는 프로그램을 작성하시오.

// Level: Silver 5

using System;
using System.Collections.Generic;
using System.Linq;

namespace BokJaeSang
{
    public class GroupWordChecker
    {
        public GroupWordChecker()
        {
            GetStringData();
        }

        private void GetStringData()
        {
            int numberCount = Int32.Parse(Console.ReadLine());
            int groupWordCount = 0;

            for (int i = 0; i < numberCount; i++)
            {
                string uncheckedWord = Console.ReadLine();

                if (CheckGroupWord(uncheckedWord) == true)
                {
                    groupWordCount++;
                }
            }

            Console.WriteLine(groupWordCount.ToString());
        }

        private bool CheckGroupWord(string uncheckedWord)
        {
            char[] unfoldedWord = uncheckedWord.ToCharArray();
            List<char> checkedAlphabet = new List<char>(); 

            if (uncheckedWord.Length == 1)
            {
                return true; // 1글자 짜리 단어의 경우 무조건 GroupWord
            }
            
            checkedAlphabet.Add(unfoldedWord[0]);
            
            for (int i = 1; i < unfoldedWord.Length; i++)
            {
                if (unfoldedWord[i] != unfoldedWord[i - 1]) // 이전글자와 같지 않다?
                {
                    if (checkedAlphabet.Contains(unfoldedWord[i])) // 이미 썼던 글자?
                    {
                        return false;
                    }
                    else // 처음 등장?
                    {
                        checkedAlphabet.Add(uncheckedWord[i]);
                    }
                }
            }

            return true;
        }
    }
}