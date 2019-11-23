using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchSceneV2 : MonoBehaviour
{
    public void GotoMainMenu()
    {

        SceneManager.LoadScene("MainMenu");
    }

    public void NouvellePartie()
    {
     
        SceneManager.LoadScene("main");
        

        Ennemy_Health.nombreDeMort = 0;
        Jour_Nuit_Cycle.NombreDeJour = 0;
    }
}
