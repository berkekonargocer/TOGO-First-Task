using System;
using UnityEngine;
using UnityEngine.Events;

public class Obstacle : MonoBehaviour, ICollectable
{
    [SerializeField] UnityEvent onCollected;

    public void Collect(PointSystem pointSystem) {
        pointSystem.DecrementPoint(1);
        onCollected?.Invoke();
        Destroy(gameObject);
    }
}