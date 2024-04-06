using UnityEngine;

[DisallowMultipleComponent]
public class Obstacle : Collectable
{
    public override void Collect() {
        if (!PlayerTriggerCollider.IS_INVULNERABLE)
        {
            base.Collect();
        }

        Destroy(gameObject);
    }
}