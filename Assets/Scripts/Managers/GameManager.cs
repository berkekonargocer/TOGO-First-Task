using System;
using UnityEngine;

[DisallowMultipleComponent]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [field: SerializeField] public AudioClip BackgroundMusic { get; private set; }
    [field: SerializeField] public AudioClip WinGameSFX { get; private set; }
    [field: SerializeField] public AudioClip LoseGameSFX { get; private set; }

    public event Action OnStartGame;
    public event Action<int> OnLoseGame;
    public event Action<int> OnWinGame;

    void Awake() {
        InitializeSingleton();
    }


    public void StartGame() {
        OnStartGame?.Invoke();
        AudioManager.Instance.PlayMusic(BackgroundMusic);
    }

    public void WinGame() {
        OnWinGame?.Invoke(PlayerInventory.Instance.Items.Count);
        AudioManager.Instance.StopMusic();
        AudioManager.Instance.PlaySFX(WinGameSFX);
    }

    public void LoseGame() {
        OnLoseGame?.Invoke(PlayerInventory.Instance.Items.Count);
        AudioManager.Instance.StopMusic();
        AudioManager.Instance.PlaySFX(LoseGameSFX);
    }

    public void RestartLevel() {
        Utils.RestartLevel();
    }


    void InitializeSingleton() {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}