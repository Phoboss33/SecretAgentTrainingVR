using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempScript : MonoBehaviour
{
    public Move move;
    public void StopRun() {
        move.isMove = false;
    }
}
