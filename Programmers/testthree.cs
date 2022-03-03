using System;
using System.Linq;
using System.Collections.Generic;

public class Process
{
    public class Route
    {
        public int start;
        public int end;
        public int totalTime;

        public Route(int start, int end, int totalTime)
        {
            this.start = start;
            this.end = end;
            this.totalTime = totalTime;
        }
    }

    private int[] T;
    private int[,] R;
    List<Route> routes = new List<Route>();

    public int solution(int[] T, int[,] R, int k)
    {
        this.T = T;
        this.R = R;
        Route route = new Route(k, k, T[k - 1]);
        FindRoute(route);

        return routes.Max(x => x.totalTime);
    }

    private void FindRoute(Route lastRoute)
    {
        // List<Route> routes = new List<Route>();
        List<int> startPos = new List<int>();

        for (int i = 0; i < R.GetLength(0); i++)  
        {
            if (R[i, 1] == lastRoute.start)
            {
                startPos.Add(R[i, 0]);
            }
        }

        if (startPos.Count == 0)
        {
            routes.Add(lastRoute);
        }
        else if (startPos.Count == 1)
        {
            lastRoute.start = startPos[0];
            lastRoute.totalTime += T[startPos[0] - 1];

            FindRoute(lastRoute);
        }
        else
        {
            foreach (int start in startPos)
            {
                Route route = new Route(start, lastRoute.end, lastRoute.totalTime + T[start - 1]);
                FindRoute(route);
            }
        }
    }
}