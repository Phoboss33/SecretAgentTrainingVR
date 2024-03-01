using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WithAkimboState : State
{
    public override void Enter() {
        base.Enter();
        Debug.Log("������ ��������� � �����");
    }

    public override void Exit() {
        base.Exit();
        Debug.Log("������� ���������� ��� � �����");
    }
}