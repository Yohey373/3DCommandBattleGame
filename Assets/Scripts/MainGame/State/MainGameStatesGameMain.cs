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
        // ゲームの初期化が完了したら、次のステートに遷移
        stateMachine.ChangeState(new MainGameStatesGameResult(stateMachine));
    }
}
