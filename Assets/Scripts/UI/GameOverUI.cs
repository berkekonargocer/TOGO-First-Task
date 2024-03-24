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
        ShowPanel();

    }

    void DisplayLoseGamePanel() {
        gameOverText.text = "<color=\"red\"> YOU LOSE </color>";
        ShowPanel();
    }

    void ShowPanel() {
        gameOverPanel.gameObject.SetActive(true);
        gameOverPanel.DOMoveY(600, showPanelAnimationDuration).SetUpdate(true);
    }
}