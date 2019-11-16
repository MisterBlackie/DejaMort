using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Flashlight : MonoBehaviour, IItem, IInterableItem, IHoldable
{
    public string itemName { get; private set; } = "Lampe de poche";

    public string description { get; private set; } = "Voir dans le noir, c'est toujours mieux";

    public Sprite displayImage { get; private set; }

    public bool hasBeenPickupOnce { get; private set; } = false;

    public Vector3 HandPosition { get; private set; }

    public Vector3 ObjectRotation { get; private set; }

    private Light flashlight;

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
        
    }

    public bool Use()
    {
        transform.SetParent(PlayerComponent.instance.rightHandJoint.transform);
        PlayerComponent.instance.equippedItem = this;
        transform.localPosition = HandPosition;
        transform.localEulerAngles = ObjectRotation;
        gameObject.SetActive(true);
        return true;
    }

    // Start is called before the first frame update
    void Start()
    {
        flashlight = GetComponentInChildren<Light>();
        displayImage = Resources.Load<Sprite>("Sprite/flashlight");

        HandPosition = new Vector3(0.000202f, 0.001072f, -0.00021f);
        ObjectRotation = new Vector3(-72.915f, -176.031f, 9.72f);
    }

    public int UsePrimary()
    {
        flashlight.enabled = !flashlight.enabled;
        return 0;
    }

    public int UseSecondary()
    {
        return 0;
    }

    public void EnleverCollider()
    {

    }
}
