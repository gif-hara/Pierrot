using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Pierrot
{
    /// <summary>
    /// クレジットUIを制御するクラス
    /// </summary>
    public sealed class CreditUIController : MonoBehaviour
    {
        [SerializeField]
        private TextMeshPro credit = null;

        [SerializeField]
        private TextMeshPro paid = null;

        [SerializeField]
        private TextMeshPro win = null;

        [SerializeField]
        private CreditController creditController = null;

        void Awake()
        {
            this.creditController.Credit
                .SubscribeWithState(this, (x, _this) =>
                {
                    _this.credit.text = x.ToString();
                })
                .AddTo(this);

            this.creditController.Paid
                .SubscribeWithState(this, (x, _this) =>
                {
                    _this.paid.text = x.ToString();
                })
                .AddTo(this);

            this.creditController.Win
                .SubscribeWithState(this, (x, _this) =>
                {
                    _this.win.text = x.ToString();
                })
                .AddTo(this);
        }
    }
}
