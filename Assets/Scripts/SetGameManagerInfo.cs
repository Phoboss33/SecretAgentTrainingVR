using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGameManagerInfo : MonoBehaviour
{
    [SerializeField] private int _standartTileCount;
    [SerializeField] private int _specTileCount;

    private void Start() {
        GameInformationSingleton.Instance.standartTileCount = _standartTileCount;
        GameInformationSingleton.Instance.specTileCount = _specTileCount;
    }
}
