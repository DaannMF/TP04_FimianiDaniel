using System;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour {
    [SerializeField] float speed;
    [SerializeField] Boolean scrollLeft;

    private Sprite sprite;
    private float singleTextureWidth;

    private void Awake() {
        SetupTexture();
    }

    void Start() {
        if (scrollLeft) speed = -speed;
    }

    void Update() {
        Scroll();
        CheckReset();
    }

    void SetupTexture() {
        this.sprite = GetComponent<SpriteRenderer>().sprite;
        this.singleTextureWidth = this.sprite.texture.width / this.sprite.pixelsPerUnit;
    }

    void Scroll() {
        float delta = this.speed * Time.deltaTime;
        transform.position += new Vector3(delta, 0f, 0f);
    }

    void CheckReset() {
        if (Math.Abs(transform.position.x) - singleTextureWidth > 0) {
            transform.position = new Vector3(0f, transform.position.y, transform.position.z);
        }
    }
}
