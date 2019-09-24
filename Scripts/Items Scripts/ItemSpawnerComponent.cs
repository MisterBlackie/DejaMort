using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnerComponent : MonoBehaviour
{
    GameObject lastItem;

    public void instantiateItem(GameObject item) {
        if (item != null)
        {
            if (lastItem == null)
            {
                lastItem = Instantiate(item, transform.position, Quaternion.identity);
            }
        }
    }
}
