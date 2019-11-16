using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Bandage : MonoBehaviour, IHealingItem
{
    public int healthToRestore { get; private set; } = 20;
    public string itemName { get; private set; } = "Bandage";
    public string description { get; private set; } = "Un bandage qui soigne vos bobos.";
    public Sprite displayImage { get; private set; }

    public bool hasBeenPickupOnce { get; private set; } = false;

    void Awake()
    {
        displayImage = Resources.Load<Sprite>("Sprite/medkit");
    }

    public bool Use()
    {
        PlayerComponent player = FindObjectOfType<PlayerComponent>();

        Debug.Assert(player != null);

        HealthComponent playerHealth = player.GetComponent<HealthComponent>();

        playerHealth.RestoreHealth(healthToRestore);

        OnUse();

        return true;
    }

    public void OnPickup()
    {
        gameObject.SetActive(false);
        hasBeenPickupOnce = true;
    }

    public void OnDrop()
    {
        gameObject.SetActive(true);
    }

    public void OnUse()
    {
        Destroy(this);
    }
}