using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Pierrot
{
    /// <summary>
    /// コインをPoolへ返却するクラス
    /// </summary>
    public sealed class OnTriggerEnterCoinReturnToPool : MonoBehaviour, IOnTriggerEnterCoin
    {
        void IOnTriggerEnterCoin.Do(Coin coin)
        {
            coin.ReturnToPool();
        }
    }
}
