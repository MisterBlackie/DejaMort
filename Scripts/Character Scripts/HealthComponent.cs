using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    private int _healthLevel;

    private int healthLevel {
        get {
            return _healthLevel;
        }

        set {
            _healthLevel = Mathf.Clamp(value, 0, MAX_HEALTH);
        }
    }

    [SerializeField]
    [Tooltip("Nombre maximal de vie au départ")]
    [InspectorName("Pts Vie max.")]
    private const int MAX_HEALTH = 100;

    private void Start()
    {
        healthLevel = MAX_HEALTH;
    }

    public bool IsDead() => healthLevel <= 0;

    public void TakeDamage(int healthPoint) {

        healthLevel -= healthPoint;


        if (IsDead()) {
            // Afficher écran mort
            // Vider inventaire
            // Reset statistiques
        }
    }

    public void RestoreHealth(int HealhPoint) {
        healthLevel += HealhPoint;
    }
}
