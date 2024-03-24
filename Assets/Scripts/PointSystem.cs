using System;
using UnityEngine;

[DisallowMultipleComponent]
public class PointSystem : MonoBehaviour
{
    public int CurrentPoint { get; private set; } = 0;
    public event Action OnPointIncreased;
    public event Action OnPointDecreased;

    public void IncrementPoint(int incrementAmount) {
        CurrentPoint += incrementAmount;
        OnPointIncreased?.Invoke();
    }

    public void DecrementPoint(int decrementPoint) {
        CurrentPoint -= decrementPoint;
        OnPointDecreased?.Invoke();
    }
}