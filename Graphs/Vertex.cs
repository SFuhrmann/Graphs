using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    /// <summary>
    /// Represents a single vertex inside a graph.
    /// </summary>
    public class Vertex
    {
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = Name;
            }
        }

        public Vertex(string name)
        {
            _name = name;
        }

        #region Overrides
        public override string ToString()
        {
            return _name;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Vertex))
                return false;
            return ((Vertex)obj).Name == _name;
        }

        public override int GetHashCode()
        {
            return _name.GetHashCode();
        }
        #endregion
    }
}
