using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCaseComponent : MonoBehaviour
{
    private IItem item;
    public int ID;
    public HotbarComponent inventory;

    private Image imageCase { get; set; }
    private GameObject itemMenu { get; set; }

    private void Awake()
    {
        imageCase = GetComponent<Image>();

        itemMenu = Instantiate(Resources.Load("Inventory_ItemMenu") as GameObject);
        itemMenu.SetActive(false);

        var buttons = itemMenu.GetComponentsInChildren<Button>();

        foreach (Button button in buttons) {
            if (button.name == "UseButton")
                button.onClick.AddListener(UseItem);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            ShowActionMenu();
        }
    }

    private void ShowActionMenu()
    {
        if (item != null) {
            itemMenu.SetActive(true);
            itemMenu.transform.position = Input.mousePosition;
        }
    }

    private void HideActionMenu() {
        itemMenu.SetActive(false);
    }

    public void setItem(IItem item) {
        this.item = item;
    }

    public void removeItem() {
        item = null;
        hideImage();
    }

    public void showImage()
    {
        imageCase.sprite = item.displayImage;
    }

    public void hideImage() {
        imageCase.sprite = null;
    }

    private void UseItem() {
        Debug.Assert(item != null);

        if (inventory.UseItem(ID))
            removeItem();

        HideActionMenu();
    }
}
