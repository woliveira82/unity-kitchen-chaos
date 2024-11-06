using UnityEngine;

public class StoveCounterSound : MonoBehaviour {
    
    [SerializeField] StoveCounter stoveCounter;

    private AudioSource audioSource;

    private void Awake() {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start() {
        stoveCounter.OnStateChange += StoveCounter_OnStateChange;
    }

    private void StoveCounter_OnStateChange(object sender, StoveCounter.OnStateChangeEventArgs e) {
        bool playSound = e.state == StoveCounter.State.Frying || e.state == StoveCounter.State.Fried;

        if (playSound) {
            audioSource.Play();
        } else {
            audioSource.Pause();
        }
    }
}
