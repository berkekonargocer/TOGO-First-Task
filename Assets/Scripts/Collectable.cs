using UnityEngine;
using UnityEngine.Events;

public class Collectable : MonoBehaviour, ICollectable
{
    [SerializeField] UnityEvent onCollected;


    public virtual void Collect() {
        onCollected?.Invoke();
    }
}
