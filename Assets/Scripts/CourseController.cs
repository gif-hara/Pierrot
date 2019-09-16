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
                    _this.OnEnteredCourse(x.CourseId);
                })
                .AddTo(this);

            Broker.Global.Receive<EnteredLucky>()
                .SubscribeWithState(this, (_, _this) =>
                {
                    _this.OnEnteredLucky();
                })
                .AddTo(this);

            Broker.Global.Receive<FiredCoin>()
                .SubscribeWithState(this, (_, _this) =>
                {
                    _this.floor.SetActive(true);
                })
                .AddTo(this);
        }

        private void OnEnteredCourse(int courseId)
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

        private void OnEnteredLucky()
        {

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
