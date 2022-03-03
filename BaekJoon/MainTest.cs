using System;

namespace BokJaeSang
{
    public class MainTest
    {
        public static void Main()
        {
            // Pool test = new Pool();
            // Console.WriteLine(test.solution(new int[] {0, 4, 1, 1, 1}, 5, 2));

            // KeepSort test = new KeepSort();
            // Console.WriteLine(test.solution("zbgaj", 3));

            Process test = new Process();
            Console.WriteLine(test.solution(new int[] {5, 8, 3, 7, 10, 5, 4}, new int[,] {{1,2}, {2,4}, {1,4}, {6,5}, {3,5}, {4,6} }, 5));
        }
    }
}