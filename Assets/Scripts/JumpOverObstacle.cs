using DG.Tweening;
using UnityEngine;

namespace NOJUMPO
{
    public class JumpOverObstacle : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] Transform raycastStartTransform;
        [SerializeField] float obstacleCheckRayLength;
        [SerializeField] LayerMask jumpObstacleLayer;

        Rigidbody _objectRigidbody;
        GroundedCheck _groundedCheck;

        RaycastHit[] _raycastResult = new RaycastHit[1];

        const float JUMP_FORCE = 65.0f;
        const float JUMP_FORCE_MULTIPLIER = 5.0f;
        const float ON_AIR_GRAVITY = -24.81f;


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
            _objectRigidbody.velocity = new Vector3(_objectRigidbody.velocity.x, 0, _objectRigidbody.velocity.z);
            _objectRigidbody.AddForce(_objectRigidbody.transform.up * JUMP_FORCE * JUMP_FORCE_MULTIPLIER * Time.fixedDeltaTime, ForceMode.Impulse);
        }

        void SetGroundedDrag() {
            Physics.gravity = new Vector3(Physics.gravity.x, -9.81f, Physics.gravity.z);
        }

        void SetAirDrag() {
            Physics.gravity = new Vector3(Physics.gravity.x, ON_AIR_GRAVITY, Physics.gravity.z);
        }
    }
}