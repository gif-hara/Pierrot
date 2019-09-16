using HK.Framework.EventSystems;
using UniRx;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Pierrot
{
    /// <summary>
    /// コース部分を制御するクラス
    /// </summary>
    public sealed class CourseController : MonoBehaviour
    {
        [SerializeField]
        private int courseNumber = 0;

        [SerializeField]
        private GameObject floor = null;

        private bool[] courseFlags;

        void Awake()
        {
            this.courseFlags = new bool[this.courseNumber];
            Broker.Global.Receive<EnteredCourse>()
                .SubscribeWithState(this, (x, _this) =>
                {
                    _this.Enter(x.CourseId);
                })
                .AddTo(this);
        }

        private void Enter(int courseId)
        {
            if(this.courseFlags[courseId])
            {
                this.GameOver();
            }
            else
            {
                this.courseFlags[courseId] = true;
            }
        }

        private void GameOver()
        {
            for (var i = 0; i < this.courseFlags.Length; i++)
            {
                this.courseFlags[i] = false;
            }

            this.floor.SetActive(false);
        }
    }
}
