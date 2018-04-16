using UnityEngine;
using System;

namespace SKU
{
    public abstract class PoolBase<T> : APool
    {
        protected T[] _pool = new T[1];

        #region Constructor

        public PoolBase(int id, int baseSize) : base(id)
        {
            if (baseSize > -1)
            {
                Array.Resize(ref _pool, baseSize);
            }
        }

        #endregion

        /// <summary>
        /// Initialize the pool with a defined number of item
        /// </summary>
        /// <param name="baseSize">Base size of the pool</param>
        protected void InitPool()
        {
            for (int i = 0; i < _pool.Length; ++i)
            {
                Release(GetObject());
            }
        }

        /// <summary>
        /// Function to create an object of the type in the pool
        /// </summary>
        /// <returns>Return the object created</returns>
        protected abstract T GetObject();

        /// <summary>
        /// Do the behaviour relative to the pool when releasing an object
        /// </summary>
        /// <param name="item">Item to modify for the release</param>
        public abstract void PoolBehaviourOnRelease(T item);

        /// <summary>
        /// When clearing the pool, this function do behaviour based on the pool type
        /// </summary>
        /// <param name="index">Index of the object to clear</param>
        public abstract void ClearElement(int index);

        /// <summary>
        /// If no more objects are contained inside the pool, create one. Else return the first in the pool
        /// </summary>
        /// <returns></returns>
        public T GetItem()
        {
            if (_index == 0)
            {
                return GetObject();
            }

            return _pool[--_index];
        }

        /// <summary>
        /// Store an object inside the pool
        /// </summary>
        /// <param name="item">Item to be stored</param>
        public void Release(T item)
        {
            PoolBehaviourOnRelease(item);

            if (_index == _pool.Length)
            {
                Array.Resize(ref _pool, _pool.Length * 2);
            }

            _pool[_index++] = item;
        }

        /// <summary>
        /// Clear the pool by clearing all individual elements first
        /// </summary>
        public override void Clear()
        {
            int size = _pool.Length;

            if (size > _index)
            {
                size = _index;
            }

            for (int i = 0; i < size; ++i)
            {
                ClearElement(i);
            }

            Array.Resize(ref _pool, 0);
            GC.Collect();
        }
    }
}