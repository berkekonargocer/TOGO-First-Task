using TMPro;
using UnityEngine;

[DisallowMultipleComponent]
public class ScoreUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;


    void OnEnable() {
        GameManager.Instance.PlayerInventory.OnItemAmountChange += UpdateScoreText;
    }

    void OnDisable() {
        GameManager.Instance.PlayerInventory.OnItemAmountChange -= UpdateScoreText;
    }

    void UpdateScoreText(int score) {
        scoreText.text = $"Score: <color=\"green\"> {score} </color>";
    }
}