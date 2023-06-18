using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MainGameStatesGameStart : MainGameState
{
    private List<CharacterUIRoot> characterUIRoots = new List<CharacterUIRoot>();
    
    public MainGameStatesGameStart(MainGameStateMachine stateMachine, List<CharacterUIRoot> characterUIRoots) : base(stateMachine) 
    { 
        this.characterUIRoots = characterUIRoots;    
    }

    public override void Enter()
    {
        Debug.Log("MainGameStatesGameStart Enter");

        for (int i = 0; i < GameCharacterDataProvider.Instance.PlayerCharacterControllers.Count(); i++)
        {
            // UIイニシャライズをする
            characterUIRoots[i].CharacterUIInitialize(GameCharacterDataProvider.Instance.PlayerCharacterControllers[i].GetCharacterData);

            GameCharacterDataProvider.Instance.PlayerCharacterControllers[i].CharacterInstantiate();
        }

    }

    public override void Exit()
    {
        Debug.Log("MainGameStatesGameStart Exit");
    }

    public override void Update()
    {
        Debug.Log("MainGameStatesGameStart Update");
        // ゲームの準備ができたら、次のステートに遷移
        stateMachine.ChangeState(MainGameStateManager.Instance.MainGameStatesGameMain);
    }
    
}
