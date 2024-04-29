using TMPro;
using UnityEngine;

namespace NOJUMPO
{

    [RequireComponent(typeof(TextMeshProUGUI))]
    public abstract class CountTowards : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] protected int countFPS = 30;
        [SerializeField] protected float duration = 1.0f;

        protected TextMeshProUGUI _textMeshProUGUI;
        protected Coroutine _countCoroutine;


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        protected virtual void Awake() {
            _textMeshProUGUI = GetComponent<TextMeshProUGUI>();    
        }


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------


        // ------------------------ CUSTOM PROTECTED METHODS -----------------------


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------

    }
}