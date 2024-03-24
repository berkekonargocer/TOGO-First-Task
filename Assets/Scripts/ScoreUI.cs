using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] PointSystem pointSystem;

    [SerializeField] TextMeshProUGUI scoreText;

    private void OnEnable() {
        pointSystem.OnPointIncreased += UpdateScoreText;
        pointSystem.OnPointDecreased += UpdateScoreText;
    }

    private void OnDisable() {
        pointSystem.OnPointIncreased -= UpdateScoreText;
        pointSystem.OnPointDecreased -= UpdateScoreText;
    }

    void UpdateScoreText() {
        scoreText.text = $"Score: {pointSystem.CurrentPoint}";
    }
}
