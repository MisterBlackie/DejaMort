using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon : IItem, IHoldable, IInterableItem
{
    int Damage { get; }

    int Durability { get; }

    bool isBroken();

    void Repair(int RepairPts);
}
