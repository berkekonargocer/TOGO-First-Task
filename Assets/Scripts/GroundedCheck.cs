using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedCheck : MonoBehaviour
{
    [SerializeField] Transform groundedCheckTransform;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Vector3 groundedCheckSize;
    [SerializeField] float groundedCheckLength;
    public bool IsGrounded { get; private set; }
    RaycastHit[] _raycastHit = new RaycastHit[1];


    void FixedUpdate() {
        int hits = Physics.BoxCastNonAlloc(groundedCheckTransform.position, groundedCheckSize * 2, groundedCheckTransform.up * -1, _raycastHit, Quaternion.identity, groundedCheckLength, groundLayer);

        IsGrounded = hits > 0;
        Debug.Log($"Is in ground: {IsGrounded}");
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(groundedCheckTransform.position + groundedCheckTransform.up * -1 * groundedCheckLength, groundedCheckSize);
    }
}