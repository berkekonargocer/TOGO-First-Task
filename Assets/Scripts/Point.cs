using UnityEngine;
using UnityEngine.Events;

[DisallowMultipleComponent]
public class Point : MonoBehaviour, ICollectable
{
    [SerializeField] UnityEvent onCollected;


    public void Collect(Inventory inventory) {
        onCollected?.Invoke();
        SetParent(inventory.ItemCarryPosition);
        ResetTransform();
    }

    void SetParent(Transform parent) {
        transform.parent = parent;
    }

    void ResetTransform() {
        transform.localPosition = Vector3.zero;
    }
}