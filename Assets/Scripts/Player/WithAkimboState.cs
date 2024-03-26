using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WithAkimboState : State {
    private GameObject[] _pistols;
    public WithAkimboState(GameObject[] pistols) {
        _pistols = pistols;
    }

    public override void Enter() {
        base.Enter();
        Debug.Log("������ ��������� � �����");

        foreach (GameObject p in _pistols) {
            p.SetActive(true);
        }
    }

    public override void Exit() {
        base.Exit();
        Debug.Log("������ ���������� ��� � �����");

        foreach (GameObject p in _pistols) {
            p.SetActive(false);
        }
    }
}
