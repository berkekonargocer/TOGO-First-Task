using NOJUMPO;
using UnityEngine;

public interface ICollectable
{
    public Transform transform { get; }
    public Collider GetCollider { get; }
    public CollectableType Type { get; }
    public FollowWithOffset GetFollowWithOffset { get; }
    public SmoothFollow GetSmoothFollow { get; }

    public void Collect(Inventory inventory);
}