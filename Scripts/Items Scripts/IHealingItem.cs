using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealingItem : IItem
{
    int healthToRestore { get; }
}
