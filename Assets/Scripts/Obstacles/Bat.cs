using UnityEngine;

public class Bat : MonoBehaviour {
    const float START_POS_X = 10f;
    const float START_POS_Y = -1f;

    [SerializeField] float speed;

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
        this.transform.position = new Vector3(START_POS_X, START_POS_Y, this.transform.position.z);
    }

    void MoveTowardsPlayer() {
        Vector2 pos = this.transform.position;
        pos.x -= this.speed * Time.deltaTime;
        this.transform.position = pos;
    }
}
