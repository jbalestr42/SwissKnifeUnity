﻿using UnityEngine;
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
                Debug.Log("Index == 0 creating T");
                return GetObject();
            }

            Debug.Log("Returning item. New size: " + (_index - 1).ToString());
            return _pool[--_index];
        }

        /// <summary>
        /// Store an object inside the pool
        /// </summary>
        /// <param name="item">Item to be stored</param>
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

        /// <summary>
        /// Clear the pool by clearing all individual elements first
        /// </summary>
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