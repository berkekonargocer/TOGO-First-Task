using UnityEngine;
using UnityEngine.Events;

[DisallowMultipleComponent]
public class Obstacle : MonoBehaviour, ITrigger
{
    [SerializeField] ParticleSystem obstacleHitParticleFX;
    [SerializeField] UnityEvent onTriggered;

    ParticleSpawner _particleSpawner;


    void Awake() {
        _particleSpawner = GetComponent<ParticleSpawner>();
    }


    public void Trigger() {
        _particleSpawner.SpawnParticle(obstacleHitParticleFX);

        if (GameManager.Instance.PlayerInventory.Items.Count == 0)
        {
            GameManager.Instance.LoseGame();
            Destroy(gameObject);
            return;
        }

        onTriggered?.Invoke();
    }
}