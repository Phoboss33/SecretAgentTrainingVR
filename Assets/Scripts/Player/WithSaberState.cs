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
        Debug.Log("���� � �����" + ", " + x);
    }

    public override void Exit() {
        base.Exit();
        Debug.Log("����� ��� � �����");
    }

    public override void Update() {
        //base.Update();
        //Debug.Log("���� �������");
    }
}
