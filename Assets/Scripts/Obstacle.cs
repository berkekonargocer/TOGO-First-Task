using UnityEngine;
using UnityEngine.Events;

[DisallowMultipleComponent]
public class Obstacle : MonoBehaviour, ITrigger
{
    [SerializeField] Inventory playerInventory;
    [SerializeField] UnityEvent onTriggered;


    public void Trigger() {
        if (playerInventory.Items.Count == 0)
        {
            GameManager.Instance.LoseGame();
        }

        onTriggered?.Invoke();
        Destroy(gameObject);
    }
}