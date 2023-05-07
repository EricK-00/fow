using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Rito.FogOfWar
{
    /// <summary> 안개 적용 대상 유닛 </summary>
    public class FowUnit : MonoBehaviour
    {
        /// <summary> xz 시야 범위 </summary>
        public float sightRange = 5;

        /// <summary> y 시야 범위 </summary>
        public float sightHeight = 0.5f;

        public bool isHidden = true;

        private List<Renderer> renderers = new List<Renderer>();

        private void Awake()
        {
            
            renderers.AddRange(GetComponentsInChildren<Renderer>());

        }

        private void LateUpdate()
        {
            if (gameObject == PlayerManager.Instance.Player)
                return;

            foreach (Renderer renderer in renderers)
            {
                renderer.forceRenderingOff = isHidden;
            }
        }

        void OnEnable() => FowManager.AddUnit(this);

        private void OnDisable() => FowManager.RemoveUnit(this);
        private void OnDestroy() => FowManager.RemoveUnit(this);
    }
}
