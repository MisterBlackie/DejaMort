using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCaseComponent : MonoBehaviour
{
    private IItem item;
    public int ID { get; private set; }

    private Image imageCase { get; set; }

    private void Awake()
    {
        imageCase = GetComponent<Image>();   
    }

    public void setItem(IItem item) {
        this.item = item;
    }

    public void showImage()
    {
        imageCase.sprite = item.displayImage;
    }
}
