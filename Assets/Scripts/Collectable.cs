using NOJUMPO;
using UnityEngine;
using UnityEngine.Events;

[DisallowMultipleComponent]
public class Collectable : MonoBehaviour, ICollectable
{
    [field: SerializeField] public CollectableType Type { get; private set; }
    public Collider GetCollider { get; private set; }
    public FollowWithOffset GetFollowWithOffset { get; private set; }
    public SmoothFollow GetSmoothFollow { get; private set; }

    [SerializeField] AudioClip collectSFX;
    [SerializeField] UnityEvent onCollected;

    MeshFilter _meshFilter;
    ParticleSystem _transformVFX;
    FloatAnimation _floatAnimation;


    void Awake() {
        GetCollider = GetComponent<Collider>();
        GetFollowWithOffset = GetComponent<FollowWithOffset>();
        GetSmoothFollow = GetComponent<SmoothFollow>();
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
        ScoreManager.Instance.IncrementScore(Type.Point);
        AudioManager.Instance.PlaySFX(collectSFX);
    }

    public void SetType(CollectableType type) {
        _transformVFX.Play();
        AudioManager.Instance.PlaySFX(type.TransformSFX);
        ScoreManager.Instance.DecrementScore(Type.Point);
        ScoreManager.Instance.IncrementScore(type.Point);
        Type = type;
        Type.ApplyTransformation(_meshFilter);
    }

    void OnTriggerEnter(Collider other) {
        switch (other.tag)
        {
            case "Collectable":
                ICollectable collectable = other.gameObject.GetComponent<ICollectable>();
                collectable?.Collect(GameManager.Instance.PlayerInventory);
                break;
            case "Trigger":
                ITrigger triggerable = other.gameObject.GetComponent<ITrigger>();
                triggerable?.Trigger();
                break;
            case "CollectableTrigger":
                ICollectableTrigger collectableTrigger = other.gameObject.GetComponent<ICollectableTrigger>();
                collectableTrigger?.Trigger(this);
                break;
        }
    }
}