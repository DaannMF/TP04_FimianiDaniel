using System;
using Runner;
using UnityEngine;

public class GameManager : MonoBehaviour {
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private PlayerController playerController;

    const string PLAYER_TAG = "Player";
    const string OBSTACLE_LIMIT_TAG = "ObstacleLimit";
    const string GROUND_TAG = "Ground";
    const string OBSTACLE_TAG = "Obstacle";

    private Score score;
    private static GameManager instance;
    public static GameManager SharedInstance {
        get {
            if (instance == null) {
                instance = FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }

    private void Awake() {
        this.score = GetComponent<Score>();
    }

    void Start() {
        Reset();
    }

    public void Lose() {
        PauseGame();
        this.gameOverMenu.SetActive(true);
    }

    public void ReStart() {
        this.gameOverMenu.SetActive(false);
        Reset();
        ResumeGame();
    }

    public void PauseGame() {
        Time.timeScale = 0;
    }

    public void ResumeGame() {
        Time.timeScale = 1;

    }

    public void Reset() {
        this.score.Reset();
        this.playerController.ResetPlayer();
        ObstaclePool.SharedInstance.DeactivateInstances();
    }

    public Boolean IsPlayerTag(String tag) {
        return tag.Equals(PLAYER_TAG);
    }

    public Boolean IsObstacleLimitTag(String tag) {
        return tag.Equals(OBSTACLE_LIMIT_TAG);
    }

    public Boolean IsGroundTag(String tag) {
        return tag.Equals(GROUND_TAG);
    }

    public Boolean IsObstacleTag(String tag) {
        return tag.Equals(OBSTACLE_TAG);
    }

    public String GetScore() {
        return this.score.GetScore().ToString("0");
    }
}
