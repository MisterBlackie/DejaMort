using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CraftingComponent : MonoBehaviour
{
    CraftManager craftManager;

    CraftingCaseComponent[] cases;
    CraftPreviewComponent preview;

    AchievementManager achievement;

    public event EventHandler<OnCraftSuccessful> onCraftSuccessful;
    public event EventHandler<EventArgs> onFieldReset; // Appeler quand les champs d'items sont reset

    public bool isUIOpen = false;

    int _lastItemChanged;
    int lastItemChanged
    {
        get => _lastItemChanged;
        set
        {
            if (value >= NbSlotForCraft)
                value = 0;

            _lastItemChanged = value;
        }
    }

    public int NbSlotForCraft { get; private set; } = 2; // BUG: Impossible d'y accèder à l'extérieur de la classe si en constante

    // Start is called before the first frame update
    void Start()
    {
        craftManager = FindObjectOfType<CraftManager>();
        Debug.Assert(craftManager != null, "Un CraftManager doit être placé dans la scène");

        cases = GetComponentsInChildren<CraftingCaseComponent>();
        Debug.Assert(cases.Length == NbSlotForCraft);

        preview = GetComponentInChildren<CraftPreviewComponent>();
        Debug.Assert(preview != null);

        achievement = FindObjectOfType<AchievementManager>();

        onCraftSuccessful += (s, a) => ResetField();
        onCraftSuccessful += (s, a) => achievement.RegisterEvent(AchievementType.Craft);
    }

    public void ToggleUI()
    {
        gameObject.SetActive(!gameObject.activeSelf);
        isUIOpen = gameObject.activeSelf;
        ResetField();
    }

    public void ResetField()
    {
        foreach (var c in cases)
            c.RemoveItem();

        preview.HideImage();

        onFieldReset?.Invoke(this, new EventArgs());
    }

    // Retourne l'index dans de l'item dans l'interface
    public int SetItem(IItem item)
    {
        int index;
        if (cases[0].item == null)
            index = 0;
        else if (cases[1].item == null)
            index = 1;
        else
            index = lastItemChanged++;


        cases[index].SetItem(item);
        CheckCraft();

        return index;
    }

    private void CheckCraft() // Affiche le résultat du craft, avant de faire le craft, si un craft est trouvé
    {
        GameObject result;

        try
        {
            result = IsCasesEmpty() ? null : craftManager.CraftItem(cases[0].item, cases[1].item);
        } catch (CraftNotFoundException ex)
        {
            result = null;
        }


        if (result != null)
            preview.ShowImage(result.GetComponent<IItem>().displayImage);
        else
            preview.HideImage();
    }

    public void CraftItem()
    {
        try
        {
            GameObject result = IsCasesEmpty() ? null : craftManager.CraftItem(cases[0].item, cases[1].item);

            if (result != null)
                onCraftSuccessful?.Invoke(this, new OnCraftSuccessful(result));
        } catch (CraftNotFoundException ex)
        {

        }
    }

    private bool IsCasesEmpty()
    {
        foreach (var c in cases)
        {
            if (c.item == null)
                return true;
        }

        return false;
    }
}

public class OnCraftSuccessful
{
    public GameObject result;

    public OnCraftSuccessful(GameObject result)
    {
        this.result = result;
    }
}
