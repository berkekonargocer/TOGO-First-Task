using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.WinGame();
        }
    }
}
