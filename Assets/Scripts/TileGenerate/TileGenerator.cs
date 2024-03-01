using System.Collections;
using UnityEngine;

public class TileGenerator : MonoBehaviour {
    [SerializeField] private DefaultFactory _defFactory;
    [SerializeField] private PropsTileFactory _propsFactory;
    [SerializeField] private SpiralFactory _spiralFactory;
    [SerializeField] private LeftRightFactory _leftRightFactory;

    [SerializeField] private int valueRangerOne;
    [SerializeField] private int valueRangerTwo;

    private int _spawnTileCount = 0;
    private int _spiralTileCount = 0;
    private int _chooseValue = 0;
    private int _waveTileCount = 0;
    private int _currentWave = 1;
    

    private void Awake() {
        TileEnterTriggerScipt.EnterGroundTile += ActivateAnyFactories;
        TileEnterTriggerScipt.EnterPropsTile += PropsFactory;
    }

    private void OnDisable() {
        TileEnterTriggerScipt.EnterGroundTile -= ActivateAnyFactories;
        TileEnterTriggerScipt.EnterPropsTile -= PropsFactory;
    }

    private void Start() {
        _currentWave = 1;
        _waveTileCount = 0;
        _spawnTileCount = 0;
        _chooseValue = Random.Range(valueRangerOne, valueRangerTwo);
    }

    public void ActivateAnyFactories() {
        _spawnTileCount++;
        if (_waveTileCount < 8)
            _waveTileCount++;
        else
            _currentWave = 2;


        //print(_chooseValue);
        //print(_waveTileCount + " wave: " + _currentWave);
        if (_spawnTileCount > 4 * _currentWave) {    

            // Standart Events
            if (_chooseValue == 0) {
                SpiralFactory();
                _spawnTileCount %= 4 * _currentWave + GameInformationSingleton.Instance.standartTileCount;
            }
            else if (_chooseValue == 1) {
                LeftRightFactory();
                _spawnTileCount %= 4 * _currentWave + GameInformationSingleton.Instance.standartTileCount;
            }

            // Spec Events
            else if (_chooseValue == 2 && _currentWave >= 2) {
                print("akimbo pistol");
                DefaultFactory();
                _spawnTileCount %= 4 * _currentWave + GameInformationSingleton.Instance.specTileCount;
            }
            else if (_chooseValue == 3 && _currentWave >= 2) {
                print("laser saber");
                DefaultFactory();
                _spawnTileCount %= 4 * _currentWave + GameInformationSingleton.Instance.specTileCount;
            }

            // На всякий
            else {
                DefaultFactory();
                _spawnTileCount %= 4 + GameInformationSingleton.Instance.standartTileCount;
            }
        }
        else {
            DefaultFactory();
            _chooseValue = Random.Range(valueRangerOne, valueRangerTwo);
        }
    }


    // Factories
    public void DefaultFactory() {
        var factory = _defFactory.GetNewInstance();
        PropsFactory();
    }

    public void PropsFactory() {
        var factory = _propsFactory.GetNewInstance();
    }

    public void SpiralFactory() {
        var factory = _spiralFactory.GetNewInstance2(_spiralTileCount++);
        _spiralTileCount %= 2;
    }

    public void LeftRightFactory() {
        var factory = _leftRightFactory.GetNewInstance2(_spiralTileCount++);
        _spiralTileCount %= 2;
    }

    // GenerateLogicWithTime

    private void FixedUpdate() {

    }
}
