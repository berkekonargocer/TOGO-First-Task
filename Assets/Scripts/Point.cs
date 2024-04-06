using UnityEngine;

[DisallowMultipleComponent]
public class Point : Collectable
{
    public override void Collect() {
        base.Collect();
        Destroy(gameObject);
    }
}