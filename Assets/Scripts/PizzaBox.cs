using UnityEngine;
using UnityEngine.Events;

[DisallowMultipleComponent]
public class PizzaBox : MonoBehaviour, ICollectable
{
    [SerializeField] UnityEvent onCollected;
    FloatAnimation _floatAnimation;


    private void Awake() {
        _floatAnimation = GetComponent<FloatAnimation>();
    }

    public void Collect(Inventory inventory) {
        Destroy(_floatAnimation);
        _floatAnimation = null;

        onCollected?.Invoke();
        inventory.AddItem(this);
    }

    void SetParent(Transform parent) {
        transform.parent = parent;
    }

    void ResetTransform() {
        transform.localPosition = Vector3.zero;
    }

    void RandomizeYRotation() {
        transform.localRotation = Quaternion.Euler(new Vector3(transform.localRotation.x, Random.Range(0, 360), transform.localRotation.z));
    }
}