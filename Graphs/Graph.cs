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
        private Dictionary<Vertex, bool> _vertices;
        private Dictionary<Edge, bool> _edges;

        #endregion


        #region Constructors
        /// <summary>
        /// Creates an empty Graph.
        /// </summary>
        public Graph()
        {
            _vertices = new Dictionary<Vertex, bool>();
            _edges = new Dictionary<Edge, bool>();
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
            if (!_vertices.ContainsKey(v))
            {
                _vertices.Add(v, true);
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

            if (!_edges.ContainsKey(newEdge))
            {
                Vertex firstV = new Vertex(p.First);
                Vertex lastV = new Vertex(p.Last);
                if (!_vertices.ContainsKey(firstV))
                {
                    AddNewVertex(firstV);
                }
                if (!_vertices.ContainsKey(lastV))
                {
                    AddNewVertex(lastV);
                }
                _edges.Add(newEdge, true);
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
