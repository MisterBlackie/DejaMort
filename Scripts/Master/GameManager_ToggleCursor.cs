using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_ToggleCursor : MonoBehaviour
{

    private GameManager_Master gameManagerMaster;
    private bool isCursorLoacked = true;
    private void OnEnable()
    {
        SetInitialReferences();
        gameManagerMaster.MenuToggleEvent += ToggleCursorState;
        gameManagerMaster.InventoryUIToggleEvent += ToggleCursorState;
    }

    private void OnDisable()
    {
        gameManagerMaster.MenuToggleEvent -= ToggleCursorState;
        gameManagerMaster.InventoryUIToggleEvent -= ToggleCursorState;
    }
    private void Update()
    {
        CheckIfCursorShouldBeLocked();
    }

    void SetInitialReferences()
    { 
    }

    void ToggleCursorState()
    {
        isCursorLoacked = !isCursorLoacked;
    }

    void CheckIfCursorShouldBeLocked()
    {
        if (isCursorLoacked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
