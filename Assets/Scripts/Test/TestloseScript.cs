using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestloseScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("MainCamera")) {
            if (other != null) {
                other.GetComponent<TempScript>().StopRun();
                print("You Lose");
            }
            
        }
    }
}
