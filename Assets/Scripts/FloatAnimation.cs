using DG.Tweening;
using UnityEngine;

public class FloatAnimation : MonoBehaviour
{
    [SerializeField] float floatAnimationDuration = 1.0f;
    [SerializeField] float floatOffset = 0.25f;

    [SerializeField] bool rotate = false;
    [SerializeField] Vector3 rotateVector;
    [SerializeField] float rotateAnimationDuration = 4.0f;

    Tween floatTween;
    Tween rotateTween;

    void Awake() {
        floatTween = transform.DOMoveY(floatOffset, floatAnimationDuration).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo).SetRelative();

        if (rotate)
        {
            rotateTween = transform.DORotate(rotateVector, rotateAnimationDuration, RotateMode.FastBeyond360).SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart); 
        }
    }

    private void OnDestroy() {
        floatTween.Kill();
        rotateTween.Kill();
    }
}