using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameStatesGameResult : MainGameState
{
    public MainGameStatesGameResult(MainGameStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        Debug.Log("MianGameStatesGameResult Enter");
    }

    public override void Exit()
    {
        Debug.Log("MianGameStatesGameResult Exit");
    }

    public override void Update()
    {
        Debug.Log("MianGameStatesGameResult Update");
    }
}
