﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public SimpleHealthBar healthBar;
    public Animator animator;
    private int _healthLevel;
   private CharacterMovingComponentv2 joueur;
    public event EventHandler<OnDamageTakenArgs> OnDamageTaken;
    public event EventHandler<OnDeathArgs> OnDeath;

    protected int healthLevel {
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
        joueur = GetComponent<CharacterMovingComponentv2>();
        healthLevel = MAX_HEALTH;
        AchievementManager acvManager = FindObjectOfType<AchievementManager>();
        Debug.Assert(acvManager != null);

        OnDeath += (s, a) => {
            acvManager.RegisterEvent(AchievementType.Die);
        };
    }

    public bool IsDead() => healthLevel <= 0;

    public virtual void TakeDamage(int healthPoint) {

       
        healthLevel -= healthPoint;
        healthBar.UpdateBar(healthLevel, 100);
        OnDamageTaken?.Invoke(this, new OnDamageTakenArgs(healthPoint, healthLevel));
        Debug.Log(healthLevel);
        if (IsDead()) {
            Debug.Log("Dead");
            OnDeath?.Invoke(this, new OnDeathArgs());
            animator.SetTrigger("Fade_Out");
            joueur.UnlockMouse();
            
        }
    }

    public void RestoreHealth(int HealhPoint) {
        healthLevel += HealhPoint;
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

public class OnDeathArgs : CharacterMovingComponentv2 {

   
}