using UnityEngine;
using System;

namespace SKU
{
    public abstract class PoolBase<T> : APool
    {
        protected T[] _pool;

        /// <summary>
        /// Reset function called when an object is released inside the pool
        /// </summary>
        protected Action<T> _resetObjectFunction;

        #region Constructor

        public PoolBase(int id, int baseSize, Action<T> resetFuncion) : base(id)
        {
            _pool = new T[baseSize];
            _resetObjectFunction = resetFuncion;
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
                _pool[i] = GetObject();
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
            T item;
            if (_index == 0)
            {
                item = GetObject();
            } else {
                item = _pool[--_index];
            }

            //Reset the item before returning it to the asking class
            _resetObjectFunction(item);

            return item;
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