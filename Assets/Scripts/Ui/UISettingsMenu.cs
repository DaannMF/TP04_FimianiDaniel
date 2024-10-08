using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System;

public class UISettingsMenu : MonoBehaviour {

    const String MIXER_PARAMETER_NAME = "SoundVol";

    [Header("Mixer")]
    [SerializeField] private AudioMixer mixer;

    [Header("Controls")]
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Button backButton;


    [Header("Panels")]
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject mainPanel;

    private void Awake() {
        volumeSlider.onValueChanged.AddListener(SetVolume);
        backButton.onClick.AddListener(OnBackButtonClicked);
    }

    private void OnDestroy() {
        backButton.onClick.RemoveListener(OnBackButtonClicked);
        volumeSlider.onValueChanged.RemoveListener(SetVolume);
    }


    private void SetVolume(float value) {
        mixer.SetFloat(MIXER_PARAMETER_NAME, MathF.Log10(value) * 20);
    }

    private void OnBackButtonClicked() {
        this.settingsPanel.SetActive(false);
        this.mainPanel.SetActive(true);
    }
}
