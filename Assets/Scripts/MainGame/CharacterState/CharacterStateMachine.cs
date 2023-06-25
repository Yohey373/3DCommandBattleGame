using System;

public class CharacterStateMachine
{
    
    public ICharacterState CurrentState { get; private set; }

    // reference to the state ojects
    public CharacterWaitState waitState;
    public CharacterMoveState moveState;
    public CharacterAttackState attackState;

    // �ύX��������Action
    public event Action<ICharacterState> stateChanged;

    // CharacterStateMachine����������̃R���X�g���N�^
    public CharacterStateMachine(MainGameCharacterController mainGameCharacterController)
    {
        this.waitState = new CharacterWaitState(mainGameCharacterController);
        this.moveState = new CharacterMoveState(mainGameCharacterController);
        this.attackState = new CharacterAttackState(mainGameCharacterController);
    }

    // CharacterState���Z�b�g���ꂽ�Ƃ��ɌĂ΂��
    public void Initialize(ICharacterState state)
    {
        CurrentState = state;
        state.Enter();
        stateChanged?.Invoke(state);
    }

    // �ʂ�CharacterState�ɕύX����Ƃ��ɂ�΂��
    public void TransitionTo(ICharacterState nextState)
    {
        CurrentState.Exit();
        CurrentState = nextState;
        nextState.Enter();

        stateChanged?.Invoke(nextState);
    }

    // ����̃X�e�[�g���t���[���̏���
    public void Update()
    {
        if (CurrentState != null)
        {
            CurrentState.Update();
        }
    }

}
