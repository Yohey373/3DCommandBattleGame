using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterWaitState : ICharacterState
{

    private CharacterData characterData;

    private MainGameCharacterController mainGameCharacterController;

    public CharacterWaitState (MainGameCharacterController mainGameCharacterController)
    {
        this.characterData = mainGameCharacterController.GetCharacterData;
        this.mainGameCharacterController = mainGameCharacterController;
    }

    
    public void Enter()
    {
        this.mainGameCharacterController.GetGameCharacterAnimator.Play("Idle");
    }

    public void Update()
    {

    }

    public void Exit()
    {

    }

}
