using System;
using UnityEngine;
using UnityEngine.Events;

public class Point : MonoBehaviour, ICollectable
{
    [SerializeField] UnityEvent onCollected;

    public void Collect(PointSystem pointSystem) {
        pointSystem.IncrementPoint(1);
        onCollected?.Invoke();
        Destroy(gameObject);
    }
}
