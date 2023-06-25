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
        Debug.Log("攻撃");
        // 攻撃のアニメーションを行う
        mainGameCharacterController.GetGameCharacterAnimator.Play("Action");
    }

    public void Update()
    {
        // 攻撃のアニメーションが終わったら
        if (mainGameCharacterController.GetGameCharacterAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            // 魔術師だった場合は動かないのでそのままwaitへ
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
