using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Pierrot
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class GameSystem : MonoBehaviour
    {
        [SerializeField]
        private int targetFrameRate = 0;

        void Awake()
        {
            Application.targetFrameRate = this.targetFrameRate;
        }
    }
}
