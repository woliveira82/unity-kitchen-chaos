using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour {

    [SerializeField] private BaseCounter baseCounter;
    [SerializeField] private GameObject[] visualGameObjectArray;

    private void Start() {
        Player.Instance.OnSelectedCounterChanged += Player_OnSelectedCounterChanged;
    }

    private void Player_OnSelectedCounterChanged(object sender, Player.OnSelectedCounterChangedEventArgs e) {
        bool showObject = e.selectedCounter == baseCounter;
        foreach (GameObject visualGameObject in visualGameObjectArray) {
            visualGameObject.SetActive(showObject);
        }
    }
}
