using NOJUMPO;
using TMPro;
using UnityEngine;

[DisallowMultipleComponent]
public class ScoreUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;

    [SerializeField] IntCountTowards score;

    void OnEnable() {
        GameManager.Instance.PlayerInventory.OnItemAmountChange += UpdateScoreText;
    }

    void OnDisable() {
        GameManager.Instance.PlayerInventory.OnItemAmountChange -= UpdateScoreText;
    }

    void UpdateScoreText(int score) {
        this.score.Value = score * 5;
        //scoreText.text = $"Score: <color=\"green\"> {score} </color>";
    }
}