using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace Pool
{
    public class PoolObject<T> : PoolBase<T> where T : MonoBehaviour
    {
        private T _baseElement;
        private Transform _parent;

        #region Constructor

        public PoolObject(int id, T baseElement, Transform parent, int baseSize = -1, int numberOfElementsPreloaded = 0) : base (id)
        {
            _baseElement = baseElement;
            _parent = parent;
        }

        #endregion

        public override T GetObject()
        {
            return UnityEngine.Object.Instantiate(_baseElement, _parent);
        }

        public override void PoolBehaviourOnRelease(T item) {
            item.transform.SetParent(_parent);
        }

        public override void ClearElement(int index)
        {
            if (_pool[index] != null)
            {
                Debug.Log(index + " / Destroy");
                UnityEngine.Object.Destroy(_pool[index].gameObject);
            }
        }
    }
}