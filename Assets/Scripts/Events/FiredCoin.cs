using HK.Framework.EventSystems;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Pierrot
{
    /// <summary>
    /// コインを発射した際のイベント
    /// </summary>
    public sealed class FiredCoin : Message<FiredCoin>
    {
    }
}
