using System;
using System.Linq;
using System.Collections.Generic;

class KeepSort
{
    public string solution(string letters, int k)
    {
        Dictionary<char, int> letterDic = new Dictionary<char, int>();
        List<char> seperatedLetters = letters.ToCharArray().ToList();

        for (int i = 0; i < seperatedLetters.Count; i++)
        {
            letterDic.Add(seperatedLetters[i], i);
        }

        seperatedLetters.Sort();
        seperatedLetters.RemoveRange(0, seperatedLetters.Count - k);

        return new String(seperatedLetters.OrderBy(x => letterDic[x]).ToArray());
    }
}