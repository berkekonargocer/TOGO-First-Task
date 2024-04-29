using UnityEngine;

namespace NOJUMPO
{
    [CreateAssetMenu(fileName = "NewCollectableType", menuName = "NOJUMPO SO/New Collectable Type")]
    public class CollectableType : ScriptableObject
    {
#if UNITY_EDITOR

        [TextArea]
        [SerializeField] string developerDescription;

#endif

        [SerializeField] Mesh meshType;
        [field: SerializeField] public AudioClip TransformSFX { get; private set; }
        [SerializeField] CollectableType transformType;

        [field: SerializeField] public int Point { get; private set; }


        // -------------------------------- FIELDS ---------------------------------


        // ------------------------- UNITY BUILT-IN METHODS ------------------------


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public void TransformType(Collectable collectable) {
            collectable.SetType(transformType);
        }

        public void ApplyTransformation(MeshFilter meshFilter) {
            meshFilter.mesh = meshType;
        }

        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
    }
}