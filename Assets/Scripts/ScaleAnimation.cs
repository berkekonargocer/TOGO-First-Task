using DG.Tweening;
using UnityEngine;

namespace NOJUMPO
{
    public class ScaleAnimation : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] Vector3 targetScale;
        [SerializeField] float animationDuration;

        Tween _scaleAnim;


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void OnDestroy() {
            _scaleAnim.Kill();
        }

        void Start() {
            _scaleAnim = transform.DOScale(targetScale, animationDuration).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
        }
    }
}