using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameCharacterController : MonoBehaviour
{
    // Asset上でのCharacterData
    [SerializeField]
    private CharacterData characterData;

    [SerializeField]
    private CharacterUIRoot characterUIRoot;

    public MainGameUIButtonsManager.ButtonAction primaryButtonAction;
    public MainGameUIButtonsManager.ButtonAction secondaryButtonAction;
    public MainGameUIButtonsManager.ButtonAction tertiaryButtonAction;

    public bool IsActionChoiced = false;

    public Transform PointOfAttack;

    private CharacterStateMachine characterStateMachine;

    public CharacterStateMachine GetCharacterStateMachine
    {
        get { return characterStateMachine; }
    }

    private Transform characterPrefabTransform = null;

    public Transform GetCharacterPrefabTransform
    {
        get { return characterPrefabTransform; }
    }

    // メインゲームで使うキャラクターデータ
    private CharacterData gameCharacterData;

    public CharacterData GetCharacterData
    {
        get { return gameCharacterData; }
    }

    private Animator gameCharacterAnimator;

    public Animator GetGameCharacterAnimator
    {
        get { return gameCharacterAnimator; }
    }

    private static string AnimationActionType = "ActionType";
    
    // Start is called before the first frame update
    private void Start()
    {
        if (characterData != null)
        {
            gameCharacterData = ScriptableObject.CreateInstance<CharacterData>();

            gameCharacterData.Initialize(characterData);

            characterStateMachine = new CharacterStateMachine(this);

        }
    }

    public void CharacterInstantiate()
    {
        var characterPrefab = Instantiate(gameCharacterData.CharacterPrefab, this.transform);

        characterPrefabTransform = characterPrefab.transform;

        gameCharacterAnimator = characterPrefab.GetComponentInChildren<Animator>();

        var CharacterClickHandler = characterPrefab.AddComponent<CharacterClickHandler>();

        primaryButtonAction = new MainGameUIButtonsManager.ButtonAction("Attack", ()=>SetAnimation(0));

        characterStateMachine.Initialize(characterStateMachine.waitState);
    }

    private void Update()
    {
        characterStateMachine.Update();
    }

    public void SetAnimation(int actionType)
    {
        IsActionChoiced = true;
        // casterだった場合は動かないのでそのままattackStateへ
        if (characterData.CharacterType == CharacterData.CharacterTypes.SpellCaster)
        {
            characterStateMachine.TransitionTo(characterStateMachine.attackState);
        }
        else
        {
            characterStateMachine.TransitionTo(characterStateMachine.moveState);
        }

        //StartCoroutine(SetActionAnimation(actionType));
    }

    public IEnumerator SetActionAnimation(int actionType)
    {
        gameCharacterAnimator.SetInteger(AnimationActionType, actionType);

        yield return new WaitWhile(
            () => gameCharacterAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1.0f);

        gameCharacterAnimator.SetInteger(AnimationActionType, -1);

        yield return new WaitUntil(
            () => !gameCharacterAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle"));

        IsActionChoiced = false;
    }

}
