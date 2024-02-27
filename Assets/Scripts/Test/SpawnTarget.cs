using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTarget : MonoBehaviour
{
    public TestSpawnTargets spawnTargets;

    private void Start() {
        

    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("MainCamera")) {
            spawnTargets.SpawnTarget();

        }
    }
}
