using System;

namespace BokJaeSang
{
    public class ModifiedAverage
    {
        public ModifiedAverage()
        {
            GetNumberData();
        }   

        private void GetNumberData()
        {
            Console.WriteLine("write score count plz");
            int scoreCount = Int32.Parse(Console.ReadLine());

            Console.WriteLine("write score plz");
            string[] numberText = Console.ReadLine().Split(" ");
            float[] scores = new float[scoreCount];
            float max = 0;

            for (int i = 0; i < scoreCount; i++)
            {
                scores[i] = Int32.Parse(numberText[i]);

                if (scores[i] > max)
                {
                    max = scores[i];
                }
            }

            ModifyScore(max, scores);
        }

        private void ModifyScore(float max, float[] scores)
        {
            float newTotalScore = 0;

            for (int i = 0; i < scores.Length; i++)
            {
                scores[i] = (scores[i] / max) * 100;
                newTotalScore += scores[i];
            }

            Console.WriteLine($"new Average is {newTotalScore / scores.Length}");
        }
    }
}