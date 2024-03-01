using UnityEngine;

public class IdleState : State
{
    public override void Enter() {
        base.Enter();
        Debug.Log("Исходное состояние");


    }
    public override void Exit() {
        base.Exit();
        Debug.Log("Выход из изходного состояния");
    }
}
