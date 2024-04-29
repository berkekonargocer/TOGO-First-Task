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
        [SerializeField] int point;
        [SerializeField] ParticleSystem transformSFX;

        [SerializeField] CollectableType transformType;


        // -------------------------------- FIELDS ---------------------------------


        // ------------------------- UNITY BUILT-IN METHODS ------------------------


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public void TransformType(Collectable collectable) {
            collectable.SetType(transformType);
        }

        public void ApplyTransformation(MeshFilter meshFilter) {
            meshFilter.mesh = meshType;
            //transformSFX.Play();
        }

        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
    }
}