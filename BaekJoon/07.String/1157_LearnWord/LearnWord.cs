// Question:
// 알파벳 대소문자로 된 단어가 주어지면, 이 단어에서 가장 많이 사용된 알파벳이 무엇인지 알아내는 프로그램을 작성하시오. 단, 대문자와 소문자를 구분하지 않는다.

// Level: Bronze 1

using System;
using System.Collections.Generic;
using System.Linq;

namespace BokJaeSang
{
    public class LearnWord
    {
        public LearnWord()
        {
            GetWord();
        }

        private void GetWord()
        {
            string word = Console.ReadLine();

            FindMostAlphabet(word.ToUpper()); // 대소문자 구분 x
        }

        private void FindMostAlphabet(string word)
        {
            char[] unfoldedWord = word.ToCharArray();

            Dictionary<char, int> wordCount = new Dictionary<char, int>();
            int max = 0;
            List<char> maxAlphabets = new List<char>();

            for (int i = 0; i < unfoldedWord.Length; i++)
            {
                if (wordCount.ContainsKey(unfoldedWord[i]))
                {
                    wordCount[unfoldedWord[i]]++;

                    if (wordCount[unfoldedWord[i]] > max) // Max값이 갱신된 경우
                    {
                        max = wordCount[unfoldedWord[i]];

                        maxAlphabets.Clear();
                        maxAlphabets.Add(unfoldedWord[i]);
                    }
                    else if (wordCount[unfoldedWord[i]] == max) // 이전 Max값과 동일한 경우
                    {
                        maxAlphabets.Add(unfoldedWord[i]);
                    }
                }
                else
                {
                    wordCount.Add(unfoldedWord[i], 1);

                    maxAlphabets.Add(unfoldedWord[i]);
                }
            }

            if (maxAlphabets.Count > 1) // Max Alphatbet의 개수가 1개가 아닌 경우
            {
                Console.WriteLine("?");
            }
            else // Max Alphatbet의 경우가 1개인 경우
            {
                Console.WriteLine(maxAlphabets[0]);
            }
        }
    }
}