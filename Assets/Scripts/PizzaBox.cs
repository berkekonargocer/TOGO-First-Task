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
}