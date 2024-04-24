using UnityEngine;
using UnityEngine.Events;

[DisallowMultipleComponent]
public class Obstacle : MonoBehaviour, ITrigger
{
    [SerializeField] Inventory playerInventory;
    [SerializeField] UnityEvent onTriggered;

    Collider _obstacleCollider;


    void Awake() {
        _obstacleCollider = GetComponent<Collider>();
    }


    public void Trigger() {
        if (playerInventory.Items.Count == 0)
        {
            GameManager.Instance.LoseGame();
        }

        _obstacleCollider.enabled = false;
        onTriggered?.Invoke();
        Destroy(gameObject);
    }
}