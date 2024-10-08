using UnityEngine;
using TMPro;
using System;

public class Score : MonoBehaviour {
    [SerializeField] TMP_Text scoreText;
    private float score = 0;

    private void Update() {
        AddScore();
    }

    public void AddScore() {
        this.score += Time.deltaTime;
        this.scoreText.text = score.ToString("0");
    }

    public float GetScore() {
        return this.score;
    }

    public void Reset() {
        this.score = 0;
    }
}
