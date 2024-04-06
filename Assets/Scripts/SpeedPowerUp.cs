using System.Collections;
using UnityEngine;

public class SpeedPowerUp : Collectable
{
    [SerializeField] AutoForwardMovement playerMovement;

    [SerializeField] float powerUpDuration = 2.0f;

    [SerializeField] float powerUpSpeed = 5.0f;


    public override void Collect() {
        base.Collect();
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
