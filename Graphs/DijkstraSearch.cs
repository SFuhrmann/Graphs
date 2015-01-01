using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public static class DijkstraSearch
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
            predecessor.Add(from, from);

            foreach(Vertex v in g.Vertices)
            {
                if (!v.Equals(from))
                {
                    distances.Add(v, Int32.MaxValue);
                    predecessor.Add(v, null);
                }
            }

            PriorityQueue<Vertex> q = new PriorityQueue<Vertex>();

            q.Insert(from, 0);

            //Algorithm
            while(q.Count != 0)
            {
                Vertex u = q.PopLowest();

                //Goal Vertex found
                if (u.Equals(to))
                {
                    found = true;
                    break;
                }

                //Find all neighbors of u
                Vertex[] neighbors = GraphHelper.FindAdjacentVertices(g, u);

                //Analyse the neighbors and update their distances and predecessors accordingly
                foreach (Vertex v in neighbors)
                {
                    if (predecessor[v] != null)
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
                        distances[v] = distances[u] + 1;
                        predecessor[v] = u;
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
            result.Insert(0, next);

            while(next != p[next])
            {
                result.Insert(0, p[next]);
                next = p[next];
            }

            return result.ToArray();
        }

        /// <summary>
        /// Returns the number of reachable nodes from the given vertex inside the given graph.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="from"></param>
        /// <returns></returns>
        public static int CountReachableNodes(Graph g, Vertex from)
        {
            //Initialize
            Dictionary<Vertex, int> distances = new Dictionary<Vertex, int>();
            Dictionary<Vertex, Vertex> predecessor = new Dictionary<Vertex, Vertex>();

            int count = 1;

            distances.Add(from, 0);
            predecessor.Add(from, from);

            foreach (Vertex v in g.Vertices)
            {
                if (!v.Equals(from))
                {
                    distances.Add(v, Int32.MaxValue);
                    predecessor.Add(v, null);
                }
            }

            PriorityQueue<Vertex> q = new PriorityQueue<Vertex>();

            q.Insert(from, 0);

            //Algorithm
            while (q.Count != 0)
            {
                //Get next Vertex
                Vertex u = q.PopLowest();

                //Find all neighbors of u
                Vertex[] neighbors = GraphHelper.FindAdjacentVertices(g, u);

                //Analyse the neighbors and update their distances and predecessors accordingly
                foreach (Vertex v in neighbors)
                {
                    if (predecessor[v] != null)
                    {
                        //update distance
                        if (distances[u] + 1 < distances[v])
                        {
                            distances[v] = distances[u] + 1;
                            predecessor[v] = u;
                            q.InsertOverride(v, distances[u] + 1);
                        }
                    }
                    else
                    {
                        distances[v] = distances[u] + 1;
                        predecessor[v] = u;
                        q.InsertOverride(v, distances[u] + 1);
                        count++;
                    }
                }
            }
            return count;
        }
    }
}
