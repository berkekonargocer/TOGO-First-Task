using UnityEngine;
using UnityEngine.Events;

[DisallowMultipleComponent]
public class Point : MonoBehaviour, ICollectable
{
    [SerializeField] UnityEvent onCollected;

    public void Collect() {
        onCollected?.Invoke();
        Destroy(gameObject);
    }
}
