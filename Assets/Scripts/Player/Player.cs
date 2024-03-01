using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private StateMachine _SM;

    public static Action playerIdleStateevent;

    private void Start() {
        _SM = new StateMachine();
        _SM.Initialize(new IdleState());
    }

    private void Update() {
        _SM.CurrentState.Update();
        
        if (Input.GetKeyUp(KeyCode.R)) {
            _SM.ChangeState(new IdleState());
            print("Состояние: " + _SM.CurrentState.ToString()); 
        }
        if (Input.GetKeyUp(KeyCode.T)) {
            _SM.ChangeState(new WithAkimboState());
            print("Состояние: " + _SM.CurrentState);
        }
        if (Input.GetKeyUp(KeyCode.Y)) {
            _SM.ChangeState(new WithSaberState(10));
            print("Состояние: " + _SM.CurrentState);
        }
    }
}
