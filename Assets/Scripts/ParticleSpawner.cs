using UnityEngine;

[DisallowMultipleComponent]
public class ParticleSpawner : MonoBehaviour
{
    public void SpawnParticle(ParticleSystem particlePrefab) {
        ParticleSystem particle = Instantiate(particlePrefab, transform.position, Quaternion.identity);
        particle.Play();
        float destroyWaitTime = particle.main.startLifetime.constant;
        Destroy(particle.gameObject, destroyWaitTime);
    }
}