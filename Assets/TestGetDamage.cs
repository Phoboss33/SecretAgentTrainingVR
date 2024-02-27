using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGetDamage : MonoBehaviour
{
    void OnCollisionEnter(Collision collision) {
        // Проверка, является ли столкнувшийся объект пулей
        if (collision.gameObject.CompareTag("Bullet")) {
            Destroy(gameObject); // Уничтожение цели
        }
    }
}
