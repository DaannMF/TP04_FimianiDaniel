using System;
using UnityEngine;

public class GameManager : MonoBehaviour {
    const string PLAYER_TAG = "Player";
    const string OBSTACLE_LIMIT_TAG = "ObstacleLimit";
    const string GROUND_TAG = "Ground";
    const string OBSTACLE_TAG = "Obstacle";

    private static GameManager instance;
    public static GameManager SharedInstance {
        get {
            if (instance == null) {
                instance = FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }

    void Start() {
        ReStart();
    }

    public void Lose() {

    }

    public void ReStart() {
        Reset();
    }

    public void Reset() {
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
