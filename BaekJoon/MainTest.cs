using System;

namespace BokJaeSang
{
    public class MainTest
    {
        public static void Main()
        {
            FunctionDevelopment test = new FunctionDevelopment();
            // string[] genres = {"classic", "pop", "classic", "classic", "pop"};
            // int[] plays = {500, 600, 150, 800, 2500};
            
            Console.WriteLine(test.FindDays(97, 2).ToString());
        }
    }
}