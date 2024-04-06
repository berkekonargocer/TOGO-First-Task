using TMPro;
using UnityEngine;
using DG.Tweening;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI gameOverText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] Transform gameOverPanel;

    [SerializeField] float showPanelAnimationDuration = 1.0f;


    void OnEnable() {
        gameOverPanel.gameObject.SetActive(false);
        GameManager.Instance.OnWinGame += DisplayWinGamePanel;
        GameManager.Instance.OnLoseGame += DisplayLoseGamePanel;
    }

    void OnDisable() {
        GameManager.Instance.OnWinGame -= DisplayWinGamePanel;
        GameManager.Instance.OnLoseGame -= DisplayLoseGamePanel;
    }

    void UpdateScore(int score) {
        scoreText.text = $"Your Score Is: {score}";
    }

    void DisplayWinGamePanel(int score) {
        UpdateScore(score);
        gameOverText.text = "<color=\"green\"> YOU WIN </color>";
        ShowPanel(isWin: true);
    }

    void DisplayLoseGamePanel(int score) {
        UpdateScore(score);
        gameOverText.text = "<color=\"red\"> YOU LOSE </color>";
        ShowPanel(isWin: false);
    }

    void ShowPanel(bool isWin) {
        
        gameOverPanel.gameObject.SetActive(true);

        if (isWin)
        {
            gameOverPanel.DOMoveY(600, showPanelAnimationDuration)
                         .SetUpdate(true)
                         .OnComplete(() => AudioManager.Instance.PlaySFX(GameManager.Instance.WinGameSFX));
            return;
        }

        gameOverPanel.DOMoveY(600, showPanelAnimationDuration)
                         .SetUpdate(true)
                         .OnComplete(() => AudioManager.Instance.PlaySFX(GameManager.Instance.LoseGameSFX));
    }
}