using UnityEngine;

[DisallowMultipleComponent]
public class FinishLine : MonoBehaviour
{
    [SerializeField] ParticleSystem[] winGameParticleFX;

    void OnTriggerExit(Collider other) {
        if (other.TryGetComponent(out Inventory inventory))
        {
            if(inventory.Items.Count > 0)
            {
                for (int i = 0; i < winGameParticleFX.Length; i++)
                {
                    winGameParticleFX[i].Play();
                }

                GameManager.Instance.WinGame();
                return;
            }

            GameManager.Instance.LoseGame();
        }
    }
}