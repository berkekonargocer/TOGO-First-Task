using UnityEngine;

public class PlayerTriggerCollider : MonoBehaviour
{
    public static bool IS_INVULNERABLE { get; private set; } = false;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Collectable")) 
        {
            ICollectable collectable = other.gameObject.GetComponent<ICollectable>();
            collectable.Collect();
        }
    }

    public void SetInvulnerability(bool isInvulnerable) {
        IS_INVULNERABLE = isInvulnerable;
    }
}