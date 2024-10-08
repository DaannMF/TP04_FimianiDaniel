using System;
using UnityEngine;

public class GameManager : MonoBehaviour {
    [SerializeField] private GameObject gameOverMenu;

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
        ReStart();
    }

    public void Lose() {
        PauseGame();
        this.gameOverMenu.SetActive(true);
    }

    public void ReStart() {
        this.gameOverMenu.SetActive(false);
        Reset();
    }

    public void PauseGame() {
        Time.timeScale = 0;
    }

    public void ResumeGame() {
        Time.timeScale = 1;

    }

    public void Reset() {
        this.score.Reset();
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
}
