using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public int _healthLevel;

    public event EventHandler<OnDamageTakenArgs> OnDamageTaken;
    public event EventHandler<OnDeathArgs> OnDeath;

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
        OnDamageTaken?.Invoke(this, new OnDamageTakenArgs(healthPoint, healthLevel));

        if (IsDead()) {
            Debug.Log("Dead");
            OnDeath?.Invoke(this, new OnDeathArgs());
            // Afficher écran mort
            // Vider inventaire
            // Reset statistiques
        }
    }

    public void RestoreHealth(int HealhPoint) {
        healthLevel += HealhPoint;
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this , null);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        healthLevel = data.health;
    }
}

public class OnDamageTakenArgs
{
    public int damageTaken;
    public int healthRemaining;

    public OnDamageTakenArgs(int dmg, int healthLeft) {
        damageTaken = dmg;
        healthRemaining = healthLeft;
    }

}

public class OnDeathArgs {
   
}