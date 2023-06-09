using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameUISettingManager : MonoBehaviour
{
    
    [SerializeField]
    private CharacterUIRoot characterUIRoot;

    [SerializeField]
    private MainGameUIButtonsManager mainGameUIButtonsManager;

    [SerializeField]
    private MainGameCharacterController mainGameCharacterController;

    // Update is called once per frame
    private void Update()
    {
        if (characterUIRoot.IsGaugeFull
            && !mainGameUIButtonsManager.gameObject.activeSelf
            && mainGameCharacterController.GetCharacterData
            == characterUIRoot.GetCharacterUIData)
        {
            mainGameUIButtonsManager.gameObject.SetActive(true);

            mainGameUIButtonsManager.SetButtonActions(mainGameCharacterController.primaryButtonAction);
        }
    }
}
