using HK.Framework;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Pierrot
{
    /// <summary>
    /// コインを制御するクラス
    /// </summary>
    public sealed class Coin : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody2D controlledRigidbody2D = null;
        public Rigidbody2D Rigidbody2D => this.controlledRigidbody2D;

        private static ObjectPoolBundle<Coin> pools = new ObjectPoolBundle<Coin>();

        private ObjectPool<Coin> pool;

        public Coin Rent()
        {
            var pool = pools.Get(this);
            var clone = pool.Rent();
            clone.pool = pool;

            return clone;
        }
    }
}
