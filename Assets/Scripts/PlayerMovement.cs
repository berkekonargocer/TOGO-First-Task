using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float horizontalMovementSpeed = 15.0f;
    [SerializeField] float verticalMovementSpeed = 10.0f;

    float _verticalMovementSpeedModifier = 100.0f;
    float _horizontalMovementSpeedModifier = 50.0f;
    Vector2 _moveDirection;

    PlayerInput playerInput;
    Rigidbody objectRigidbody;

    void Awake() {
        objectRigidbody = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
    }

    void Update() {
        _moveDirection = playerInput.actions["Move"].ReadValue<Vector2>();
    }

    void FixedUpdate() {
        Move();
    }

    void Move() {
        Vector3 moveDirection = new Vector3(horizontalMovementSpeed * _moveDirection.x * _horizontalMovementSpeedModifier, 0, verticalMovementSpeed * _verticalMovementSpeedModifier) * Time.fixedDeltaTime;
        objectRigidbody.velocity = moveDirection;
    }
}