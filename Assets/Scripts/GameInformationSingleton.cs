using UnityEngine;

public class GameInformationSingleton : MonoBehaviour {
    private static GameInformationSingleton _instance;

    public static GameInformationSingleton Instance {
        get {
            if (_instance == null) {
                _instance = FindObjectOfType<GameInformationSingleton>();
                if (_instance == null) {
                    _instance = new GameObject("TileCount").AddComponent<GameInformationSingleton>();
                }
            }

            return _instance;
        }
    }

    public int standartTileCount { get; set; }
    public int specTileCount { get; set; }

    

    private void Awake() {
        if (_instance != null && _instance != this) {
            Destroy(this);
        }
        else {
            _instance = this;
        }
    }
}
