using DG.Tweening;
using UnityEngine;

public class MoveBackAndForth : MonoBehaviour
{
    [SerializeField] bool moveVertical;
    [SerializeField] float desiredMoveDuration = 2f;
    [SerializeField] float verticalMoveLimit = 4f;
    [SerializeField] float maxXPosition = 4.48f;

    bool _moveRight;
    bool _moveForward;

    Tween moveTween;


    void Awake() {
        if (!moveVertical)
        {
            SetStartPositionX();
            MoveHorizontal();
            return;
        }

        MoveVertical();
    }

    private void MoveVertical() {
        _moveForward = GetRandomFlag();

        if (!_moveForward)
        {
            verticalMoveLimit = -verticalMoveLimit;
        }

        moveTween = transform.DOMoveZ(verticalMoveLimit, desiredMoveDuration).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo).SetRelative();
    }

    private void MoveHorizontal() {
        if (_moveRight)
        {
            moveTween = transform.DOMoveX(maxXPosition, desiredMoveDuration).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
            return;
        }

        moveTween = transform.DOMoveX(-maxXPosition, desiredMoveDuration).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
        return;
    }

    void SetStartPositionX() {
        int startPos = Random.Range(0, 2);

        if (startPos == 0)
        {
            transform.position = new Vector3(-maxXPosition, transform.position.y, transform.position.z);
            _moveRight = true;
            return;
        }

        transform.position = new Vector3(maxXPosition, transform.position.y, transform.position.z);
        _moveRight = false;
        return;
    }

    bool GetRandomFlag() {
        int randomNumber = Random.Range(0, 2);

        if (randomNumber == 0)
        {
            return true;
        }

        return false;
    }

    private void OnDestroy() {
        moveTween.Kill();
    }
}