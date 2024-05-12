using UnityEngine;

namespace NOJUMPO
{
    public class MiddleCharacter : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] float xScaleAmount, yScaleAmount;


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void Awake() {
        }

        void OnEnable() {
        }

        void OnDisable() {
        }

        void Start() {
        }

        void Update() {
        }

        void OnTriggerEnter(Collider other) {
            if (other.gameObject.CompareTag("Trigger"))
            {
                ITrigger triggerable = other.gameObject.GetComponent<ITrigger>();
                triggerable?.Trigger();
            }
        }


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public void IncrementScale() {
            Vector3 currentScale = transform.localScale;
            transform.localScale = new Vector3(currentScale.x + xScaleAmount, currentScale.y + yScaleAmount, currentScale.z);
        }

        // ------------------------ CUSTOM PROTECTED METHODS -----------------------


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
    }
}