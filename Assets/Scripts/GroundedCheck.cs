using System;
using UnityEngine;

public class GroundedCheck : MonoBehaviour
{
    [SerializeField] Transform groundedCheckTransform;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Vector3 groundedCheckSize;

    public bool IsGrounded { get; private set; }
    RaycastHit[] _raycastHit = new RaycastHit[1];

    public static event Action OnGrounded;
    public static event Action OnLeftGround;


    void FixedUpdate() {
        int hits = Physics.BoxCastNonAlloc(groundedCheckTransform.position, groundedCheckSize * 2, groundedCheckTransform.up * -1, _raycastHit, Quaternion.identity, 0, groundLayer);

        if (IsGrounded == false &&  hits == 1)
        {
            IsGrounded = true;
            OnGrounded?.Invoke();
            Debug.Log($"Is in ground: {IsGrounded}");
            return;
        }

        if (IsGrounded == true && hits == 0)
        {
            IsGrounded = false;
            OnLeftGround?.Invoke();
        }

        Debug.Log($"Is in ground: {IsGrounded}");
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(groundedCheckTransform.position + groundedCheckTransform.up * -1 * 0, groundedCheckSize);
    }
}