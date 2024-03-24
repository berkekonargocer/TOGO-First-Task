using System;
using UnityEngine;

[DisallowMultipleComponent]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public AudioClip WinGameSFX;
    public AudioClip LoseGameSFX;

    PointSystem _playerPointSystem;

    public event Action OnLoseGame;
    public event Action OnWinGame;

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
            //AudioManager.Instance.PlaySFX(LoseGameSFX);
            OnLoseGame?.Invoke();
            return;
        }

        if(_playerPointSystem.CurrentPoint == 10)
        {
            //AudioManager.Instance.PlaySFX(WinGameSFX);
            OnWinGame?.Invoke();
        }
    }

    public void RestartLevel() {
        Utils.RestartLevel();
    }
}