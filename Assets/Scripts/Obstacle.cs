using UnityEngine;
using UnityEngine.Events;

[DisallowMultipleComponent]
public class Obstacle : MonoBehaviour, ITrigger
{
    [SerializeField] ScoreSystem playerScore;
    [SerializeField] UnityEvent onTriggered;


    public void Trigger() {
        if (!PlayerTriggerCollider.IS_INVULNERABLE)
        {
            playerScore.DecrementScore(1);
        }

        onTriggered?.Invoke();
        Destroy(gameObject);
    }
}