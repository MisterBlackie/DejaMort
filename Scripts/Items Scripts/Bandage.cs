using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Bandage : ScriptableObject, IHealingItem
{
    public int healthToRestore { get; private set; } = 20;
    public string itemName { get; private set; } = "Bandage";
    public string description { get; private set; } = "Un bandage qui soigne vos bobos.";
    public Image displayImage { get; private set; }

    public void Use()
    {
        PlayerComponent player = FindObjectOfType<PlayerComponent>();

        Debug.Assert(player != null);

        HealthComponent playerHealth = player.GetComponent<HealthComponent>();

        playerHealth.RestoreHealth(healthToRestore);
    }

}