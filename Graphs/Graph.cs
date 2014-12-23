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

        /// <summary>
        /// Creates a graph with the specified edges and vertices
        /// </summary>
        /// <param name="vertices"></param>
        /// <param name="edges"></param>
        public Graph(List<Vertex> vs, List<Edge> e)
        {
            //add all vertices to _vertices
            _vertices = new Dictionary<string, Vertex>();
            foreach(Vertex v in vs)
            {
                _vertices.Add(v.Name, v);
            }

            _edges = e;
        }
#endregion

        public void AddNewVertex(string n)
        {

        }
    }
}
