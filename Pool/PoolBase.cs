using UnityEngine;
using System;

namespace Pool
{
    public abstract class PoolBase<T> : PoolAbstract
    {
        protected T[] _pool = new T[1];

        #region Constructor

        public PoolBase(int id, int baseSize = -1, int numberOfElementsPreloaded = 0) : base(id)
        {
            if (baseSize > 0)
            {
                Array.Resize(ref _pool, baseSize);
            }

            if (numberOfElementsPreloaded > 0)
            {
                for (int i = 0; i < numberOfElementsPreloaded; ++i)
                {
                    Release(GetObject());
                }
            }
        }

        #endregion

        public abstract T GetObject();
        public abstract void PoolBehaviourOnRelease(T item);
        public abstract void ClearElement(int index);

        public T GetItem()
        {
            if (_index == 0)
            {
                Debug.Log("Index == 0 creating T");
                return GetObject();
            }

            Debug.Log("Returning item. New size: " + (_index - 1).ToString());
            return _pool[--_index];
        }

        public void Release(T item)
        {
            Debug.Log(_index + " / " + _pool.Length);
            PoolBehaviourOnRelease(item);

            if (_index == _pool.Length)
            {
                Array.Resize(ref _pool, _pool.Length * 2);
                Debug.Log("New size: " + _pool.Length);
            }

            Debug.Log("Saving item at " + _index);
            _pool[_index++] = item;
        }

        public override void Clear()
        {
            Debug.Log("Clear " + _pool.Length + " elements");
            int size = _pool.Length;

            if (size > _index)
            {
                size = _index;
            }

            for (int i = 0; i < size; ++i)
            {
                ClearElement(i);
            }

            Debug.Log("Resize to 0");
            Array.Resize(ref _pool, 0);

            Debug.Log("GC collect");
            GC.Collect();
        }
    }
}