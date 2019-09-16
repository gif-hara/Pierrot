using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Pierrot
{
    /// <summary>
    /// コインと衝突した際に処理を行うインターフェイス
    /// </summary>
    public interface IOnTriggerEnterCoin
    {
        void Do(Coin coin);
    }
}
