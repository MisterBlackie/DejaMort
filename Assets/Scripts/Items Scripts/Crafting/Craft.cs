using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Craft
{
    // Code unique des items
    public string itemOne { get; private set; }
    public string itemTwo { get; private set; }

    // Résultat du craft (Code Unique)
    public string result { get; private set; }

    public Craft(IItem itemOneName, IItem itemTwoName, IItem resultName)
    {
        itemOne = itemOneName.itemUniqueCode;
        itemTwo = itemTwoName.itemUniqueCode;
        result = resultName.itemUniqueCode;
    }
}
