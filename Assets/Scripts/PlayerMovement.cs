using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float horizontalMovementSpeed = 15.0f;
    [SerializeField] float verticalMovementSpeed = 10.0f;


    float _maxXPosition = 4.48f;
    float _verticalMovementSpeedMultiplier = 100.0f;
    float _horizontalMovementSpeedMultiplier = 50.0f;
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
        _moveDirection = _playerInput.actions["Move"].ReadValue<Vector2>();
    }

    void FixedUpdate() {
        Move();
    }

    void Move() {
        Vector3 moveDirection = new Vector3(horizontalMovementSpeed * _moveDirection.x * _horizontalMovementSpeedMultiplier, 
            0,
                verticalMovementSpeed * _verticalMovementSpeedMultiplier) * Time.fixedDeltaTime;
        _objectRigidbody.velocity = moveDirection;

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -_maxXPosition, _maxXPosition), transform.position.y, transform.position.z);
    }

    void StopMovement() {
        _objectRigidbody.velocity = Vector3.zero;
        enabled = false;
    }
}