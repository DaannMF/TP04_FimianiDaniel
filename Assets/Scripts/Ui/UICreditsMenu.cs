using UnityEngine;
using UnityEngine.UI;

public class UICreditsMenu : MonoBehaviour {

    [Header("Buttons")]
    [SerializeField] private Button backButton;

    [Header("Panels")]
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject creditsPanel;


    private void Awake() {
        backButton.onClick.AddListener(OnBackButtonClicked);
    }

    private void OnDestroy() {
        backButton.onClick.RemoveListener(OnBackButtonClicked);
    }

    private void OnBackButtonClicked() {
        creditsPanel.SetActive(false);
        mainPanel.SetActive(true);
    }
}
