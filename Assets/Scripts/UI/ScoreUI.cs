using TMPro;
using UnityEngine;

[DisallowMultipleComponent]
public class ScoreUI : MonoBehaviour
{
    [SerializeField] Inventory playerInventory;

    [SerializeField] TextMeshProUGUI scoreText;


    void OnEnable() {
        playerInventory.OnItemAmountChange += UpdateScoreText;
    }

    void OnDisable() {
        playerInventory.OnItemAmountChange -= UpdateScoreText;
    }

    void UpdateScoreText(int score) {
        scoreText.text = $"Score: <color=\"green\"> {score} </color>";
    }
}