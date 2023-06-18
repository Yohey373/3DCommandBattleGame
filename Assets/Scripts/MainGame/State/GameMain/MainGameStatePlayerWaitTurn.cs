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
        // どれか一つでもゲージがフルであれば
        if (characterUIRoots.Any(uiRoots => uiRoots.IsGaugeFull))
        {
            // もし、ゲージがフルになってら選択するターンに移行する
            stateMachine.ChangeState(MainGameStateManager.Instance.MainGameStatesPlayerChoiseTurn);
        }
    }
}
