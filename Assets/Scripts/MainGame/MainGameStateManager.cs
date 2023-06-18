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
    
    // MainGame�̕���
    public MainGameStatesGameMain MainGameStatesGameMain;
    // �Q�[�����U���g
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
        MainGameStatesGameResult = new MainGameStatesGameResult(stateMachine);

        // Init����X�^�[�g����
        stateMachine.ChangeState(MainGameStatesGameInit);
    }

    // Update is called once per frame
    private void Update()
    {
        stateMachine.Update();
    }
}