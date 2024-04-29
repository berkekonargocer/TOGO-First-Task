using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace NOJUMPO
{

    [RequireComponent(typeof(TextMeshProUGUI))]
    public abstract class CountTowards : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] int countFPS;
        [SerializeField] float duration;

        TextMeshProUGUI _textMeshProUGUI;
        Coroutine _countCoroutine;

        public T Value { get { return _value; } set { UpdateText(value); _value = value; } }
        T _value;


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void Awake() {
            _textMeshProUGUI = GetComponent<TextMeshProUGUI>();    
        }


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        //void UpdateText(T newValue) {
        //    if (_countCoroutine != null)
        //    {
        //        StopCoroutine(_countCoroutine);
        //    }
        //    _countCoroutine = StartCoroutine(Count(newValue));
        //}

        // ------------------------ CUSTOM PROTECTED METHODS -----------------------


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        //IEnumerator Count(T newValue) {
        //    WaitForSeconds waitTime = new WaitForSeconds(1.0f / countFPS);
        //    T previousValue = _value;
        //    int stepAmount;

        //    if (newValue - previousValue = 0)
        //    {

        //    }
        //    yield return null;
        //}
    }
}