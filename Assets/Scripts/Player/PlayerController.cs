using System;
using UnityEngine;

namespace Runner {
    public class PlayerController : MonoBehaviour {

        const float START_POS_X = -6f;
        const float START_POS_Y = -3.2f;
        const String JUMP_TRIGGER = "Jumped";
        const String DIED_TRIGGER = "Died";

        [SerializeField] private Animator animator;
        [SerializeField] private float jumpForce;
        [SerializeField] private PlayerSounds playerSounds;

        private Boolean isGrounded = true;

        private Rigidbody2D rigidBody2D;

        private void Awake() {
            this.rigidBody2D = GetComponent<Rigidbody2D>();
        }

        private void OnTriggerEnter2D(Collider2D other) {
            if (GameManager.SharedInstance.IsObstacleTag(other.gameObject.tag)) {
                this.animator.SetTrigger(DIED_TRIGGER);
                this.playerSounds.PlayDieClip();
                GameManager.SharedInstance.Lose();
            }
        }

        private void OnCollisionEnter2D(Collision2D other) {
            if (GameManager.SharedInstance.IsGroundTag(other.gameObject.tag) && !isGrounded) {
                this.playerSounds.PlayLandClip();
                this.isGrounded = true;
            }
        }

        private void Update() {
            Jump();
        }

        void Jump() {
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
                this.isGrounded = false;
                this.playerSounds.PlayJumpClip();
                animator.SetTrigger(JUMP_TRIGGER);
                this.rigidBody2D.AddForce(Vector2.up * this.jumpForce, ForceMode2D.Impulse);
            }
        }

        public void ResetPlayer() {
            this.transform.position = new Vector3(START_POS_X, START_POS_Y, transform.position.z);
        }
    }
}
