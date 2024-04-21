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
        RaycastHit[] _raycastResult = new RaycastHit[1];
        Rigidbody _objectRigidbody;

        const float JUMP_FORCE_MULTIPLIER = 5.0f;


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void Awake() {
            _objectRigidbody = GetComponent<Rigidbody>();
        }

        void FixedUpdate() {
            int hits = Physics.RaycastNonAlloc(raycastStartTransform.position, raycastStartTransform.forward, _raycastResult, obstacleCheckRayLength, jumpObstacleLayer);

            for (int i = 0; i < hits; i++)
            {
                Debug.Log("Hit " + _raycastResult[i].collider.gameObject.name);
                Jump();
            }
        }


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        void Jump() {
            _objectRigidbody.AddForce(_objectRigidbody.transform.up * jumpForce * JUMP_FORCE_MULTIPLIER * Time.fixedDeltaTime, ForceMode.Impulse);
        }
    }
}