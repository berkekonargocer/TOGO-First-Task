using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerInput))]
public class AutoForwardMovement : MonoBehaviour
{
    [field: SerializeField] public float HorizontalMovementSpeed { get; private set; } = 8.0f;
    [field: SerializeField] public float VerticalMovementSpeed { get; private set; } = 10.0f;

    PlayerInput _playerInput;
    Rigidbody _objectRigidbody;

    Vector2 _moveDirection;

    const float MAX_X_POSITION = 4.48f;
    const float VERTICAL_MOVEMENT_SPEED_MULTIPLIER = 50.0f;
    const float HORIZONTAL_MOVEMENT_SPEED_MULTIPLIER = 20.0f;


    void OnEnable() {
        GameManager.Instance.OnWinGame += StopMovement;
        GameManager.Instance.OnLoseGame += StopMovement;
    }

    void OnDisable() {
        GameManager.Instance.OnWinGame -= StopMovement;
        GameManager.Instance.OnLoseGame -= StopMovement;
    }

    void Awake() {
        _objectRigidbody = GetComponent<Rigidbody>();
        _playerInput = GetComponent<PlayerInput>();
    }

    void Update() {
        GetMovementDirection();
    }

    void FixedUpdate() {
        ApplyMovement();
    }

    public void IncrementVerticalMovementSpeed(float speedToAddUp) {
        VerticalMovementSpeed += speedToAddUp;
    }

    public void SetVerticalMovementSpeed(float speed) {
        VerticalMovementSpeed = speed;
    }

    Vector3 GetMovementDirection() {
        if (_playerInput.actions["LeftClick"].ReadValue<float>() == 0)
        {
            _moveDirection = Vector3.zero;
        }
        else
        {
            _moveDirection = _playerInput.actions["Move"].ReadValue<Vector2>();
        }

        Vector3 moveDirection = new Vector3(HorizontalMovementSpeed * _moveDirection.x * HORIZONTAL_MOVEMENT_SPEED_MULTIPLIER, 0, VerticalMovementSpeed * VERTICAL_MOVEMENT_SPEED_MULTIPLIER) * Time.fixedDeltaTime;

        return moveDirection;
    }

    void ApplyMovement() {
        _objectRigidbody.velocity = GetMovementDirection();
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -MAX_X_POSITION, MAX_X_POSITION), transform.position.y, transform.position.z);
    }

    void StopMovement(int score) {
        _objectRigidbody.velocity = Vector3.zero;
        enabled = false;
    }
}