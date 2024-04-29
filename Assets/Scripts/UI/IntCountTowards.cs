using System.Collections;
using UnityEngine;

namespace NOJUMPO
{
    public class IntCountTowards : CountTowards
    {
        // -------------------------------- FIELDS ---------------------------------
        public int Value { get { return _value; } set { UpdateText(value); _value = value; } }
        int _value;

        // ------------------------- UNITY BUILT-IN METHODS ------------------------


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        void UpdateText(int newValue) {
            if (_countCoroutine != null)
            {
                StopCoroutine(_countCoroutine);
            }
            _countCoroutine = StartCoroutine(Count(newValue));
        }


        // ------------------------ CUSTOM PROTECTED METHODS -----------------------


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        IEnumerator Count(int newValue) {
            WaitForSeconds waitTime = new WaitForSeconds(1.0f / countFPS);
            int previousValue = _value;
            int stepAmount;

            if (newValue - previousValue < 0)
            {
                stepAmount = Mathf.FloorToInt((newValue - previousValue) / (countFPS * duration));
            }
            else
            {
                stepAmount = Mathf.CeilToInt((newValue - previousValue) / (countFPS * duration));
            }

            if (previousValue < newValue)
            {
                while (previousValue < newValue)
                {
                    previousValue += stepAmount;

                    if (previousValue > newValue)
                    {
                        previousValue = newValue;
                    }

                    _textMeshProUGUI.SetText(previousValue.ToString("F0"));

                    yield return waitTime;
                }
            }
            else
            {
                while (previousValue > newValue)
                {
                    previousValue += stepAmount;

                    if (previousValue < newValue)
                    {
                        previousValue = newValue;
                    }

                    _textMeshProUGUI.SetText(previousValue.ToString("F0"));

                    yield return waitTime;
                }
            }
        }
    }
}