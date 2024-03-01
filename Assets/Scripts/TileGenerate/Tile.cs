using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private void Update() {
        transform.position -= new Vector3(0, 0, TileSpeed.speed * Time.deltaTime);
    }
}
