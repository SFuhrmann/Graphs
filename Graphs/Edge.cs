using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    class Edge : IDisposable
    {
        private Pair<Vertex> _vertices;

        public Pair<Vertex> Vertices
        {
            get
            {
                return _vertices;
            }
            set
            {
                _vertices = Vertices;
            }
        }

        public Edge(Vertex a, Vertex b)
        {
            _vertices = new Pair<Vertex>(a, b);
        }
    }
}
