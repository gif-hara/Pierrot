using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Pierrot
{
    /// <summary>
    /// 入力を制御するクラス
    /// </summary>
    public sealed class InputController : MonoBehaviour
    {
        [SerializeField]
        private SpawnCoin spawnCoin = null;

        [SerializeField]
        private CreditController creditController = null;

        void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                this.spawnCoin.Fire();
            }

            if(Input.GetKeyDown(KeyCode.C))
            {
                this.creditController.Collect();
            }
        }
    }
}
