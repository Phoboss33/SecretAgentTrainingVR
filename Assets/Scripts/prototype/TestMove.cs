using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TestMove : MonoBehaviour
{
    [SerializeField] public int playerSpeed;
    [SerializeField] public int maxPlayerSpeed;
    [SerializeField] private GameObject pref;

    public TextMeshProUGUI text;

    private void Start() {
        playerSpeed = 0;
    }

    public void StartMove() {
        playerSpeed = 3;
    }

    private void Update() {
        pref.transform.position += new Vector3(0, 0, playerSpeed) * Time.deltaTime;
        text.text = "Скорость:" + playerSpeed.ToString();
    }
}
