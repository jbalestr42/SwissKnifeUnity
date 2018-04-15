using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pool
{
    public abstract class PoolAbstract
    {
        protected int _poolId;
        protected int _index = 0;

        public int PoolId { get { return _poolId; } }

        public abstract void Clear();

        protected PoolAbstract(int id)
        {
            _poolId = id;
            Debug.Log("Pool id: " + _poolId);
        }
    }
}