using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGetDamage : MonoBehaviour
{
    void OnCollisionEnter(Collision collision) {
        // ��������, �������� �� ������������� ������ �����
        if (collision.gameObject.CompareTag("Bullet")) {
            Destroy(gameObject); // ����������� ����
        }
    }
}
