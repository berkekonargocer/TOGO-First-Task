using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource MusicAudioSource;
    [SerializeField] AudioSource SFXAudioSource;

    public void PlayMusic(AudioClip clipToPlay) {
        MusicAudioSource.clip = clipToPlay;
        MusicAudioSource.Play();
    }

    public void StopMusic() {
        MusicAudioSource.Stop();
    }

    public void PlaySFX(AudioClip clipToPlay) {
        SFXAudioSource.clip = clipToPlay;
        SFXAudioSource.Play();
    }

    public void StopSFX() {
        SFXAudioSource.Stop();
    }
}
