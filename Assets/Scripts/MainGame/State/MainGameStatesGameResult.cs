using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameStatesGameResult : MainGameState
{
    public MainGameStatesGameResult(MainGameStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        Debug.Log("MiangGameStatesGameResult Enter");
    }

    public override void Exit()
    {
        Debug.Log("MiangGameStatesGameResult Exit");
    }

    public override void Update()
    {
        Debug.Log("MiangGameStatesGameResult Update");
    }
}
