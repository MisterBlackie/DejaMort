using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnerComponent : MonoBehaviour
{
    GameObject lastItem;

    public void instantiateItem(GameObject item) {
        if (lastItem == null) // Pour ne pas spawn plusieurs items un par dessus l'autre
        {
            lastItem = Instantiate(item, transform.position, Quaternion.identity);
        }
    }
}
