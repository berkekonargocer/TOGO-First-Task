using NOJUMPO;
using UnityEngine;

[DisallowMultipleComponent]
public class ScoreUI : MonoBehaviour
{
    [SerializeField] CountingFloat score;

    void OnEnable() {
        GameManager.Instance.PlayerInventory.OnItemAmountChange += UpdateScoreText;
    }

    void OnDisable() {
        GameManager.Instance.PlayerInventory.OnItemAmountChange -= UpdateScoreText;
    }

    void UpdateScoreText(int score) {
        this.score.Value = score * 5;
    }
}