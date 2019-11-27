using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
public class SwitchScene : MonoBehaviour
{

    public PlayerComponent player;
    private GamaManager_TogglePause pauseManager;

    static public bool IsPlayerLoad = false;
    public Text m_Text;
    public Button buttonload;
    public Button buttonnew;

    void Start()
    {
        //Call the LoadButton() function when the user clicks this Button
        buttonload.onClick.AddListener(LoadButton);
        buttonnew.onClick.AddListener(NouvellePartie);
    }

    void LoadButton()
    {
        //Start loading the Scene asynchronously and output the progress bar
        StartCoroutine(LoadScene());

       
    }

    public void NouvellePartie()
    {   
        IsPlayerLoad = false;
        SceneManager.LoadScene("main");
       // pauseManager.GetComponent<GamaManager_TogglePause>();
        if (pauseManager.isPaused)
            pauseManager.TogglePause();

        Ennemy_Health.nombreDeMort = 0;
        Jour_Nuit_Cycle.NombreDeJour = 0;
        SpawnerV3.NombreSpawner = 0;
    }

    IEnumerator LoadScene()
    {
       yield return null;

        //Begin to load the Scene you specify
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("main");
        //Don't let the Scene activate until you allow it to
        asyncOperation.allowSceneActivation = false;
        //Debug.Log("Pro :" + asyncOperation.progress);
        //When the load is still in progress, output the Text and progress bar
        while (!asyncOperation.isDone)
        {
            //Output the current progress
            m_Text.text = "Chargement : " + (asyncOperation.progress * 100) + "%";

            // Check if the load has finished
            if (asyncOperation.progress >= 0.9f)
            {
                //Change the Text to show the Scene is ready
                m_Text.text = "Chargement : 100 %";
                //Wait to you press the space key to activate the Scene
                
                    asyncOperation.allowSceneActivation = true;
                    IsPlayerLoad = true;

                
            }
         
            yield return null;
        }
    }

    public void GotoMainMenu()
    {
       
        SceneManager.LoadScene("MainMenu");
    }

}

