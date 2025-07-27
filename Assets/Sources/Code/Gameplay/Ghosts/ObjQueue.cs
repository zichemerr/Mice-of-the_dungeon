using System.Collections.Generic;

namespace Sources.Code.Gameplay.Ghosts
{
    public class ObjQueue<T>
    {
        private Queue<T> _queue = new Queue<T>();
        private T[] _array;

        public ObjQueue(T[] array)
        {
            _array = array;
            InitQueue();
        }

        private void InitQueue()
        {
            for (int i = 0; i < _array.Length; i++)
            {
                _queue.Enqueue(_array[i]);
            }
        }

        public T Get()
        {
            if (_queue.Count > 0)
            {
                return _queue.Dequeue();
            }

            InitQueue();
            return _queue.Dequeue();
        }
    }
}