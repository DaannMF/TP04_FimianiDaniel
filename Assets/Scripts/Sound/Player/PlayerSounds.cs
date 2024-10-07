using System;
using UnityEngine;

public class PlayerSounds : MonoBehaviour {
    const ulong DELAY = 0;
    [SerializeField] AudioClip jumpClip;
    [SerializeField] AudioClip landClip;
    [SerializeField] AudioClip dieClip;
    private AudioSource src;

    private void Awake() {
        src = GetComponent<AudioSource>();
        jumpClip.LoadAudioData();
        landClip.LoadAudioData();
        dieClip.LoadAudioData();
    }

    public void PlayJumpClip() {
        this.src.PlayOneShot(jumpClip);
    }

    public void PlayLandClip() {
        this.src.PlayOneShot(landClip);
    }

    public void PlayDieClip() {
        this.src.PlayOneShot(dieClip);
    }
}
