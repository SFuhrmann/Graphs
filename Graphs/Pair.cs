using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public class Pair<T>
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

        /// <summary>
        /// Returns the other item of the Pair. If the Pair does not contain the item it returns the default value of the Class of this Pair.
        /// You may want to make sure the Pair contains the item by using Pair.Contains().
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public T GetOther(T item)
        {
            if (item.Equals(_first)) return _last;
            if (item.Equals(_last)) return _first;
            return default(T);
        }
    }
}
