using System;
using System.Linq;
using System.Collections.Generic;

class Pool
{
    public int solution(int[] bricks, int n, int k) // 벽돌, 높이, 웅덩이 개수
    {
        List<int> remainBrickList = new List<int>();

        for (int i = 0; i < bricks.Length ; i++)
        {
            remainBrickList.Add(n - bricks[i]);
        }

        int answer = 0;
        int poolCount = 1;

        while (poolCount < k)
        {
            // 맨 앞과 맨 뒤는 웅덩이 개수에 영향을 줄 수 없기에 제외
            remainBrickList[0] = -1;
            remainBrickList[remainBrickList.Count - 1] = -1;

            var min = remainBrickList.Where(x => x != -1)
                                     .Select((n, i) => (remainBrick: n, index: i))
                                     .Min();

            answer += min.remainBrick;
            poolCount += 1;

            if (min.index > 0)
            {
                remainBrickList.RemoveRange(min.index - 1, 3);
            }
            else
            {
                remainBrickList.RemoveRange(min.index, 2);
            }
        }

        return answer;
    }
}

// 1 <= n <= 50

// 양끝을 제외한 연속되지 않은 어딘가를 올려야 웅덩이가 늘어남 올린 곳 옆은 예외처리 필요
// k = 2 -> 1개를 끝까지 올려야함
// k = 3 -> 2개를 끝까지 올려야함