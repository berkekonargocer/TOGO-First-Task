using UnityEngine;
using UnityEngine.Events;

[DisallowMultipleComponent]
public class Obstacle : MonoBehaviour, ITrigger
{
    //[SerializeField] ScoreSystem playerScoreSystem;
    [SerializeField] UnityEvent onTriggered;


    public void Trigger() {
        //if (!PlayerTriggerCollider.IS_INVULNERABLE)
        //{
        //    playerScoreSystem.DecrementScore(1);
        //}

        onTriggered?.Invoke();
        Destroy(gameObject);
    }
}