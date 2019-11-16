using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Craft
{
    // Nom des items
    public string itemOne { get; private set; }
    public string itemTwo { get; private set; }

    // Résultat du craft
    public string result { get; private set; }

    public Craft(string itemOneName, string itemTwoName, string resultPrefabName)
    {
        itemOne = itemOneName;
        itemTwo = itemTwoName;
        result = resultPrefabName;
    }
}
