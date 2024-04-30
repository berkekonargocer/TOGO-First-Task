using UnityEngine;

namespace NOJUMPO
{
    public class SmoothFollow : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] Transform transformToFollow;
        [SerializeField] Vector3 offset;

        [SerializeField] float speed;

        [SerializeField] FollowDirection followDirection;

        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void FixedUpdate() {
            switch (followDirection)
            {
                case FollowDirection.ALL:
                    transform.position = Vector3.Lerp(transform.position, transformToFollow.position + offset, speed * Time.fixedDeltaTime);
                    break;
                case FollowDirection.X:
                    transform.position = new Vector3(Mathf.Lerp(transform.position.x, transformToFollow.position.x, speed * Time.fixedDeltaTime), transform.position.y, transform.position.z) + offset;
                    break;
                case FollowDirection.Y:
                    transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, transformToFollow.position.y, speed * Time.fixedDeltaTime), transform.position.z) + offset;
                    break;
                case FollowDirection.Z:
                    transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Lerp(transform.position.z, transformToFollow.position.z, speed * Time.fixedDeltaTime)) + offset;
                    break;
                default:
                    break;
            }
        }


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public void Setup(Transform transformToFollow, Vector3 offset, FollowDirection direction, float speed) {
            this.transformToFollow = transformToFollow;
            this.offset = offset;
            followDirection = direction;
            this.speed = speed;
        }

        // ------------------------ CUSTOM PROTECTED METHODS -----------------------


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
    }
}