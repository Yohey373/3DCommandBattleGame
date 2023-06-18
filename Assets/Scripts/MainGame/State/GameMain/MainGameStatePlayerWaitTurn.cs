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
        // どれか一つでもゲージがフルであれば
        if (characterUIRoots.Any(uiRoots => uiRoots.IsGaugeFull))
        {
            // もし、ゲージがフルになってら選択するターンに移行する
            stateMachine.ChangeState(MainGameStateManager.Instance.MainGameStatesPlayerChoiseTurn);
        }
    }
}
