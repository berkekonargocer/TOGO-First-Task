using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

[DisallowMultipleComponent]
public class Obstacle : MonoBehaviour, ICollectable
{
    [SerializeField] UnityEvent onCollected;

    bool _moveRight;

    const float MAX_X_POSITION = 4.48f;
    const float DESIRED_MOVE_DURATION = 2f;


    void Awake() {
        GetRandomStartPosition();
        StartCoroutine(MoveLeftAndRight());
    }


    public void Collect() {
        onCollected?.Invoke();
        Destroy(gameObject);
    }


    IEnumerator MoveLeftAndRight() {
        Vector3 initialPosition = transform.position;
        Vector3 desiredPosition = DesiredMovePosition();
        float elapsedTime = 0;

        while (transform.position != desiredPosition)
        {
            elapsedTime += Time.deltaTime;
            float percentageCompleted = elapsedTime / DESIRED_MOVE_DURATION;
            transform.position = Vector3.Lerp(initialPosition, desiredPosition, percentageCompleted);
            yield return null;
        }

        transform.position = desiredPosition;
        StartCoroutine(MoveLeftAndRight());
    }

    void GetRandomStartPosition() {
        int startPos = Random.Range(0, 2);

        if (startPos == 0)
        {
            transform.position = new Vector3(-MAX_X_POSITION, transform.position.y, transform.position.z);
            _moveRight = true;
            return;
        }

        transform.position = new Vector3(MAX_X_POSITION, transform.position.y, transform.position.z);
        _moveRight = false;
        return;
    }

    Vector3 DesiredMovePosition() {
        if (_moveRight)
        {
            _moveRight = !_moveRight;
            return new Vector3(MAX_X_POSITION, transform.position.y, transform.position.z);
        }

        _moveRight = !_moveRight;
        return new Vector3(-MAX_X_POSITION, transform.position.y, transform.position.z);
    }
}