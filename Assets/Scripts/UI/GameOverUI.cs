using TMPro;
using UnityEngine;
using DG.Tweening;
using NOJUMPO;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI gameOverText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] Transform gameOverPanel;

    [SerializeField] GameObject scoreHUDGameObj;

    [SerializeField] float showPanelAnimationDuration = 1.0f;


    void OnEnable() {
        gameOverPanel.gameObject.SetActive(false);
        ScoreManager.Instance.OnScoreChanged += UpdateScore;
        GameManager.Instance.OnWinGame += DisplayWinGamePanel;
        GameManager.Instance.OnLoseGame += DisplayLoseGamePanel;
    }

    void OnDisable() {
        ScoreManager.Instance.OnScoreChanged -= UpdateScore;
        GameManager.Instance.OnWinGame -= DisplayWinGamePanel;
        GameManager.Instance.OnLoseGame -= DisplayLoseGamePanel;
    }

    void UpdateScore(int score) {
        scoreText.text = $"<color=\"green\"> {score} </color>";
    }

    void DisplayWinGamePanel(int score) {
        gameOverText.text = "<color=\"green\"> YOU WIN </color>";
        ShowPanel(score);
    }

    void DisplayLoseGamePanel(int score) {
        gameOverText.text = "<color=\"red\"> YOU LOSE </color>";
        ShowPanel(score);
    }

    void ShowPanel(int score) {
        scoreHUDGameObj.SetActive(false);
        gameOverPanel.gameObject.SetActive(true);

        gameOverPanel.DOMoveY(600, showPanelAnimationDuration)
                         .SetUpdate(true);
                         //.OnComplete(() => UpdateScore(score));
    }
}