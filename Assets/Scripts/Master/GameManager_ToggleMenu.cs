using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_ToggleMenu : MonoBehaviour
{
    public CharacterMovingComponentv2 player;
    private GameManager_Master gameManagerMaster;
    public GameObject menu;

    private void Start()
    {
        //ToggleMenu();
    }

    private void Update()
    {
        CheckForMenuToggleRequest();
       
       
    }
    private void OnEnable()
    {
        SetInitialReferences();
        gameManagerMaster.GameOverEvent += ToggleMenu;
       
    }

    private void OnDisable()
    {
        gameManagerMaster.GameOverEvent -= ToggleMenu;
      
        
    }

    void SetInitialReferences()
    {
        gameManagerMaster = GetComponent<GameManager_Master>();
    }

    void CheckForMenuToggleRequest()
    {
        if (Input.GetKeyUp(KeyCode.P) && !gameManagerMaster.isGameOver && !gameManagerMaster.isInventoryUIOn)
        {
            ToggleMenu();
          
         
        }
      
      
    }

    void ToggleMenu()
    {
       
        if (menu != null)
        {
            menu.SetActive(!menu.activeSelf);
            gameManagerMaster.isMenuOn = !gameManagerMaster.isMenuOn;
            gameManagerMaster.CallEventMenuToggle();
            if (!gameManagerMaster.isMenuOn)
            {
                player.LockMouse();
            }
            else
            {
                player.UnlockMouse();

            }



        }
        else
        {
            Debug.LogWarning("Assigner le menu dans le GameManager");
        }
    }
}
