using TMPro;
using UnityEngine;
using DG.Tweening;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI gameOverText;
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

    void DisplayWinGamePanel() {
        gameOverText.text = "<color=\"green\"> YOU WIN </color>";
        ShowPanel(true);
    }

    void DisplayLoseGamePanel() {
        gameOverText.text = "<color=\"red\"> YOU LOSE </color>";
        ShowPanel(false);
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