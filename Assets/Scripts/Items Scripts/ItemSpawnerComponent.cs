using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnerComponent : MonoBehaviour
{
    GameObject lastItem;

    public void instantiateItem(GameObject item) {
        if (ShouldSpawn()) // Pour ne pas spawn plusieurs items un par dessus l'autre
        {
            lastItem = Instantiate(item, transform.position, Quaternion.identity);
        }
    }

    private bool ShouldSpawn() {
        if (lastItem == null)
            return true;
        return lastItem.GetComponent<IItem>().hasBeenPickupOnce;
    }
}
