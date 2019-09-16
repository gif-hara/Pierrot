using HK.Framework.EventSystems;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Pierrot
{
    /// <summary>
    /// コインを回収した際のイベント
    /// </summary>
    public sealed class CollectedCoin : Message<CollectedCoin>
    {
    }
}
