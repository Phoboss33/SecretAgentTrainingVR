using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WithSaberState : State
{
    public int x;
    public WithSaberState(int value) {
        x = value;
    }
    public override void Enter() {
        base.Enter();
        Debug.Log("Мечи в руках" + ", " + x);
    }

    public override void Exit() {
        base.Exit();
        Debug.Log("Мечей нет в руках");
    }

    public override void Update() {
        //base.Update();
        //Debug.Log("Тест апдейта");
    }
}
