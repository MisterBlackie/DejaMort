using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager_TogglePlayer : MonoBehaviour
{
    public CharacterMovingComponentv2 player;
    private GameManager_Master gameManagerMaster;

    private void OnEnable()
    {
        SetInitialReferences();
        gameManagerMaster.MenuToggleEvent += TogglePlayerController;
        gameManagerMaster.InventoryUIToggleEvent += TogglePlayerController;
    }

    private void OnDisable()
    {
        gameManagerMaster.MenuToggleEvent -= TogglePlayerController;
        gameManagerMaster.InventoryUIToggleEvent -= TogglePlayerController;
    }

    void SetInitialReferences()
    {
        gameManagerMaster = GetComponent<GameManager_Master>();
    }
    void TogglePlayerController()
    {
       
    }
}
