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
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        // �ǂꂩ��ł��Q�[�W���t���ł����
        if (characterUIRoots.Any(uiRoots => uiRoots.IsGaugeFull))
        {
            // �����A�Q�[�W���t���ɂȂ��Ă�I������^�[���Ɉڍs����
            stateMachine.ChangeState(MainGameStateManager.Instance.MainGameStatesPlayerChoiseTurn);
        }
    }
}
