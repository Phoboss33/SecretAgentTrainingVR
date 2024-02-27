using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpawnTargets : MonoBehaviour
{
    public GameObject[] spawnTargets;
    
    private int randValue;

    private void Start() {
        foreach (var spawnTarget in spawnTargets) {
            spawnTarget.SetActive(false);
        }
    }

    public void SpawnTarget() {
        randValue = Random.Range(0, 3);
        if (randValue < 3) {
            spawnTargets[Random.Range(0, 3)].SetActive(true);
        }
    }
}
