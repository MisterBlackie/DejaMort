using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Faim_Component : MonoBehaviour
{
    [SerializeField]
    [InspectorName("Secondes avant update")]
    [Tooltip("Le nombre de seconde avant d'update le niveau de faim")]
    private float TIME_BEFORE_FAIM_UPDATE = 1;

    [SerializeField]
    [InspectorName("Nb pts de faim")]
    [Tooltip("Le nombre de point de faim à retirer à chaque update de la faim")]
    private int FaimToRemove = 40;

    [SerializeField]
    [InspectorName("Barre de faim")]
    [Tooltip("La barre sur l'UI reliée à la faim")]
    private SimpleHealthBar faimBar;

    [SerializeField]
    private int damageToGive = 5;

    HealthComponent health;

    private const int FaimPtsMax = 1000;

    private int faimLevel = FaimPtsMax;
    public int FaimLevel
    {
        get => faimLevel;
        private set
        {
            value = Mathf.Clamp(value, 0, FaimPtsMax);
            faimLevel = value;
        }
    }

    private float compteurUpdate = 0;

    private void Start()
    {
        health = GetComponent<HealthComponent>();
        Debug.Assert(health != null, "Pour utiliser ThirstComponent, le game object doit avoir un HealthComponent");
        Debug.Assert(faimBar != null, "Aucune barre de soif spécifiée.");
    }

    private void Update()
    {
        if (FaimLevel > 0 && compteurUpdate >= TIME_BEFORE_FAIM_UPDATE)
        {
            UpdateFaim();
            compteurUpdate = 0;
        }

        if (FaimLevel == 0 && compteurUpdate >= TIME_BEFORE_FAIM_UPDATE)
        {
            health.TakeDamage(damageToGive);
            compteurUpdate = 0;
        }

        compteurUpdate += Time.deltaTime;
    }

    private void UpdateFaim()
    {
        FaimLevel -= FaimToRemove;
        UpdateBar();
    }
    private void UpdateBar()
    {
        faimBar.UpdateBar(FaimLevel, FaimPtsMax);
    }

    public void Eat(int foodLvl)
    {
        faimLevel += foodLvl;
        UpdateBar();
    }
}
