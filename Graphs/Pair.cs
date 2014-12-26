using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    class Pair<T>
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
        public Pair()
        {}

        /// <summary>
        /// Returns true when the pair contains the defined item.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(T item)
        {
            if (item.Equals(_first)) return true;
            if (item.Equals(_last)) return true;
            return false;
        }
    }
}
