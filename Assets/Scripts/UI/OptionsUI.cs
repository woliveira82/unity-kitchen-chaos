using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionsUI : MonoBehaviour {

    public static OptionsUI Instance { get; private set; }

    [SerializeField] private Button soundEffectsButton;
    [SerializeField] private Button musicButton;
    [SerializeField] private Button closeButton;
    [SerializeField] private Button moveUpButton;
    [SerializeField] private Button moveDownButton;
    [SerializeField] private Button moveLeftButton;
    [SerializeField] private Button moveRightButton;
    [SerializeField] private Button interactButton;
    [SerializeField] private Button interactAlternateButton;
    [SerializeField] private Button pauseButton;
    [SerializeField] private TextMeshProUGUI soundEffectsText;
    [SerializeField] private TextMeshProUGUI musicText;
    [SerializeField] private TextMeshProUGUI moveUpText;
    [SerializeField] private TextMeshProUGUI moveDownText;
    [SerializeField] private TextMeshProUGUI moveLeftText;
    [SerializeField] private TextMeshProUGUI moveRightText;
    [SerializeField] private TextMeshProUGUI interactText;
    [SerializeField] private TextMeshProUGUI interactAlternateText;
    [SerializeField] private TextMeshProUGUI pauseText;
    [SerializeField] private Transform pressToRebindKeyTransform;

    private void Awake() {
        Instance = this;

        soundEffectsButton.onClick.AddListener(() => {
            SoundManager.Instance.ChangeVolumne();
            UpdateVisual();
        });
        
        musicButton.onClick.AddListener(() => {
            MusicManager.Instance.ChangeVolumne();
            UpdateVisual();
        });

        closeButton.onClick.AddListener(() => {
            Hide();
        });

        moveUpButton.onClick.AddListener(() => { RebindBiding(GameInput.Binding.MoveUp); });
        moveDownButton.onClick.AddListener(() => { RebindBiding(GameInput.Binding.MoveDown); });
        moveLeftButton.onClick.AddListener(() => { RebindBiding(GameInput.Binding.MoveLeft); });
        moveRightButton.onClick.AddListener(() => { RebindBiding(GameInput.Binding.MoveRight); });
        interactButton.onClick.AddListener(() => { RebindBiding(GameInput.Binding.Interact); });
        interactAlternateButton.onClick.AddListener(() => { RebindBiding(GameInput.Binding.InteractAlternate); });
        pauseButton.onClick.AddListener(() => { RebindBiding(GameInput.Binding.Pause); });
    }

    private void Start() {
        GameManager.Instance.OnGameUnpaused += GameManager_OnGameUnpaused;

        UpdateVisual();

        HidePressToRebindKey();
        Hide();
    }

    private void GameManager_OnGameUnpaused(object sender, EventArgs e) {
        Hide();
    }

    private void UpdateVisual() {
        soundEffectsText.text = "Sound Effects: " + Mathf.Round(SoundManager.Instance.GetVolume() * 10f);
        musicText.text = "Music: " + Mathf.Round(MusicManager.Instance.GetVolume() * 10f);

        moveUpText.text = GameInput.Instance.GetBidingText(GameInput.Binding.MoveUp);
        moveDownText.text = GameInput.Instance.GetBidingText(GameInput.Binding.MoveDown);
        moveLeftText.text = GameInput.Instance.GetBidingText(GameInput.Binding.MoveLeft);
        moveRightText.text = GameInput.Instance.GetBidingText(GameInput.Binding.MoveRight);
        interactText.text = GameInput.Instance.GetBidingText(GameInput.Binding.Interact);
        interactAlternateText.text = GameInput.Instance.GetBidingText(GameInput.Binding.InteractAlternate);
        pauseText.text = GameInput.Instance.GetBidingText(GameInput.Binding.Pause);
    }

    public void Show() {
        gameObject.SetActive(true);
    }

    public void Hide() {
        gameObject.SetActive(false);
    }

    private void ShowPressToRebindKey() {
        pressToRebindKeyTransform.gameObject.SetActive(true);
    }

    private void HidePressToRebindKey() {
        pressToRebindKeyTransform.gameObject.SetActive(false);
    }

    private void RebindBiding(GameInput.Binding binding) {
        ShowPressToRebindKey();
        GameInput.Instance.RebindBiding(binding, () => {
            HidePressToRebindKey();
            UpdateVisual();
        });
    }
}
