using System;

public class CharacterStateMachine
{
    
    public ICharacterState CurrentState { get; private set; }

    // reference to the state ojects
    public CharacterWaitState waitState;
    public CharacterMoveState moveState;
    public CharacterAttackState attackState;

    // 変更した時のAction
    public event Action<ICharacterState> stateChanged;

    // CharacterStateMachineを作った時のコンストラクタ
    public CharacterStateMachine(CharacterData characterData)
    {
        this.waitState = new CharacterWaitState(characterData);
        this.moveState = new CharacterMoveState(characterData);
        this.attackState = new CharacterAttackState(characterData);
    }

    // CharacterStateがセットされたときに呼ばれる
    public void Initialize(ICharacterState state)
    {
        CurrentState = state;
        state.Enter();
        stateChanged?.Invoke(state);
    }

    // 別のCharacterStateに変更するときによばれる
    public void TransitionTo(ICharacterState nextState)
    {
        CurrentState.Exit();
        CurrentState = nextState;
        nextState.Enter();

        stateChanged?.Invoke(nextState);
    }

    // 現状のステート毎フレームの処理
    public void Update()
    {
        if (CurrentState != null)
        {
            CurrentState.Update();
        }
    }

}
