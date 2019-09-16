using HK.Framework.EventSystems;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Pierrot
{
    /// <summary>
    /// コインがラッキーコースに入ったことを通知するクラス
    /// </summary>
    public sealed class OnTriggerEnterCoinEnteredLucky : MonoBehaviour, IOnTriggerEnterCoin
    {
        void IOnTriggerEnterCoin.Do(Coin coin)
        {
            Broker.Global.Publish(EnteredLucky.Get());
        }
    }
}
