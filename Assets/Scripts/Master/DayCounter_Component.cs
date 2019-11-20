using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayCounter_Component : MonoBehaviour
{
    public Text DayCounter;
    // Update is called once per frame
    void Update()
    {
        DayCounter.text = "Nombre de jour survécue :" + Jour_Nuit_Cycle.NombreDeJour.ToString();
    }
}
