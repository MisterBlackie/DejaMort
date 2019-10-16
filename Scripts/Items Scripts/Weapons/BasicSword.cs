using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSword : MonoBehaviour, IWeapon
{
    public int Damage { get; private set; } = 10;

    public int Durability { get; private set; } = 100;

    public string itemName { get; private set; } = "Vielle épée";

    public string description { get; private set; } = "Une vielle épée qui ne fait pas beaucoup de dommage.";

    public Sprite displayImage { get; private set; }

    public bool hasBeenPickupOnce { get; private set; }

    public Vector3 HandPosition { get; private set; }

    public Vector3 ObjectRotation { get; private set; }

    public void Awake()
    {
        hasBeenPickupOnce = false;
        displayImage = Resources.Load<Sprite>("Sprite/basicSword");

        HandPosition = new Vector3(0.301f, 1.177f, 0.406f);
        ObjectRotation = new Vector3(-60.462f, -79.814f, 174.226f);
    }
    public bool isBroken() => Durability <= 0;

    public void OnDrop()
    {
        gameObject.SetActive(true);
    }

    public void OnPickup()
    {
        gameObject.SetActive(false);
        hasBeenPickupOnce = true;
    }

    public void OnUse()
    {
        Durability -= 1;
    }

    public void Repair(int RepairPts) => throw new System.NotImplementedException();

    public void Use() // Équipe l'arme
    {
        transform.SetParent(PlayerComponent.instance.gameObject.transform);
        transform.localPosition = HandPosition;
        transform.localEulerAngles = ObjectRotation;
        gameObject.SetActive(true);
    }

    public int UsePrimary()
    {
        
        return isBroken() ? Damage / 2 : Damage;
    }

    public int UseSecondary()
    {
        // Does nothing
        return 0;
    }
}
