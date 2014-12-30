using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    static class DijkstraSearch
    {
        /// <summary>
        /// Uses the Dijkstra Search Algorithm to find from one Vertex to another in the given Graph.
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public static Vertex[] Search(Graph g, Vertex from, Vertex to)
        {
            //Initialize
            Dictionary<Vertex, int> distances = new Dictionary<Vertex, int>();
            Dictionary<Vertex, Vertex> predecessor = new Dictionary<Vertex, Vertex>();

            bool found = false;

            distances.Add(from, 0);

            foreach(Vertex v in g.Vertices)
            {
                if (v != from)
                    distances.Add(v, Int32.MaxValue);
                predecessor.Add(v, null);
            }

            PriorityQueue<Vertex> q = new PriorityQueue<Vertex>();

            q.Insert(from, 0);

            //Algorithm
            while(q.Count != 0)
            {
                Vertex u = q.PopLowest();

                //Goal Vertex found
                if (u == to)
                {
                    found = true;
                    break;
                }

                //Analyse the neighbors and update their distances and predecessors accordingly
                foreach(Vertex v in GraphHelper.FindAdjacentVertices(g, u))
                {
                    if(distances.ContainsKey(v))
                    {
                        //update distance
                        if(distances[u] + 1 < distances[v])
                        {
                            distances[v] = distances[u] + 1;
                            predecessor[v] = u;
                            q.InsertOverride(v, distances[u] + 1);
                        }
                    }
                    else
                    {
                        distances.Add(v, distances[u] + 1);
                        predecessor.Add(v, u);
                        q.InsertOverride(v, distances[u] + 1);
                    }
                }
            }

            if (found)
                return GetPath(predecessor, to);
            else
                return null;
        }

        //Returns a sorted array of vertices that represent the path from the start to the goal
        private static Vertex[] GetPath(Dictionary<Vertex, Vertex> p, Vertex to)
        {
            List<Vertex> result = new List<Vertex>();

            Vertex next = to;

            while(next != null)
            {
                result.Insert(0, p[next]);
                next = p[next];
            }

            return result.ToArray();
        }
    }
}
