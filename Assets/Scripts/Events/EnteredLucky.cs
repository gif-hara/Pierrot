using HK.Framework.EventSystems;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Pierrot
{
    /// <summary>
    /// ラッキーコースにコインが入った際のイベント
    /// </summary>
    public sealed class EnteredLucky : Message<EnteredLucky>
    {
    }
}
