using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SKU
{

    /// <summary>
    /// Class that creates and manages all the pools
    /// </summary>
    [CreateAssetMenu(fileName = "PoolsManager", menuName = "SKU/Managers/Pools Manager")]
    public class PoolManager: AManagers
    {
        /// <summary>
        /// Array of pool
        /// </summary>
        private APool[] _pools;

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

        public static PoolManager Instance
        {
            get { return GameManager.Instance.Get(typeof(PoolManager)) as PoolManager; }
        }

        #region Methods

        #region Add Pool

        public Pool<T> AddPool<T>(int baseSize, Action<T> resetFunction) where T : new()
        {
            int key = PoolsKey;
            Pool<T> pool = new Pool<T>(key, baseSize, resetFunction);
            _pools[key] = pool;

            return pool;
        }

        public PoolObject<T> AddPool<T>(T baseElement, Transform parent, int baseSize, Action<T> resetFunction) where T : MonoBehaviour
        {
            int key = PoolsKey;
            PoolObject<T> pool = new PoolObject<T>(key, baseElement, parent, baseSize, resetFunction);
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
            for (int i = 0; i < _pools.Length; ++i)
            {
                if (_pools[i] != null)
                {
                    DestroyPool(_pools[i]);
                }
            }

            Array.Resize(ref _pools, 0);
            GC.Collect();
        }

        /// <summary>
        /// Clear a specific pool
        /// </summary>
        /// <param name="poolToDestroy">Pool to be destroyed</param>
        public void DestroyPool(APool poolToDestroy)
        {
            if (poolToDestroy.PoolId >= _pools.Length)
            {
                return;
            }

            if (_pools[poolToDestroy.PoolId] != null)
            {
                _pools[poolToDestroy.PoolId].Clear();
                _pools[poolToDestroy.PoolId] = null;

                GC.Collect();
            }
            else
            {
                Debug.LogWarning("Pool already destroyed");
            }
        }

        #endregion

        public override void Init()
        {
            _poolsKey = 0;
            _pools = new APool[1];
        }

        #endregion
    }
}