using UnityEngine;

[DisallowMultipleComponent]
public class PlayerCollider : MonoBehaviour
{
    public static bool IS_INVULNERABLE { get; private set; } = false;

    Inventory _playerInventory;


    void Awake() {
        _playerInventory = GetComponent<Inventory>();
    }

    void OnTriggerEnter(Collider other) {
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

    void OnCollisionEnter(Collision collision) {

    }


    public void SetInvulnerability(bool isInvulnerable) {
        IS_INVULNERABLE = isInvulnerable;
    }
}