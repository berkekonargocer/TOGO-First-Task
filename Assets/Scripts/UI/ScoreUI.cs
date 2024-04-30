using NOJUMPO;
using UnityEngine;

[DisallowMultipleComponent]
public class ScoreUI : MonoBehaviour
{
    [SerializeField] CountingFloat score;

    void OnEnable() {
        ScoreManager.Instance.OnScoreChanged += UpdateScoreText;
    }

    void OnDisable() {
        ScoreManager.Instance.OnScoreChanged -= UpdateScoreText;
    }

    void UpdateScoreText(int score) {
        this.score.Value = score;
    }
}