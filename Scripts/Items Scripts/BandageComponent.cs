using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BandageComponent : MonoBehaviour, ITakeable
{
    public IItem item { get; set; }

    private void Awake()
    {
        // TODO: si l'item est droppé de l'inventaire, assigné cet objet
       // if (item == null)
        //    item = ScriptableObject.CreateInstance<Bandage>();
    }
    

    void Update()
    {
        
    }
}
