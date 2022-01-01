using System;

namespace BokJaeSang
{
    public class OverAverage
    {
        float[] overAverageRatio;

        public OverAverage()
        {
            GetTestData();
        }
        
        private void GetTestData()   
        {
            Console.WriteLine("write test case plz");
            int testCase = Int32.Parse(Console.ReadLine());
            overAverageRatio = new float[testCase];

            for (int i = 0; i < testCase; i++)
            {
                Console.WriteLine("write Student count plz");
                int studentCount = Int32.Parse(Console.ReadLine());

                Console.WriteLine("write Student score plz");
                string[] numberText = Console.ReadLine().Split(" ");
                int[] scores = new int[studentCount];

                for (int j = 0; j < studentCount; j++)
                {
                    scores[j] = Int32.Parse(numberText[j]);
                }

                CheckOverAverage(scores, i);
            }

            WrtieResult(testCase);
        }

        private void CheckOverAverage(int[] scores, int index)
        {
            float totalScore = 0;

            for (int i = 0; i < scores.Length; i++)
            {
                totalScore += scores[i];
            }

            float scoreAverage = totalScore / scores.Length;
            int overAverageCount = 0;

            for (int i = 0; i < scores.Length; i++)
            {
                if (scores[i] > scoreAverage)
                {
                    overAverageCount++;
                }
            }
            
            overAverageRatio[index] = ((float)overAverageCount / (float)scores.Length) * 100f;
        }

        private void WrtieResult(int testCase)
        {
            for (int i = 0; i < testCase; i++)
            {
                Console.WriteLine($"평균 넘은 비율은 {overAverageRatio[i]}%");
            }
        }
    }
}