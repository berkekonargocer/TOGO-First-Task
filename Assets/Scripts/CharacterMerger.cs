using UnityEngine;
using UnityEngine.InputSystem;

namespace NOJUMPO
{
    public class CharacterMerger : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] GameObject leftCharacter, rightCharacter, middleCharacter;
        [SerializeField] float moveSensitivity;
        PlayerInput _playerInput;
        Vector2 _moveDirection;
        const float MAX_X_POSITION = 4.85f;

        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void Awake() {
            _playerInput = GetComponent<PlayerInput>();
        }

        void Update() {
            ApplyMovement();
            TryMerge();
        }

        // ------------------------- CUSTOM PUBLIC METHODS -------------------------


        // ------------------------ CUSTOM PROTECTED METHODS -----------------------


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        void ApplyMovement() {
            if (_playerInput.actions["LeftClick"].ReadValue<float>() == 0)
            {
                _moveDirection = Vector3.zero;
            }
            else
            {
                _moveDirection = _playerInput.actions["Move"].ReadValue<Vector2>();
            }

            Vector3 rightCharacterPosition = rightCharacter.transform.position;
            rightCharacterPosition.x = Mathf.Clamp(rightCharacterPosition.x + (_moveDirection.x * moveSensitivity * Time.deltaTime), -MAX_X_POSITION, MAX_X_POSITION);
            rightCharacter.transform.position = rightCharacterPosition;

            leftCharacter.transform.position = Vector3.Reflect(rightCharacter.transform.position, Vector3.right);
        }

        void TryMerge() {
            float distance = Vector3.Distance(leftCharacter.transform.position, rightCharacter.transform.position);

            if (distance <= 0.5f)
            {
                middleCharacter.SetActive(true);
                leftCharacter.SetActive(false);
                rightCharacter.SetActive(false);
            }
            else
            {
                middleCharacter.SetActive(false);
                leftCharacter.SetActive(true);
                rightCharacter.SetActive(true);
            }
        }
    }
}