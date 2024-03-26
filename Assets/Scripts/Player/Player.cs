using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject[] _sabers;
    [SerializeField] private GameObject[] _pistols;

    private StateMachine _SM;

    //public static Action playerIdleStateevent;


    private void Awake() {
        TileGenerator.akimboEvent += ChangeStateOnAkimbo;
        TileGenerator.saberEvent += ChangeStateOnSaber;
        TileGenerator.idleEvent += ChangeStateOnIdle;
    }

    private void OnDisable() {
        TileGenerator.akimboEvent -= ChangeStateOnAkimbo;
        TileGenerator.saberEvent -= ChangeStateOnSaber;
        TileGenerator.idleEvent -= ChangeStateOnIdle;
    }

    private void Start() {
        foreach (var item in _sabers) {
            item.SetActive(false);
        }
        
        foreach (var item in _pistols) {
            item.SetActive(false);
        }

        _SM = new StateMachine();
        _SM.Initialize(new IdleState());
    }

    private void Update() {
        //_SM.CurrentState.Update();
        

    }

    public void ChangeStateOnIdle() {
        _SM.ChangeState(new IdleState());
    }
    public void ChangeStateOnAkimbo() {
        _SM.ChangeState(new WithAkimboState(_pistols));
    }
    public void ChangeStateOnSaber() {
        _SM.ChangeState(new WithSaberState(_sabers));
    }
}
