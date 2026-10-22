using System;
using System.Collections.Generic;
using System.Text;

namespace file5
{
    internal class Graf
    {
        static public List<int> FindShortestGraf(List<int>[] graph, int start, int end)
        {
            Queue<int> queue = new Queue<int>();

            int[] parents = new int[graph.Length];
            for (int i = 0; i < parents.Length; i++)
            {
                parents[i] = -1;
            }

            queue.Enqueue(start);
            parents[start] = start;

            while (queue.Count > 0)
            {
                int current = queue.Dequeue();

                if (current == end)
                {
                    break;
                }

                foreach (int neighbor in graph[current])
                {
                    if (parents[neighbor] == -1)
                    {
                        queue.Enqueue(neighbor);
                        parents[neighbor] = current;
                    }
                }
            }
            if (parents[end] == -1)
            {
                return new List<int>();
            }

            List<int> path = new List<int>();
            int step = end;
            while (step != start)
            {
                path.Add(step);
                step = parents[step];
            }
            path.Add(start);

            path.Reverse();

            return path;
        }
    }
}

