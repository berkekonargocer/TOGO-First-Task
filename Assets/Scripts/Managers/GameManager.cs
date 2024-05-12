using NOJUMPO;
using System;
using UnityEngine;

[DisallowMultipleComponent]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [field: SerializeField] public AudioClip BackgroundMusic { get; private set; }
    [field: SerializeField] public AudioClip WinGameSFX { get; private set; }
    [field: SerializeField] public AudioClip LoseGameSFX { get; private set; }

    public Inventory PlayerInventory { get { return _playerInventory; } }
    Inventory _playerInventory;

    public event Action OnStartGame;
    public event Action<int> OnLoseGame;
    public event Action<int> OnWinGame;
    bool isGameOver = false;


    void Awake() {
        InitializeSingleton();
    }

    void OnEnable() {
        if (_playerInventory == null)
        {
            _playerInventory = GameObject.FindWithTag("Player").GetComponent<Inventory>();
        }
    }


    public void StartGame() {
        OnStartGame?.Invoke();
        AudioManager.Instance.PlayMusic(BackgroundMusic);
    }

    public void WinGame() {
        OnWinGame?.Invoke(ScoreManager.Instance.Score);
        AudioManager.Instance.StopMusic();
        AudioManager.Instance.PlaySFX(WinGameSFX);
    }

    public void LoseGame() {
        if (isGameOver)
            return;

        isGameOver = true;
        OnLoseGame?.Invoke(ScoreManager.Instance.Score);
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