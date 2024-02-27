using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Move : MonoBehaviour
{
    public int timeToEnd = 120;
    public int startSpeed = 0;
    public int secondStartSpeed = 3;
    public int maxSpeed = 15;
    //public TextMeshProUGUI text;
    public bool isMove;
    public float timeElapsed = 0f;


    private float speed = 0f;
    
    private int eventCounter;
    private bool CanImproveSpeed = true;

    private void Start() {
        isMove = false;
        CanImproveSpeed = true;
    }

    public int GetSpeed() {
        return (int)speed;
    }

    public void StartMove() {
        isMove = true;
        speed = 0f;
    }

    void FixedUpdate() {
        if (isMove) {
            timeElapsed += Time.deltaTime;

            if (speed < secondStartSpeed) {
                speed = Mathf.Lerp(startSpeed, secondStartSpeed, timeElapsed / secondStartSpeed);
            }
            else if (speed < maxSpeed) {
                speed = Mathf.Lerp(secondStartSpeed, maxSpeed, (timeElapsed * timeElapsed / timeToEnd) / timeToEnd);
            }
            else {
                CanImproveSpeed = false;
            }

            timeElapsed %= 125;

            if (timeElapsed > 30 && timeElapsed < 2 && eventCounter == 0) {
                eventCounter++;
                print("Хоп и эвент");
            }
            else if (timeElapsed > 60 && eventCounter == 1) {
                eventCounter++;
                print("хоп и второй эвент");
            }
            else if (timeElapsed > 110 && eventCounter == 2) {
                print("хоп и необычный эвент"); // может куча мишеней
                eventCounter = 0;
            }

            // Применяем скорость к объекту
            transform.position += transform.forward * speed * Time.deltaTime;
            //text.text = "Скорость:" + speed.ToString();
        }
    }
}
