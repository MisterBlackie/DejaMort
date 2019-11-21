using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Craft
{
    // Code unique des items
    public string itemOne { get; set; }
    public string itemTwo { get; set; }

    // Résultat du craft (Code Unique)
    public string result { get; set; }

    public Craft(string itemOneName, string itemTwoName, string resultName)
    {
        itemOne = itemOneName;
        itemTwo = itemTwoName;
        result = resultName;
    }
}
