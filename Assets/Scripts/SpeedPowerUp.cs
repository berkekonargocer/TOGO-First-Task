using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class SpeedPowerUp : MonoBehaviour, ITrigger
{
    [SerializeField] AutoForwardMovement playerMovement;

    [SerializeField] float powerUpDuration = 2.0f;

    [SerializeField] float powerUpSpeed = 5.0f;

    [SerializeField] UnityEvent onTriggered;


    public void Trigger() {
        onTriggered?.Invoke();
        StartCoroutine(SpeedUp());
        transform.position = Vector3.down * 5.0f;
    }

    IEnumerator SpeedUp() {
        playerMovement.IncrementVerticalMovementSpeed(powerUpSpeed);

        yield return new WaitForSeconds(powerUpDuration);

        playerMovement.IncrementVerticalMovementSpeed(-powerUpSpeed);

        Destroy(gameObject);
    }
}
