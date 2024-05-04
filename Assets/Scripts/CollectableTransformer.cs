using UnityEngine;

namespace NOJUMPO
{
    public class CollectableTransformer : MonoBehaviour, ICollectableTrigger
    {
        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public void Trigger(Collectable collectable) {
            collectable.Type.TransformType(collectable);
        }
    }
}