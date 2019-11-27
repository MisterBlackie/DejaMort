using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirstComponent : MonoBehaviour
{
    [SerializeField]
    [InspectorName("Secondes avant update")]
    [Tooltip("Le nombre de seconde avant d'update le niveau de soif")]
    private float TIME_BEFORE_THIRST_UPDATE = 1;

    [SerializeField]
    [InspectorName("Nb pts de soif")]
    [Tooltip("Le nombre de point de soif à retirer à chaque update de la soif")]
    private int ThirstToRemove = 40;

    [SerializeField]
    [InspectorName("Barre de soif")]
    [Tooltip("La barre sur l'UI reliée à la soif")]
    private SimpleHealthBar thirstBar;

    [SerializeField]
    private int damageToGive = 5;

    HealthComponent health;

    private const int ThirstPtsMax = 1000;

    private int thirstLevel = ThirstPtsMax;
    public int ThirstLevel
    {
        get => thirstLevel;
        private set
        {
            value = Mathf.Clamp(value, 0, ThirstPtsMax);
            thirstLevel = value;
        }
    }

    private float compteurUpdate = 0;

    private void Start()
    {
        health = GetComponent<HealthComponent>();
        Debug.Assert(health != null, "Pour utiliser ThirstComponent, le game object doit avoir un HealthComponent");
        Debug.Assert(thirstBar != null, "Aucune barre de soif spécifiée.");
    }

    private void Update()
    {
        if (ThirstLevel > 0 && compteurUpdate >= TIME_BEFORE_THIRST_UPDATE)
        {
            UpdateThirst();
            compteurUpdate = 0;
        }

        if (ThirstLevel == 0 && compteurUpdate >= TIME_BEFORE_THIRST_UPDATE)
        {
            health.TakeDamage(damageToGive);
            compteurUpdate = 0;
        }

        compteurUpdate += Time.deltaTime;
    }

    private void UpdateThirst()
    {
        ThirstLevel -= ThirstToRemove;
        UpdateBar();
    }
    private void UpdateBar()
    {
        thirstBar.UpdateBar(ThirstLevel, ThirstPtsMax);
    }

    public void Drink(int waterLvl)
    {
        ThirstLevel += waterLvl;
        UpdateBar();
    }


}