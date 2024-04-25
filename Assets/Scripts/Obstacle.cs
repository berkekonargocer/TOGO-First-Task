using UnityEngine;
using UnityEngine.Events;

[DisallowMultipleComponent]
public class Obstacle : MonoBehaviour, ITrigger
{
    [SerializeField] Inventory playerInventory;
    [SerializeField] ParticleSystem obstacleHitParticleFX;

    [SerializeField] UnityEvent onTriggered;

    ParticleSpawner _particleSpawner;
    Collider _obstacleCollider;


    void Awake() {
        _particleSpawner = GetComponent<ParticleSpawner>();
        _obstacleCollider = GetComponent<Collider>();
    }


    public void Trigger() {
        _obstacleCollider.enabled = false;
        _particleSpawner.SpawnParticle(obstacleHitParticleFX);

        if (playerInventory.Items.Count == 0)
        {
            GameManager.Instance.LoseGame();
            Destroy(gameObject);
            return;
        }

        onTriggered?.Invoke();
        Destroy(gameObject);
    }
}