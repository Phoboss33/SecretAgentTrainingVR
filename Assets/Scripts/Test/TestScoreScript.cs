using TMPro;
using UnityEngine;

public class TestScoreScript : MonoBehaviour
{
    public Move moveSpeed;
    public TextMeshProUGUI text;
    public int ScoreMultCount;

    private int Score;
    public void FixedUpdate() {
        Score +=  ScoreMultCount* moveSpeed.GetSpeed();
        if (moveSpeed.isMove)
            text.text = "Очки: " + Score;
    }
}
