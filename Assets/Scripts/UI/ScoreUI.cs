using TMPro;
using UnityEngine;

[DisallowMultipleComponent]
public class ScoreUI : MonoBehaviour
{
    //[SerializeField] ScoreSystem pointSystem;
    [SerializeField] Inventory playerInventory;

    [SerializeField] TextMeshProUGUI scoreText;


    void OnEnable() {
        playerInventory.OnItemAmountChange += UpdateScoreText;
        //pointSystem.OnScoreIncreased += UpdateScoreText;
        //pointSystem.OnScoreDecreased += UpdateScoreText;
    }

    void OnDisable() {
        playerInventory.OnItemAmountChange -= UpdateScoreText;
        //pointSystem.OnScoreIncreased -= UpdateScoreText;
        //pointSystem.OnScoreDecreased -= UpdateScoreText;
    }

    void UpdateScoreText(int score) {
        scoreText.text = $"Score: <color=\"green\"> {score} </color>";
    }
}