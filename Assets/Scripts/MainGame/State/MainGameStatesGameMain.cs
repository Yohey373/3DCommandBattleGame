using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MainGameStatesGameMain : MainGameState
{
    public MainGameStatesGameMain(MainGameStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        Debug.Log("MainGameStatesGameMain Enter");
        // ゲームのメインに入ったらまずプレイヤーを待つターンに移行する。
        stateMachine.ChangeState(MainGameStateManager.Instance.MainGameStatesPlayerWaitTurn);
    }

    public override void Exit()
    {
        Debug.Log("MainGameStatesGameMain Exit");
    }

    public override void Update()
    {
        if (GameCharacterDataProvider.Instance.PlayerCharacterControllers.All(x=>x.GetCharacterData.HitPoint <= 0))
        {
            // HitPointがなくなったらリザルトへ
            stateMachine.ChangeState(MainGameStateManager.Instance.MainGameStatesGameResult);
        }
        // ゲームの初期化が完了したら、次のステートに遷移
        //stateMachine.ChangeState(new MainGameStatesGameResult(stateMachine));
    }
}
