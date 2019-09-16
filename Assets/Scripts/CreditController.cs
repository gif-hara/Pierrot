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

            Broker.Global.Receive<FiredCoin>()
                .SubscribeWithState(this, (_, _this) =>
                {
                    _this.paid.Value = 0;
                })
                .AddTo(this);
        }

        public void SetWin(int value)
        {
            this.win.Value = value;
        }

        public void Collect()
        {
            if(this.win.Value <= 0)
            {
                return;
            }

            this.paid.Value = this.win.Value;
            this.credit.Value += this.win.Value;
            this.win.Value = 0;

            Broker.Global.Publish(CollectedCoin.Get());
        }
    }
}
