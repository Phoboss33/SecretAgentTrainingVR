using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpeed : MonoBehaviour
{
    public static float speed = 0;
    public float seconds = 5f; 
    public float maxFirstSpeed;
    public float maxLastSpeed;
    private void FixedUpdate() {
        
        if (speed >= maxFirstSpeed)
            speed = Mathf.Lerp(speed, maxLastSpeed, Time.deltaTime * Time.deltaTime / seconds * seconds);
        else
            speed = Mathf.Lerp(speed, maxFirstSpeed * 1.1f, Time.deltaTime / seconds);

        //print(speed);
    }
    
}
