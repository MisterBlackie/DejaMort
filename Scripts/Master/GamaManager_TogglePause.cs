using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamaManager_TogglePause : MonoBehaviour
{
    private GameManager_Master gameManagerMaster;
    private bool isPaused;

    private void OnEnable()
    {
        SetInitialReferences();
        gameManagerMaster.MenuToggleEvent += TogglePause;
        gameManagerMaster.InventoryUIToggleEvent += TogglePause;
    }
    private void OnDisable()
    {
        gameManagerMaster.MenuToggleEvent -= TogglePause;
        gameManagerMaster.InventoryUIToggleEvent -= TogglePause;
    }

    void SetInitialReferences()
    {
        gameManagerMaster = GetComponent<GameManager_Master>();
    }

    void TogglePause()
    {
        if (isPaused)
        {
            Time.timeScale = 1;
            isPaused = false;
        }
        else
        {
            Time.timeScale = 0;
            isPaused = true;
        }
    }
}
