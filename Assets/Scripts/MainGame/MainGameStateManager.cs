using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameStateManager : SingletonMonoBehaviour<MainGameStateManager>
{
    
    private MainGameStateMachine stateMachine;

    public MainGameStateMachine GetMainGameState
    {
        get { return stateMachine; }
    }

    public override void Awake()
    {
        isSceneinSingleton = true;
    }

    public MainGameStatesGameInit MainGameStatesGameInit;
    public MainGameStatesGameStart MainGameStatesGameStart;
    
    // MainGameの部分
    public MainGameStatesGameMain MainGameStatesGameMain;

    public MainGameStatePlayerWaitTurn MainGameStatesPlayerWaitTurn;
    public MainGameStatePlayerChoiseTurn MainGameStatesPlayerChoiseTurn;
    public MainGameStatePlayerAttackTurn MainGameStatesPlayerAttackTurn;


    // ゲームリザルト
    public MainGameStatesGameResult MainGameStatesGameResult;

    [SerializeField]
    private List<CharacterUIRoot> CharacterUIRoots = new List<CharacterUIRoot>();
    
    // Start is called before the first frame update
    private void Start()
    {
        stateMachine = new MainGameStateMachine();

        MainGameStatesGameInit = new MainGameStatesGameInit(stateMachine);
        MainGameStatesGameStart = new MainGameStatesGameStart(stateMachine, CharacterUIRoots);
        MainGameStatesGameMain = new MainGameStatesGameMain(stateMachine);

        MainGameStatesPlayerWaitTurn = new MainGameStatePlayerWaitTurn(stateMachine, CharacterUIRoots);
        MainGameStatesPlayerChoiseTurn = new MainGameStatePlayerChoiseTurn(stateMachine);
        MainGameStatesPlayerAttackTurn = new MainGameStatePlayerAttackTurn(stateMachine);

        MainGameStatesGameResult = new MainGameStatesGameResult(stateMachine);

        // Initからスタートする
        stateMachine.ChangeState(MainGameStatesGameInit);
    }

    // Update is called once per frame
    private void Update()
    {
        stateMachine.Update();
    }
}
