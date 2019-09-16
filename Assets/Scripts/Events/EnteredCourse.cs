using HK.Framework.EventSystems;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Pierrot
{
    /// <summary>
    /// コースにコインが入った際のイベント
    /// </summary>
    public sealed class EnteredCourse : Message<EnteredCourse, int>
    {
        public int CourseId => this.param1;
    }
}
