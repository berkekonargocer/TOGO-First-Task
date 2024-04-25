using UnityEngine;

[DisallowMultipleComponent]
public class FinishLine : MonoBehaviour
{
    private void OnTriggerExit(Collider other) {
        if (other.TryGetComponent(out Inventory inventory))
        {
            if(inventory.Items.Count > 0)
            {
                GameManager.Instance.WinGame();
                return;
            }

            GameManager.Instance.LoseGame();
        }
    }
}
