using NOJUMPO;
using UnityEngine;

public interface ICollectable
{
    public Transform transform { get; }
    public CollectableType Type { get; }

    public void Collect(Inventory inventory);
}