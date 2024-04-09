using System;
using UnityEngine;

[DisallowMultipleComponent]
public class ScoreSystem : MonoBehaviour
{
    public int CurrentScore { get; private set; } = 0;
    public event Action OnScoreIncreased;
    public event Action OnScoreDecreased;

    public void IncrementScore(int incrementAmount) {
        CurrentScore += incrementAmount;
        OnScoreIncreased?.Invoke();
    }

    public void DecrementScore(int decrementPoint) {
        CurrentScore -= decrementPoint;
        OnScoreDecreased?.Invoke();
    }
}