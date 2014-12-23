using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    /// <summary>
    /// A class that handles all algorithms and data structures needed when using graphs.
    /// </summary>
    class Graph : IDisposable
    {

        #region Instance Variables

        //vertices should have quick access through usage of a hashmap
        private Dictionary<string, Vertex> _vertices;
        private List<Edge> _edges;

        #endregion


        #region Constructors
        /// <summary>
        /// Creates an empty Graph.
        /// </summary>
        public Graph()
        {
            _vertices = new Dictionary<string, Vertex>();
            _edges = new List<Edge>();
        }
#endregion
        /// <summary>
        /// Adds a new Vertex with the specified name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool AddNewVertex(string n)
        {
            return AddNewVertex(new Vertex(n));
        }

        /// <summary>
        /// Adds the specified Vertex to the Graph.
        /// </summary>
        /// <param name="vertex"></param>
        /// <returns></returns>
        public bool AddNewVertex(Vertex v)
        {
            if (!_vertices.ContainsKey(v.Name))
            {
                _vertices.Add(v.Name, v);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Adds a new Edge between the two vertices defined by the strings.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public bool AddNewEdge(string a, string b)
        {
            return AddNewEdge(new Pair<string>(a, b));
        }

        /// <summary>
        /// Adds a new Edge between the two vertices defined by the string-pair.
        /// </summary>
        /// <param name="stringpair"></param>
        /// <returns></returns>
        public bool AddNewEdge(Pair<string> p)
        {
            Edge newEdge = new Edge(p);

            if (!_edges.Contains(newEdge))
            {
                if (!_vertices.ContainsKey(p.First))
                {
                    AddNewVertex(p.First);
                }
                if (!_vertices.ContainsKey(p.Last))
                {
                    AddNewVertex(p.Last);
                }
                _edges.Add(newEdge);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Adds the specified Edge to the Graph.
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public bool AddNewEdge(Edge e)
        {
            return true;
        }
    }
}
