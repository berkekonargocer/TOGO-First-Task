using System;
using UnityEngine;

[DisallowMultipleComponent]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public AudioClip WinGameSFX;
    public AudioClip LoseGameSFX;

    PointSystem _playerPointSystem;

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


    public void WinGame() {
        OnWinGame?.Invoke(_playerPointSystem.CurrentPoint);
    }

    public void RestartLevel() {
        Utils.RestartLevel();
    }
}