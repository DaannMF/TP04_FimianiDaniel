using System;
using UnityEngine;

namespace Runner {
    public class PlayerController : MonoBehaviour {
        const String JUMP_TRIGGER = "Jumped";
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
                this.playerSounds.PlayDieClip();
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
                animator.SetBool(JUMP_TRIGGER, true);
                this.rigidBody2D.AddForce(Vector2.up * this.jumpForce, ForceMode2D.Impulse);
            }
        }
    }
}
