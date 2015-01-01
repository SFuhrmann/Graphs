using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    /// <summary>
    /// Holds several static Methods that may help when using Graphs.
    /// </summary>
    public static class GraphHelper
    {

        #region FindAdjacent
        /// <summary>
        /// Returns an array of all Edges that are adjacent to the given vertex in the graph.
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="vertex"></param>
        /// <returns></returns>
        public static Edge[] FindAdjacentEdges(Graph g, Vertex v)
        {
            List<Edge> result = new List<Edge>();

            foreach(Edge e in g.Edges)
            {
                if (e.Vertices.Contains(v))
                    result.Add(e);
            }

            return result.ToArray();
        }

        /// <summary>
        /// Returns an array of all Edges that are adjacent to one of the vertices in the specified edge inside the graph.
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="edge"></param>
        /// <returns></returns>
        public static Edge[] FindAdjacentEdges(Graph g, Edge e)
        {
            List<Edge> result = new List<Edge>();

            result.AddRange(FindAdjacentEdges(g, e.Vertices.First));
            result.AddRange(FindAdjacentEdges(g, e.Vertices.Last));

            return result.ToArray();
        }

        /// <summary>
        /// Returns an array of all vertices that are adjacent to the specified vertex inside the graph.
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="vertex"></param>
        /// <returns></returns>
        public static Vertex[] FindAdjacentVertices(Graph g, Vertex v)
        {
            List<Vertex> result = new List<Vertex>();

            foreach(Edge e in g.Edges)
            {
                if (e.Vertices.Contains(v))
                    result.Add(e.Vertices.GetOther(v));
            }

            return result.ToArray();
        }

        /// <summary>
        /// Returns an array of all vertices that are adjacent to one of the vertices of the specified edge inside the graph.
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="edge"></param>
        /// <returns></returns>
        public static Vertex[] FindAdjacentVertices(Graph g, Edge e)
        {
            List<Vertex> result = new List<Vertex>();

            result.AddRange(FindAdjacentVertices(g, e.Vertices.First));
            result.AddRange(FindAdjacentVertices(g, e.Vertices.Last));

            return result.ToArray();
        }
        #endregion

    }
}
