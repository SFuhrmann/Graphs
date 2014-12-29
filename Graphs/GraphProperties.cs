﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    static class GraphProperties
    {
        public static bool IsVertexReachableFrom(Graph g, Vertex start, Vertex goal)
        {
            return true;
        }

        /// <summary>
        /// Returns true when the given Graph is bipartite.
        /// </summary>
        /// <param name="graph"></param>
        /// <returns></returns>
        public static bool IsGraphBipartite(Graph g)
        {
            //Create two sets of Vertices
            Dictionary<Vertex, bool> U = new Dictionary<Vertex, bool>();
            Dictionary<Vertex, bool> V = new Dictionary<Vertex, bool>();

            //Define Source Vertex
            Vertex src = g.Vertices[0];

            //Create a Queue that holds all vertices to analyse and starts with the source Vertex
            Queue<Vertex> q = new Queue<Vertex>();
            q.Enqueue(src);

            //Add Source Vertex to Set U
            U.Add(src, true);

            //while there is an Element in the Queue
            while(!(q.Count == 0))
            {
                //get the next Vertex
                Vertex v = q.Dequeue();

                //find all neighbors
                Vertex[] neighbors = GraphHelper.FindAdjacentVertices(g, v);

                foreach (Vertex vn in neighbors)
                {
                    //if neighbor is in no set yet add it to the alternate set of v
                    if (!U.ContainsKey(vn) && !V.ContainsKey(vn))
                    {
                        if (U.ContainsKey(v))
                            V.Add(vn, true);
                        else
                            U.Add(vn, true);
                        //Add the neighbor to the Queue
                        q.Enqueue(vn);
                    }

                    //if the neighbor already is inside a set and it is the same set as v, the graph is not bipartite
                    else if ((U.ContainsKey(v) && U.ContainsKey(vn)) || (V.ContainsKey(v) && V.ContainsKey(vn)))
                        return false;
                }
            }

            //if until now the graph was not determined non-bipartite, it can only be bipartite
            return true;
        }

        /// <summary>
        /// Returns true when the given graph is bipartite. Calculates this asynchronously.
        /// </summary>
        /// <param name="graph"></param>
        /// <returns></returns>
        public async static Task<bool> IsGraphBipartiteAsync(Graph g)
        {
            return await Task.Run(() => { return IsGraphBipartite(g); });
        }
    }
}