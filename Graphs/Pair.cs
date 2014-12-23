using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    class Pair<T> : IDisposable
    {
        private T _first;
        private T _last;

        public T First
        {
            get
            {
                return _first;
            }
            set
            {
                _first = First;
            }
        }
        public T Last
        {
            get
            {
                return _last;
            }
            set
            {
                _last = Last;
            }
        }

        public Pair(T first, T last)
        {
            _first = first;
            _last = last;
        }
        public Pair();
    }
}
