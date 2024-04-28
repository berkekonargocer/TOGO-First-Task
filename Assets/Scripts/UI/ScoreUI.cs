using TMPro;
using UnityEngine;

[DisallowMultipleComponent]
public class ScoreUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;


    void OnEnable() {
        PlayerInventory.Instance.OnItemAmountChange += UpdateScoreText;
    }

    void OnDisable() {
        PlayerInventory.Instance.OnItemAmountChange -= UpdateScoreText;
    }

    void UpdateScoreText(int score) {
        scoreText.text = $"Score: <color=\"green\"> {score} </color>";
    }
}