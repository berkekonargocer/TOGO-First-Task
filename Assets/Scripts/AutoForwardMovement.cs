using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerInput))]
public class AutoForwardMovement : MonoBehaviour
{
    [SerializeField] float horizontalMovementSpeed = 15.0f;
    [SerializeField] float verticalMovementSpeed = 10.0f;

    [SerializeField] bool autoMoveForward;

    float _maxXPosition = 4.48f;
    float _movementSpeedMultiplier = 50.0f;
    Vector2 _moveDirection;

    PlayerInput _playerInput;
    Rigidbody _objectRigidbody;


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

    private Vector3 GetMovementDirection() {
        _moveDirection = _playerInput.actions["Move"].ReadValue<Vector2>();

        Vector3 moveDirection;

        if (autoMoveForward)
        {
            moveDirection = new Vector3(horizontalMovementSpeed * _moveDirection.x, 0, verticalMovementSpeed) * _movementSpeedMultiplier * Time.fixedDeltaTime;
            return moveDirection;
        }

        moveDirection = new Vector3(horizontalMovementSpeed * _moveDirection.x, 0, verticalMovementSpeed * _moveDirection.y) * _movementSpeedMultiplier * Time.fixedDeltaTime;
        return moveDirection;
    }

    void ApplyMovement() {
        if (autoMoveForward)
        {
            _objectRigidbody.velocity = GetMovementDirection();
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -_maxXPosition, _maxXPosition), transform.position.y, transform.position.z);
            return;
        }

        _objectRigidbody.MovePosition(_objectRigidbody.position + GetMovementDirection());
    }

    void StopMovement() {
        _objectRigidbody.velocity = Vector3.zero;
        enabled = false;
    }
}