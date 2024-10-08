using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UIGameOverMenu : MonoBehaviour {
    [SerializeField] private TMP_Text textFinalScore;
    [SerializeField] private Button restartButton;

    private void OnEnable() {
        ShowFinalResult();
    }
    private void Start() {
        restartButton.onClick.AddListener(OnRestartButtonClicked);
    }

    private void OnDestroy() {
        restartButton.onClick.RemoveListener(OnRestartButtonClicked);
    }

    void ShowFinalResult() {
        String score = GameManager.SharedInstance.GetScore();
        this.textFinalScore.text = $"YOUR FINAL SCORE IS : {score}";
    }

    private void OnRestartButtonClicked() {
        GameManager.SharedInstance.ReStart();
    }
}
