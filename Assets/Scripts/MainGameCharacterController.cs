using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameCharacterController : MonoBehaviour
{
    // Asset上でのCharacterData
    [SerializeField]
    private CharacterData characterData;

    public MainGameUIButtonsManager.ButtonAction primaryButtonAction;
    public MainGameUIButtonsManager.ButtonAction secondaryButtonAction;
    public MainGameUIButtonsManager.ButtonAction tertiaryButtonAction;

    // メインゲームで使うキャラクターデータ
    private CharacterData gameCharacterData;

    public CharacterData GetCharacterData
    {
        get { return gameCharacterData; }
    }

    private Animator gameCharacterAnimator;

    private static string AnimationActionType = "ActionType";
    
    // Start is called before the first frame update
    private void Start()
    {
        if (characterData != null)
        {
            gameCharacterData =
                ScriptableObject.CreateInstance<CharacterData>();

            gameCharacterData.Initialize(characterData);

            var characterPrefab = Instantiate(gameCharacterData.CharacterPrefab, this.transform);

            gameCharacterAnimator = characterPrefab.GetComponentInChildren<Animator>();
        }
    }

    public void SetAnimation(int actionType)
    {
        StartCoroutine(SetActionAnimation(actionType));
    }

    public IEnumerator SetActionAnimation(int actionType)
    {
        gameCharacterAnimator.SetInteger(AnimationActionType, actionType);
        yield return new WaitWhile(
            () => gameCharacterAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1.0f);

        yield return new WaitUntil(
            () => gameCharacterAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1.0f);

        gameCharacterAnimator.SetInteger(AnimationActionType, -1);
    }

}
