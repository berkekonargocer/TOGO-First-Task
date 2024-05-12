using TMPro;
using UnityEngine;
using UnityEngine.Events;

[DisallowMultipleComponent]
[RequireComponent(typeof(ParticleSpawner))]
public class Obstacle : MonoBehaviour, ITrigger
{
    [SerializeField] ParticleSystem obstacleHitParticleFX;
    //[SerializeField] TextMeshPro destroyCountText;

    [SerializeField] UnityEvent onTriggered;

    //int _destroyCount;

    ParticleSpawner _particleSpawner;


    void Awake() {
        _particleSpawner = GetComponent<ParticleSpawner>();
    }


    public void Trigger() {
        _particleSpawner.SpawnParticle(obstacleHitParticleFX);


        onTriggered?.Invoke();
        GameManager.Instance.LoseGame();
        Destroy(gameObject);


        //_destroyCount++;
        //destroyCountText.SetText(_destroyCount.ToString());
    }
}