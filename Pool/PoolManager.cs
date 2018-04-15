using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pool
{

    /// <summary>
    /// Class that creates and manages all the pools
    /// </summary>
    public class PoolManager
    {
        /// <summary>
        /// Array of pool
        /// </summary>
        private PoolAbstract[] _pools;

        /// <summary>
        /// Current index for the pool
        /// </summary>
        private int _poolsKey;

        /// <summary>
        /// Get the current pool index. Automatic increment and resize
        /// </summary>
        private int PoolsKey {
            get {
                if (_poolsKey >= _pools.Length)
                {
                    Array.Resize(ref _pools, _pools.Length * 2);
                }

                return _poolsKey++;
            }
        }

        #region Constructor

        public PoolManager()
        {
            _poolsKey = 0;
            _pools = new PoolAbstract[1];
        }

        #endregion

        #region Add Pool

        public Pool<T> AddPool<T>(int baseSize = -1, int numberOfElementsPreloaded = 0) where T : new()
        {
            int key = PoolsKey;
            Pool<T> pool = new Pool<T>(key, baseSize, numberOfElementsPreloaded);
            _pools[key] = pool;

            return pool;
        }

        public PoolObject<T> AddPool<T>(T baseElement, Transform parent, int baseSize = -1, int numberOfElementsPreloaded = 0) where T : MonoBehaviour
        {
            int key = PoolsKey;
            PoolObject<T> pool = new PoolObject<T>(key, baseElement, parent, baseSize, numberOfElementsPreloaded);
            _pools[key] = pool;

            return pool;
        }

        #endregion

        #region Destroy Pool

        /// <summary>
        /// Clear the pool manager and destroy all pools
        /// </summary>
        public void ClearPools()
        {
            Debug.LogWarning("Destroy all pools");

            for (int i = 0; i < _pools.Length; ++i)
            {
                if (_pools[i] != null)
                {
                    DestroyPool(_pools[i]);
                }
            }

            Array.Resize(ref _pools, 0);
            Debug.Log("Size for pool manager: " + _pools.Length);

            GC.Collect();
        }

        /// <summary>
        /// Clear a specific pool
        /// </summary>
        /// <param name="poolToDestroy">Pool to be destroyed</param>
        public void DestroyPool(PoolAbstract poolToDestroy)
        {
            if (poolToDestroy.PoolId >= _pools.Length)
            {
                Debug.LogError(poolToDestroy.PoolId + " > " + _pools.Length);
                return;
            }

            Debug.Log("Pools size: " + _pools.Length);
            Debug.Log("Destroy the pool at index: " + poolToDestroy.PoolId);

            if (_pools[poolToDestroy.PoolId] != null)
            {
                _pools[poolToDestroy.PoolId].Clear();
                _pools[poolToDestroy.PoolId] = null;

                GC.Collect();
            }
            else
            {
                Debug.Log("Pool already destroyed");
            }
        }

        #endregion
    }
}