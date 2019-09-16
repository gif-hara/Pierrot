using System;
using HK.Framework.EventSystems;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace HK.Pierrot
{
    /// <summary>
    /// 入力を制御するクラス
    /// </summary>
    public sealed class InputController : MonoBehaviour
    {
        [SerializeField]
        private SpawnCoin spawnCoin = null;

        [SerializeField]
        private CreditController creditController = null;

        [SerializeField]
        private Button fireButton = null;

        [SerializeField]
        private Button collectButton = null;

        void Awake()
        {
            Observable.Merge(
                this.fireButton.OnClickAsObservable(),
                this.GetKeyDown(KeyCode.Space)
            )
                .SubscribeWithState(this, (_, _this) =>
                {
                    _this.spawnCoin.Fire();
                })
                .AddTo(this);

            Observable.Merge(
                this.collectButton.OnClickAsObservable(),
                this.GetKeyDown(KeyCode.C)
            )
            .SubscribeWithState(this, (_, _this) =>
            {
                _this.creditController.Collect();
            })
            .AddTo(this);

            this.collectButton.gameObject.SetActive(false);

            this.creditController.Win
                .SubscribeWithState(this, (x, _this) =>
                {
                    _this.collectButton.gameObject.SetActive(x > 0);
                })
                .AddTo(this);

            Broker.Global.Receive<FiredCoin>()
                .SubscribeWithState(this, (_, _this) =>
                {
                    _this.collectButton.gameObject.SetActive(false);
                })
                .AddTo(this);
        }

        private IObservable<Unit> GetKeyDown(KeyCode keyCode)
        {
            return this.UpdateAsObservable()
                .Where(_ => Input.GetKeyDown(keyCode))
                .AsUnitObservable();
        }
    }
}
