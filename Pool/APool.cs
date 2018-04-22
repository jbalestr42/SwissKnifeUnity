namespace SKU
{
    /// <summary>
    /// Abstract class for the pools
    /// </summary>
    public abstract class APool
    {
        /// <summary>
        /// Id of the pool inside the Pool manager
        /// </summary>
        protected int _poolId;

        /// <summary>
        /// Current index for the element inside the pool
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
        protected APool(int id)
        {
            _poolId = id;
        }
    }
}