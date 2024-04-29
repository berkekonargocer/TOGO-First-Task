using NOJUMPO;
using UnityEngine;
using UnityEngine.Events;

[DisallowMultipleComponent]
public class Collectable : MonoBehaviour, ICollectable
{
    [field: SerializeField] public CollectableType Type { get; private set; }
    [SerializeField] UnityEvent onCollected;
    FloatAnimation _floatAnimation;

    MeshFilter _meshFilter;


    private void Awake() {
        _floatAnimation = GetComponent<FloatAnimation>();
        _meshFilter = GetComponent<MeshFilter>();
    }


    public void Collect(Inventory inventory) {
        Destroy(_floatAnimation);
        _floatAnimation = null;

        tag = "Untagged";

        onCollected?.Invoke();
        inventory.AddItem(this);
    }

    public void SetType(CollectableType type) {
        Type = type;
        Type.ApplyTransformation(_meshFilter);
    }

    void OnTriggerEnter(Collider other) {
        switch (other.tag)
        {
            case "CollectableTransformer":
                Type.TransformType(this);
                break;
            case "Collectable":
                ICollectable collectable = other.gameObject.GetComponent<ICollectable>();
                collectable?.Collect(GameManager.Instance.PlayerInventory);
                break;
            case "Trigger":
                ITrigger triggerable = other.gameObject.GetComponent<ITrigger>();
                triggerable?.Trigger();
                break;
        }
    }
}