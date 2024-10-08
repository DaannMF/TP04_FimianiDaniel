using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UIGameOverMenu : MonoBehaviour {
    [SerializeField] private TMP_Text textFinalScore;
    [SerializeField] private Button restartButton;

    private Score score;

    private void Start() {
        ShowFinalResult();
        restartButton.onClick.AddListener(OnRestartButtonClicked);
    }

    private void OnDestroy() {
        restartButton.onClick.RemoveListener(OnRestartButtonClicked);
    }

    void ShowFinalResult() {
        String score = this.score.GetScore().ToString("0");
        this.textFinalScore.text = $"YOUR FINAL SCORE IS : {score}";
    }

    private void OnRestartButtonClicked() {
        GameManager.SharedInstance.ReStart();
    }
}
