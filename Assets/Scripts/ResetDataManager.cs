using UnityEngine;

public class ResetDataManager : MonoBehaviour {

    private void Awake() {
        CuttingCounter.ResetStaticData();
        BaseCounter.ResetStaticData();
        TrashCounter.ResetStaticData();
    }
}
