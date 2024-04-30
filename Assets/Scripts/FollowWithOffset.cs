using UnityEngine;

namespace NOJUMPO
{
    public enum FollowDirection
    {
        X, Y, Z, ALL
    }

    public class FollowWithOffset : MonoBehaviour
    {

        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] Transform transformToFollow;
        [SerializeField] Vector3 offset;

        [SerializeField] FollowDirection followDirection;


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void Update() {
            switch (followDirection)
            {
                case FollowDirection.ALL:
                    transform.position = transformToFollow.position + offset;
                    break;
                case FollowDirection.X:
                    transform.position = new Vector3(transformToFollow.position.x, transform.position.y, transform.position.z) + offset;
                    break;
                case FollowDirection.Y:
                    transform.position = new Vector3(transform.position.x, transformToFollow.position.y, transform.position.z) + offset;
                    break;
                case FollowDirection.Z:
                    transform.position = new Vector3(transform.position.x, transform.position.y, transformToFollow.position.z) + offset;
                    break;
                default:
                    break;
            }
        }


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public void Setup(Transform transformToFollow, Vector3 offset, FollowDirection direction) {
            this.transformToFollow = transformToFollow;
            this.offset = offset;
            followDirection = direction;
        }
    }
}