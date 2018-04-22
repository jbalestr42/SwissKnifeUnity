using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace SKU
{
    /// <summary>
    /// This pool is used for the Monobehaviour elements to be pooled
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PoolObject<T> : PoolBase<T> where T : MonoBehaviour
    {
        /// <summary>
        /// Monobehaviour element to instantiated
        /// </summary>
        private T _baseElement;

        /// <summary>
        /// Parent of the object for the parenting
        /// </summary>
        private Transform _parent;

        #region Constructor

        public PoolObject(int id, T baseElement, Transform parent, int baseSize, Action<T> resetFunction) : base(id, baseSize, resetFunction)
        {
            _baseElement = baseElement;
            _parent = parent;

            InitPool();
        }

        #endregion

        /// <summary>
        /// Instantiate a new Object with the Unity method
        /// </summary>
        /// <returns></returns>
        protected override T GetObject()
        {
            return UnityEngine.Object.Instantiate(_baseElement, _parent);
        }

        /// <summary>
        /// Set the parent of the released item to pool parent
        /// </summary>
        /// <param name="item"></param>
        public override void PoolBehaviourOnRelease(T item) {
            item.transform.SetParent(_parent);
        }
    
        /// <summary>
        /// Destroy the gameObject contained at a specific index
        /// </summary>
        /// <param name="index">Index of the object to be destroyed</param>
        public override void ClearElement(int index)
        {
            if (_pool[index] != null)
            {
                UnityEngine.Object.Destroy(_pool[index].gameObject);
            }
        }
    }
}