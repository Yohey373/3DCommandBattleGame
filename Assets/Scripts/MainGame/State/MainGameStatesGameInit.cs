using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameStatesGameInit : MainGameState
{
    // コンストラクタ
    public MainGameStatesGameInit(MainGameStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        Debug.Log("MainGameStatesGameInit Enter");
        //base.Enter();
    }

    public override void Exit()
    {
        //base.Exit();
        Debug.Log("MainGameStatesGameInit Exit");
    }

    public override void Update()
    {
        //base.Update();
        Debug.Log("MainGameStatesGameInit Update");
        // ゲームの初期化が完了したら、Startに遷移
        stateMachine.ChangeState(MainGameStateManager.Instance.MainGameStatesGameStart);
    }
}
