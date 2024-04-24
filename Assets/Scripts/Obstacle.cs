using UnityEngine;
using UnityEngine.Events;

[DisallowMultipleComponent]
public class Obstacle : MonoBehaviour, ITrigger
{
    [SerializeField] ScoreSystem playerScoreSystem;
    [SerializeField] UnityEvent onTriggered;


    public void Trigger() {
        if (playerScoreSystem.CurrentScore == 0)
        {
            GameManager.Instance.LoseGame();
        }

        onTriggered?.Invoke();
        Destroy(gameObject);
    }
}