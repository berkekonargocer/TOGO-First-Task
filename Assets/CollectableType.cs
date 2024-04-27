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



        // -------------------------------- FIELDS ---------------------------------


        // ------------------------- UNITY BUILT-IN METHODS ------------------------


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
    }
}