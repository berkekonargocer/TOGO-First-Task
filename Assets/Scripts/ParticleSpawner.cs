using UnityEngine;

[DisallowMultipleComponent]
public class ParticleSpawner : MonoBehaviour
{
    public void SpawnParticle(ParticleSystem particlePrefab) {
        ParticleSystem particle = Instantiate(particlePrefab, transform.position, Quaternion.identity);
        particle.Play();
        Destroy(particle, particle.main.startLifetime.constant);
    }
}