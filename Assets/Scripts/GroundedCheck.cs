using System;
using UnityEngine;

public class GroundedCheck : MonoBehaviour
{
    [SerializeField] Transform groundedCheckTransform;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Vector3 boxCastSize = new Vector3(0.5f, 0.025f, 0.275f);

    public bool IsGrounded { get; private set; }
    RaycastHit[] _raycastHit = new RaycastHit[1];

    public event Action OnGrounded;
    public event Action OnLeftGround;


    void FixedUpdate() {
        int hits = Physics.BoxCastNonAlloc(groundedCheckTransform.position, boxCastSize * 2, groundedCheckTransform.up * -1, _raycastHit, Quaternion.identity, 0, groundLayer);

        if (IsGrounded == false &&  hits == 1)
        {
            IsGrounded = true;
            OnGrounded?.Invoke();
            return;
        }

        if (IsGrounded == true && hits == 0)
        {
            IsGrounded = false;
            OnLeftGround?.Invoke();
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(groundedCheckTransform.position + groundedCheckTransform.up * -1 * 0, boxCastSize);
    }
}