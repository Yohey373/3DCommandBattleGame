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
        Debug.Log("����������");
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        // �I�΂ꂽ�A�^�b�N�̃X�e�[�g�Ɉڍs����
        if (GameCharacterDataProvider.Instance.PlayerCharacterControllers.Any(Player => Player.IsActionChoiced))
        {
            stateMachine.ChangeState(MainGameStateManager.Instance.MainGameStatesPlayerAttackTurn);
        }
    }
}
