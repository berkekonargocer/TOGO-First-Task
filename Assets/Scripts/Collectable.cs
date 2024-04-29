using NOJUMPO;
using UnityEngine;
using UnityEngine.Events;

[DisallowMultipleComponent]
public class Collectable : MonoBehaviour, ICollectable
{
    [field: SerializeField] public CollectableType Type { get; private set; }

    [SerializeField] AudioClip collectSFX;
    [SerializeField] UnityEvent onCollected;

    MeshFilter _meshFilter;
    ParticleSystem _transformVFX;
    FloatAnimation _floatAnimation;


    void Awake() {
        _meshFilter = GetComponent<MeshFilter>();
        _transformVFX = GetComponent<ParticleSystem>();
        _floatAnimation = GetComponent<FloatAnimation>();
    }


    public void Collect(Inventory inventory) {
        Destroy(_floatAnimation);
        _floatAnimation = null;

        tag = "Untagged";

        onCollected?.Invoke();
        inventory.AddItem(this);
        AudioManager.Instance.PlaySFX(collectSFX);
    }

    public void SetType(CollectableType type) {
        _transformVFX.Play();
        AudioManager.Instance.PlaySFX(type.TransformSFX);
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