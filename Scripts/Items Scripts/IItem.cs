using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IItem {
    
    string itemUniqueCode { get; } // Nom unique de l'item qui ne change pas par rapport à la langue et qui est safe d'utiliser
    string itemName { get; } // Nom d'affichage de l'item, modifié par rapport à la langue (pas du support multilangue pour l'instant)
    
    string description { get; }
    
    Sprite displayImage { get; }

    bool hasBeenPickupOnce { get;  }

    bool Use();

    void OnPickup();

    void OnDrop();

    void OnUse();
}
