using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MainGameStatePlayerWaitTurn : MainGameStatesGameMain
{
    private List<CharacterUIRoot> characterUIRoots;

    public MainGameStatePlayerWaitTurn(MainGameStateMachine stateMachine, List<CharacterUIRoot> characterUIRoots) : base(stateMachine)
    {
        this.characterUIRoots = characterUIRoots;
    }

    public override void Enter()
    {
        Debug.Log("MainGameStatePlayerWaitTurn Enter");
    }

    public override void Exit()
    {
        Debug.Log("MainGameStatePlayerWaitTurn Exit");
    }

    public override void Update()
    {
        Debug.Log("MainGameStatePlayerWaitTurn Update");
        base.Update();
        // �ǂꂩ��ł��Q�[�W���t���ł����
        if (characterUIRoots.Any(uiRoots => uiRoots.IsGaugeFull))
        {
            // �����A�Q�[�W���t���ɂȂ��Ă�I������^�[���Ɉڍs����
            stateMachine.ChangeState(MainGameStateManager.Instance.MainGameStatesPlayerChoiseTurn);
        }
    }
}
