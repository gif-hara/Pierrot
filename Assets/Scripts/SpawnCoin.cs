using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Pierrot
{
    /// <summary>
    /// コインを生成するクラス
    /// </summary>
    public sealed class SpawnCoin : MonoBehaviour
    {
        [SerializeField]
        private Coin coinPrefab = null;

        [SerializeField]
        private Transform coinParent = null;

        [SerializeField]
        private float angleLimit = 45.0f;

        [SerializeField]
        private float speed = 1.0f;

        [SerializeField]
        private float power = 1.0f;

        private float initialAngle;

        void Start()
        {
            this.initialAngle = this.transform.localRotation.eulerAngles.z;
        }

        void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                this.Fire();
            }
            var angle = (Mathf.Sin(Time.time * this.speed)) * this.angleLimit;
            this.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, this.initialAngle + angle);
        }

        private void Fire()
        {
            var coin = this.coinPrefab.Rent();
            coin.transform.SetParent(this.coinParent);
            coin.transform.position = this.transform.position;
            var vector = this.transform.up;
            coin.Rigidbody2D.AddForce(vector * this.power);
        }
    }
}
