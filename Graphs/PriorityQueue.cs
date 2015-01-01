using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public class PriorityQueue<T>
    {
        Dictionary<T, int> _priority;
        List<T> _queue;

        public PriorityQueue()
        {
            _priority = new Dictionary<T, int>();
            _queue = new List<T>();
        }

        public int Count
        {
            get
            {
                return _queue.Count;
            }
        }

        /// <summary>
        /// Adds the item with the given priority to the Queue.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="priority"></param>
        public void Insert(T t, int i)
        {
            if (_queue.Count == 0)
            {
                _queue.Insert(0, t);
            }
            else
            {
                bool positioned = false;
                int k = 0;

                while (!positioned)
                {
                    T next = _queue[k];

                    if (_priority[next] > i)
                    {
                        _queue.Insert(k, t);
                        positioned = true;
                    }

                    k++;

                    if (k > _queue.Count - 1)
                    {
                        _queue.Add(t);
                        positioned = true;
                    }
                }
            }
            _priority.Add(t, i);
        }

        public void InsertOverride(T t, int i)
        {
            if (_priority.ContainsKey(t))
            {
                _priority.Remove(t);
                _queue.Remove(t);
            }
            Insert(t, i);
        }

        /// <summary>
        /// Returns the item in the List with the lowest priority.
        /// </summary>
        /// <returns></returns>
        public T PeekLowest()
        {
            return _queue[0];
        }

        /// <summary>
        /// Returns the item in the Queue with the highest priority.
        /// </summary>
        /// <returns></returns>
        public T PeekHighest()
        {
            return _queue[_queue.Count - 1];
        }

        /// <summary>
        /// Returns and removes the item in the Queue with the lowest priority.
        /// </summary>
        /// <returns></returns>
        public T PopLowest()
        {
            T result = _queue[0];

            _queue.RemoveAt(0);
            _priority.Remove(result);

            return result;
        }

        /// <summary>
        /// Returns and removes the item in the Queue with the highest priority.
        /// </summary>
        /// <returns></returns>
        public T PopHighest()
        {
            int i = _queue.Count - 1;

            T result = _queue[i];

            _queue.RemoveAt(i);
            _priority.Remove(result);

            return result;
        }

        /// <summary>
        /// Returns true when the PriorityQueue contains the given item.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(T item)
        {
            return _priority.ContainsKey(item);
        }
    }
}
