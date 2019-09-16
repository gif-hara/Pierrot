using HK.Framework.EventSystems;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Pierrot
{
    /// <summary>
    /// コインがコースに入ったことを通知するクラス
    /// </summary>
    public sealed class OnTriggerEnterCoinEnteredCourse : MonoBehaviour, IOnTriggerEnterCoin
    {
        [SerializeField]
        private int id;
        
        void IOnTriggerEnterCoin.Do(Coin coin)
        {
            Broker.Global.Publish(EnteredCourse.Get(this.id));
        }
    }
}
