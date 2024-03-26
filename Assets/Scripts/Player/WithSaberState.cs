using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WithSaberState : State
{
    //public int x;
    private GameObject[] _sabers;
    public WithSaberState(GameObject[] sabers) {
        //x = value;
        _sabers = sabers;
    }
    public override void Enter() {
        base.Enter();
        Debug.Log("Мечи в руках");
        foreach (var saber in _sabers) {
            saber.SetActive(true);
        }
    }

    public override void Exit() {
        base.Exit();
        Debug.Log("Мечей нет в руках");
        foreach (var saber in _sabers) {
            saber.SetActive(true);
        }
    }

    public override void Update() {
        //base.Update();
        //Debug.Log("Тест апдейта");
    }
}
