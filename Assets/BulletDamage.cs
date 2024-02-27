using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour {
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Target")) {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }

}

