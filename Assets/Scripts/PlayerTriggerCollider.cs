using UnityEngine;

public class PlayerTriggerCollider : MonoBehaviour
{
    public static bool IS_INVULNERABLE { get; private set; } = false;

    Inventory _playerInventory;


    private void Awake() {
        _playerInventory = GetComponent<Inventory>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Collectable")) 
        {
            ICollectable collectable = other.gameObject.GetComponent<ICollectable>();
            collectable?.Collect(_playerInventory);
            return;
        }

        if (other.gameObject.CompareTag("Trigger"))
        {
            ITrigger triggerable = other.gameObject.GetComponent<ITrigger>();
            triggerable?.Trigger();
        }
    }


    public void SetInvulnerability(bool isInvulnerable) {
        IS_INVULNERABLE = isInvulnerable;
    }
}