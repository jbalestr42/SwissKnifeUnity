using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pool
{

    /// <summary>
    /// Abstract class for the pools
    /// </summary>
    public abstract class PoolAbstract
    {

        /// <summary>
        /// Id of the pool inside the Pool manager
        /// </summary>
        protected int _poolId;

        /// <summary>
        /// Curret index for the element inside the pool
        /// </summary>
        protected int _index = 0;

        /// <summary>
        /// Return the current id of the pool
        /// </summary>
        public int PoolId { get { return _poolId; } }

        /// <summary>
        /// Abstract function to clear the content of the pool
        /// </summary>
        public abstract void Clear();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id"></param>
        protected PoolAbstract(int id)
        {
            _poolId = id;
        }
    }
}