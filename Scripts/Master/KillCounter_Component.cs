using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillCounter_Component : MonoBehaviour
{

    public Text KillCounter;
    // Update is called once per frame
    void Update()
    {
        KillCounter.text =  "Nombre d'ennemie tuer :" + Ennemy_Health.nombreDeMort.ToString();
    }
}
