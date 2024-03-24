using System;
using UnityEngine;
using UnityEngine.Events;

public class Obstacle : MonoBehaviour, ICollectable
{
    [SerializeField] UnityEvent onCollected;

    public void Collect() {
        onCollected?.Invoke();
        Destroy(gameObject);
    }
}