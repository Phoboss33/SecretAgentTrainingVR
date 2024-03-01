using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileEnterTriggerScipt : MonoBehaviour
{
    public static event Action EnterGroundTile;
    public static event Action EnterPropsTile;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Tile")) {
            EnterGroundTile?.Invoke();
            Destroy(other.gameObject);
        }
        if (other.CompareTag("PropTile")) {
            EnterPropsTile?.Invoke();
            Destroy(other.gameObject);
        }
    }
}
