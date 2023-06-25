using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CharacterMoveState : ICharacterState
{

    CharacterData characterData;

    private Transform pointOfAttack;

    private bool forward = true;

    private MainGameCharacterController mainGameCharacterController;

    private float nearDistance = 0.2f;

    public CharacterMoveState (MainGameCharacterController mainGameCharacterController)
    {
        this.characterData = mainGameCharacterController.GetCharacterData;
        this.mainGameCharacterController = mainGameCharacterController;
    }

    
    public void Enter()
    {
        this.pointOfAttack = GameCharacterDataProvider.Instance.PointOfAttack;
        // �v���C���[�̃A�^�b�N�^�[�Q�b�g�������Ƃ�
        if (pointOfAttack == null)
        {
            var enemy = GameCharacterDataProvider.Instance.EnemyCharacterControllers.FirstOrDefault();
            pointOfAttack = enemy.PointOfAttack;
        }

        if (mainGameCharacterController.IsActionChoiced)
        {
            // �����A�j���[�V�������Đ�������
            mainGameCharacterController.GetGameCharacterAnimator.Play("Run");
        }
        else
        {
            // �����A�j���[�V�������Đ�������
            mainGameCharacterController.GetGameCharacterAnimator.Play("BackRun");
        }

    }

    public void Update()
    {
        // �O�i����Ƃ�
        if (mainGameCharacterController.IsActionChoiced)
        {
            mainGameCharacterController.GetCharacterPrefabTransform.position = 
                Vector3.Lerp(mainGameCharacterController.GetCharacterPrefabTransform.position, pointOfAttack.position, Time.deltaTime);

            if ((mainGameCharacterController.GetCharacterPrefabTransform.position - pointOfAttack.position).magnitude < nearDistance)
            {
                // character��AttackState�ɕύX����
                mainGameCharacterController.GetCharacterStateMachine.TransitionTo(mainGameCharacterController.GetCharacterStateMachine.attackState);
            }

        }

        /*// Character��Position���d�Ȃ�����
        if (mainGameCharacterController.GetCharacterPrefabTransform.position == pointOfAttack.position)
        {
            // character��AttackState�ɕύX����
            mainGameCharacterController.GetCharacterStateMachine.TransitionTo(mainGameCharacterController.GetCharacterStateMachine.attackState);
        }*/
        else
        {
            // ��ނ���Ƃ�
            mainGameCharacterController.GetCharacterPrefabTransform.position =
                Vector3.Lerp(mainGameCharacterController.GetCharacterPrefabTransform.position, mainGameCharacterController.transform.position, Time.deltaTime);

            // Character��Position���d�Ȃ�����
            if ((mainGameCharacterController.GetCharacterPrefabTransform.position - mainGameCharacterController.transform.position).magnitude<nearDistance)
            {
                // character��AttackState�ɕύX����
                mainGameCharacterController.GetCharacterStateMachine.TransitionTo(mainGameCharacterController.GetCharacterStateMachine.waitState);
            }
        }
        
        /*
        if (mainGameCharacterController.GetCharacterPrefabTransform.position == mainGameCharacterController.transform.position)
        {
            // character��AttackState�ɕύX����
            mainGameCharacterController.GetCharacterStateMachine.TransitionTo(mainGameCharacterController.GetCharacterStateMachine.waitState);
        }
        
        if (forward)
        {
            mainGameCharacterController.transform.position = Vector3.Lerp(mainGameCharacterController.transform.position, pointOfAttack.position, Time.deltaTime);
        }
        */
    }

    public void Exit()
    {

    }

}
