using UnityEngine;
using UnityEngine.Pool;

public class PlayerTriggerCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Collectable")) 
        {
            ICollectable collectable = other.gameObject.GetComponent<ICollectable>();
            collectable.Collect();
        }
    }
}