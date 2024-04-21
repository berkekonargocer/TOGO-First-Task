using UnityEngine;

namespace NOJUMPO
{
    public class JumpOverObstacle : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] Transform raycastStartTransform;
        [SerializeField] float obstacleCheckRayLength;
        [SerializeField] LayerMask jumpObstacleLayer;

        [SerializeField] float jumpForce;

        Rigidbody _objectRigidbody;
        GroundedCheck _groundedCheck;

        RaycastHit[] _raycastResult = new RaycastHit[1];

        const float JUMP_FORCE_MULTIPLIER = 5.0f;


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void Awake() {
            _objectRigidbody = GetComponent<Rigidbody>();
            _groundedCheck = GetComponent<GroundedCheck>();
        }

        void OnEnable() {
            GroundedCheck.OnGrounded += SetGroundedDrag;
            GroundedCheck.OnLeftGround += SetAirDrag;
        }

        private void OnDisable() {
            GroundedCheck.OnGrounded -= SetGroundedDrag;
            GroundedCheck.OnLeftGround -= SetAirDrag;
        }

        void FixedUpdate() {
            int hits = Physics.RaycastNonAlloc(raycastStartTransform.position, raycastStartTransform.forward, _raycastResult, obstacleCheckRayLength, jumpObstacleLayer);

            if (hits == 0)
                return;

            if (_groundedCheck.IsGrounded)
            {
                Jump();
            }
        }


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        void Jump() {
            _objectRigidbody.AddForce(_objectRigidbody.transform.up * jumpForce * JUMP_FORCE_MULTIPLIER * Time.fixedDeltaTime, ForceMode.Impulse);
        }

        void SetGroundedDrag() {
            Physics.gravity = new Vector3(Physics.gravity.x, -9.81f, Physics.gravity.z);
        }

        void SetAirDrag() {
            Physics.gravity = new Vector3(Physics.gravity.x, -24.81f, Physics.gravity.z);
        }
    }
}