using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CharacterAttackState : ICharacterState
{

    CharacterData characterData;

    private MainGameCharacterController mainGameCharacterController;

    public CharacterAttackState (MainGameCharacterController mainGameCharacterController)
    {
        this.characterData = mainGameCharacterController.GetCharacterData;
        this.mainGameCharacterController = mainGameCharacterController;
    }

    
    public void Enter()
    {
        Debug.Log("�U��");
        // �U���̃A�j���[�V�������s��
        mainGameCharacterController.GetGameCharacterAnimator.Play("Action");
    }

    public void Update()
    {
        // �U���̃A�j���[�V�������I�������
        if (mainGameCharacterController.GetGameCharacterAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            // ���p�t�������ꍇ�͓����Ȃ��̂ł��̂܂�wait��
            if (characterData.CharacterType == CharacterData.CharacterTypes.SpellCaster)
            {
                mainGameCharacterController.GetCharacterStateMachine.TransitionTo(mainGameCharacterController.GetCharacterStateMachine.waitState);
            }
            else
            {
                mainGameCharacterController.GetCharacterStateMachine.TransitionTo(mainGameCharacterController.GetCharacterStateMachine.moveState);
            }
        }
    }

    public void Exit()
    {
        mainGameCharacterController.IsActionChoiced = false;
    }

}
