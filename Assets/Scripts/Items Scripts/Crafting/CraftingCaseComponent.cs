using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class CraftingCaseComponent : MonoBehaviour
{
    private Image imageCase { get; set; }

    public IItem item { get; private set; }

    private void Awake()
    {
        imageCase = GetComponent<Image>();
    }

    public void SetItem(IItem item)
    {
        this.item = item;
        RefreshCase();
    }

    public void RemoveItem()
    {
        item = null;
        HideImage();
    }

    private void RefreshCase()
    {
        Debug.Assert(item.displayImage != null);
        imageCase.sprite = item.displayImage;
    }

    private void HideImage()
    {
        imageCase.sprite = null;
    }
}
