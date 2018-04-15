using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace Pool
{
    public class Pool<T> : PoolBase<T> where T : new()
    {

        public Pool(int id, int baseSize = -1, int numberOfElementsPreloaded = 0) : base(id) { }

        public override T GetObject()
        {
            return new T();
        }

        public override void PoolBehaviourOnRelease(T item) { }

        public override void ClearElement(int index)
        {
            Debug.Log(index + " / clear");
            _pool[index] = default(T);
        }
    }
}