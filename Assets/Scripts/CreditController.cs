using HK.Framework.EventSystems;
using UniRx;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Pierrot
{
    /// <summary>
    /// クレジットを制御するクラス
    /// </summary>
    public sealed class CreditController : MonoBehaviour
    {
        [SerializeField]
        private IntReactiveProperty credit = new IntReactiveProperty(100);
        public IReactiveProperty<int> Credit => this.credit;

        private IntReactiveProperty paid = new IntReactiveProperty(0);
        public IReactiveProperty<int> Paid => this.paid;

        private IntReactiveProperty win = new IntReactiveProperty(0);
        public IReactiveProperty<int> Win => this.win;

        void Awake()
        {
            Broker.Global.Receive<FiredCoin>()
                .SubscribeWithState(this, (_, _this) =>
                {
                    _this.credit.Value--;
                })
                .AddTo(this);
        }
    }
}
