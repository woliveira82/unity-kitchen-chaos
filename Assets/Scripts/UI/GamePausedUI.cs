using System;
using UnityEngine;
using UnityEngine.UI;

public class GamePausedUI : MonoBehaviour {

    [SerializeField] private Button resumeButton;
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private Button optionsButton;

    private void Awake() {
        resumeButton.onClick.AddListener(() => {
            GameManager.Instance.TogglePauseGame();
        });
        mainMenuButton.onClick.AddListener(() => {
            Loader.Load(Loader.Scene.MainMenuScene);
        });
        optionsButton.onClick.AddListener(() => {
            OptionsUI.Instance.Show();
        });
    }

    private void Start() {
        GameManager.Instance.OnGamePaused += GameManager_OnGamePaused;
        GameManager.Instance.OnGameUnpaused += GameManager_OnGameUnpaused;
        
        Hide();
    }

    private void GameManager_OnGamePaused(object sender, EventArgs e) {
        Show();
    }

    private void GameManager_OnGameUnpaused(object sender, EventArgs e) {
        Hide();
    }

    public void Show() {
        gameObject.SetActive(true);
    }
    
    public void Hide() {
        gameObject.SetActive(false);
    }

}
