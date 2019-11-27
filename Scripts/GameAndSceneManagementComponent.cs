using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameAndSceneManagementComponent : MonoBehaviour
{
    public void Quit()
    {
        Application.Quit();
    }

    public void LoadMenu()
    {
        SaveGame();
        SceneManager.LoadScene("MainMenu");
    }

    public void SaveGame()
    {
        PlayerComponent.instance?.SavePlayer();
    }
}
