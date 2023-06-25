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
        // プレイヤーのアタックターゲットが無いとき
        if (pointOfAttack == null)
        {
            var enemy = GameCharacterDataProvider.Instance.EnemyCharacterControllers.FirstOrDefault();
            pointOfAttack = enemy.PointOfAttack;
        }

        if (mainGameCharacterController.IsActionChoiced)
        {
            // 動くアニメーションを再生させる
            mainGameCharacterController.GetGameCharacterAnimator.Play("Run");
        }
        else
        {
            // 動くアニメーションを再生させる
            mainGameCharacterController.GetGameCharacterAnimator.Play("BackRun");
        }

    }

    public void Update()
    {
        // 前進するとき
        if (mainGameCharacterController.IsActionChoiced)
        {
            mainGameCharacterController.GetCharacterPrefabTransform.position = 
                Vector3.Lerp(mainGameCharacterController.GetCharacterPrefabTransform.position, pointOfAttack.position, Time.deltaTime);

            if ((mainGameCharacterController.GetCharacterPrefabTransform.position - pointOfAttack.position).magnitude < nearDistance)
            {
                // characterのAttackStateに変更する
                mainGameCharacterController.GetCharacterStateMachine.TransitionTo(mainGameCharacterController.GetCharacterStateMachine.attackState);
            }

        }

        /*// CharacterのPositionが重なったら
        if (mainGameCharacterController.GetCharacterPrefabTransform.position == pointOfAttack.position)
        {
            // characterのAttackStateに変更する
            mainGameCharacterController.GetCharacterStateMachine.TransitionTo(mainGameCharacterController.GetCharacterStateMachine.attackState);
        }*/
        else
        {
            // 後退するとき
            mainGameCharacterController.GetCharacterPrefabTransform.position =
                Vector3.Lerp(mainGameCharacterController.GetCharacterPrefabTransform.position, mainGameCharacterController.transform.position, Time.deltaTime);

            // CharacterのPositionが重なったら
            if ((mainGameCharacterController.GetCharacterPrefabTransform.position - mainGameCharacterController.transform.position).magnitude<nearDistance)
            {
                // characterのAttackStateに変更する
                mainGameCharacterController.GetCharacterStateMachine.TransitionTo(mainGameCharacterController.GetCharacterStateMachine.waitState);
            }
        }
        
        /*
        if (mainGameCharacterController.GetCharacterPrefabTransform.position == mainGameCharacterController.transform.position)
        {
            // characterのAttackStateに変更する
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
