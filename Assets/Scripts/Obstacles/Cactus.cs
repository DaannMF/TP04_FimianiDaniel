using UnityEngine;

public class Cactus : MonoBehaviour {
    const float START_POS = 10f;
    [SerializeField] Sprite[] sprites;
    [SerializeField] float speed;

    private void OnCollisionEnter2D(Collision2D other) {
        if (GameManager.SharedInstance.IsPlayerTag(other.gameObject.tag)) {
            GameManager.SharedInstance.Lose();
        }
    }

    private void OnEnable() {
        SetPosition();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (GameManager.SharedInstance.IsObstacleLimitTag(other.gameObject.tag)) {
            this.gameObject.SetActive(false);
        }
    }

    private void Update() {
        MoveTowardsPlayer();
    }

    void SetPosition() {
        this.transform.position = new Vector3(START_POS, this.transform.position.y, this.transform.position.z);
    }

    void MoveTowardsPlayer() {
        Vector2 pos = this.transform.position;
        pos.x -= this.speed * Time.deltaTime;
        this.transform.position = pos;
    }
}
