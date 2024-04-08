using System;
using UnityEngine;

[DisallowMultipleComponent]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [field: SerializeField] public AudioClip WinGameSFX { get; private set; }
    [field: SerializeField] public AudioClip LoseGameSFX { get; private set; }

    PointSystem _playerPointSystem;

    public event Action OnStartGame;
    public event Action<int> OnLoseGame;
    public event Action<int> OnWinGame;


    void OnEnable() {
        _playerPointSystem = GameObject.FindWithTag("Player").GetComponent<PointSystem>();
        _playerPointSystem.OnPointIncreased += CheckIfGameFinished;
        _playerPointSystem.OnPointDecreased += CheckIfGameFinished;
    }

    void OnDisable() {
        _playerPointSystem.OnPointIncreased -= CheckIfGameFinished;
        _playerPointSystem.OnPointDecreased -= CheckIfGameFinished;
    }
    void Awake() {
        InitializeSingleton();
    }

    public void StartGame() {
        OnStartGame?.Invoke();
    }

    public void WinGame() {
        OnWinGame?.Invoke(_playerPointSystem.CurrentPoint);
        AudioManager.Instance.PlaySFX(WinGameSFX);
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

    void CheckIfGameFinished() {
        if (_playerPointSystem.CurrentPoint == -1)
        {
            LoseGame();
        }
    }

    void LoseGame() {
        OnLoseGame?.Invoke(_playerPointSystem.CurrentPoint);
    }
}