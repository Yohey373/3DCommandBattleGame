using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameStatesGameMain : MainGameState
{
    public MainGameStatesGameMain(MainGameStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        Debug.Log("MainGameStatesGameMain Enter");
    }

    public override void Exit()
    {
        Debug.Log("MainGameStatesGameMain Exit");
    }

    public override void Update()
    {
        Debug.Log("MainGameStatesGameMain Update");
        // �Q�[���̏�����������������A���̃X�e�[�g�ɑJ��
        stateMachine.ChangeState(new MainGameStatesGameResult(stateMachine));
    }
}
