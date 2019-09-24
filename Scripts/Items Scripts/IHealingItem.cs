using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealingItem : IItem{
    int HealthToRestore { get; }

    int Use(GameObject objectToHeal);
}
