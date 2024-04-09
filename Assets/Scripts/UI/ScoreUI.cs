using TMPro;
using UnityEngine;

[DisallowMultipleComponent]
public class ScoreUI : MonoBehaviour
{
    [SerializeField] ScoreSystem pointSystem;

    [SerializeField] TextMeshProUGUI scoreText;

    private void OnEnable() {
        pointSystem.OnScoreIncreased += UpdateScoreText;
        pointSystem.OnScoreDecreased += UpdateScoreText;
    }

    private void OnDisable() {
        pointSystem.OnScoreIncreased -= UpdateScoreText;
        pointSystem.OnScoreDecreased -= UpdateScoreText;
    }

    void UpdateScoreText() {
        scoreText.text = $"Score: <color=\"green\"> {pointSystem.CurrentScore} </color>";
    }
}