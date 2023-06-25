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
        // �Q�[���̃��C���ɓ�������܂��v���C���[��҂^�[���Ɉڍs����B
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
            // HitPoint���Ȃ��Ȃ����烊�U���g��
            stateMachine.ChangeState(MainGameStateManager.Instance.MainGameStatesGameResult);
        }
        // �Q�[���̏�����������������A���̃X�e�[�g�ɑJ��
        //stateMachine.ChangeState(new MainGameStatesGameResult(stateMachine));
    }
}
