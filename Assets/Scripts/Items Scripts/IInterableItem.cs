using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInterableItem : IHoldable {
    int UsePrimary();
    int UseSecondary();
    void EnleverCollider();
}
