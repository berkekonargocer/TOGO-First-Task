using System;
using UnityEngine;

[DisallowMultipleComponent]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [field: SerializeField] public AudioClip WinGameSFX { get; private set; }
    [field: SerializeField] public AudioClip LoseGameSFX { get; private set; }

    Inventory _playerInventory;

    public event Action OnStartGame;
    public event Action<int> OnLoseGame;
    public event Action<int> OnWinGame;


    void OnEnable() {
        _playerInventory = GameObject.FindWithTag("Player").GetComponent<Inventory>();
    }

    void Awake() {
        InitializeSingleton();
    }


    public void StartGame() {
        OnStartGame?.Invoke();
    }

    public void WinGame() {
        OnWinGame?.Invoke(_playerInventory.Items.Count);
        AudioManager.Instance.PlaySFX(WinGameSFX);
    }

    public void LoseGame() {
        OnLoseGame?.Invoke(_playerInventory.Items.Count);
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