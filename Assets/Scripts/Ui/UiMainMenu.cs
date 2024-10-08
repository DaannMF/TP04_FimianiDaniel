using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class UiMainMenu : MonoBehaviour {
    [Header("Buttons")]
    [SerializeField] private Button playButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button creditsButton;
    [SerializeField] private Button exitButton;

    [Header("Panels")]
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject creditsPanel;

    private void OnEnable() {
        GameManager.SharedInstance.PauseGame();
    }

    private void Awake() {
        playButton.onClick.AddListener(OnPlayButtonClicked);
        settingsButton.onClick.AddListener(OnSettingsButtonClicked);
        creditsButton.onClick.AddListener(OnCreditsButtonClicked);
        exitButton.onClick.AddListener(OnExitButtonClicked);
    }

    private void Update() {
        Pause();
    }

    private void OnDestroy() {
        playButton.onClick.RemoveListener(OnPlayButtonClicked);
        settingsButton.onClick.RemoveListener(OnSettingsButtonClicked);
        creditsButton.onClick.RemoveListener(OnCreditsButtonClicked);
        exitButton.onClick.RemoveListener(OnExitButtonClicked);
    }

    private void Pause() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (!pausePanel.activeSelf) {
                GameManager.SharedInstance.PauseGame();
                pausePanel.SetActive(true);
            }
        }
    }

    private void OnPlayButtonClicked() {
        pausePanel.SetActive(false);
        GameManager.SharedInstance.ResumeGame();
    }

    private void OnSettingsButtonClicked() {
        mainPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    private void OnCreditsButtonClicked() {
        mainPanel.SetActive(false);
        creditsPanel.SetActive(true);
    }

    private void OnExitButtonClicked() {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif

    }
}
