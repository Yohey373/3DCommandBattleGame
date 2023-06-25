using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MainGameStatePlayerChoiseTurn : MainGameStatesGameMain
{
    public MainGameStatePlayerChoiseTurn(MainGameStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        Debug.Log("ここきｔる");
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        // 選ばれたアタックのステートに移行する
        if (GameCharacterDataProvider.Instance.PlayerCharacterControllers.Any(Player => Player.IsActionChoiced))
        {
            stateMachine.ChangeState(MainGameStateManager.Instance.MainGameStatesPlayerAttackTurn);
        }
    }
}
