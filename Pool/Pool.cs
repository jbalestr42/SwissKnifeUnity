using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace Pool
{
    /// <summary>
    /// This pool is used for all elements that can call "New()"
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Pool<T> : PoolBase<T> where T : new()
    {

        #region Constructor

        public Pool(int id, int baseSize = -1, int numberOfElementsPreloaded = 0) : base(id) { }

        #endregion

        /// <summary>
        /// Create a new T() object
        /// </summary>
        /// <returns>Return the object created</returns>
        protected override T GetObject()
        {
            return new T();
        }

        /// <summary>
        /// Set the item to its default value
        /// </summary>
        /// <param name="item">item to be stored in the pool</param>
        public override void PoolBehaviourOnRelease(T item)
        {
            item = default(T);
        }

        /// <summary>
        /// Force the object to its default value
        /// </summary>
        /// <param name="index">Index of an element</param>
        public override void ClearElement(int index)
        {
            _pool[index] = default(T);
        }
    }
}