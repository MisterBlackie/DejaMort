using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterMovingComponentv2))]
[RequireComponent(typeof(ItemPickUpComponent))]
[RequireComponent(typeof(HealthComponent))]
[RequireComponent(typeof(AnimationTriggerComponent))]
[RequireComponent(typeof(AttackComponent))]
[RequireComponent(typeof(HotbarComponent))]
public class PlayerComponent : MonoBehaviour
{
    private HealthComponent vie;
    public GameObject rightHandJoint;
    public static PlayerComponent instance { get; private set; }

    public event EventHandler<EquippedItemChangedArgs> OnEquippedItemChanged;

    IInterableItem _equippedItem;
    public IInterableItem equippedItem
    {
        get => _equippedItem;

        set
        {
            IInterableItem lastItem = _equippedItem;
            _equippedItem = value;
           OnEquippedItemChanged?.Invoke(this, new EquippedItemChangedArgs(lastItem, value));
        }
    }

    private void OnEnable()
    {
        vie = GetComponent<HealthComponent>();
        if (SwitchScene.IsPlayerLoad == true )
        {
            LoadPlayer();
        }
        
    }

    private void Awake()
    {
        instance = this;
    }

    public void SavePlayer()
    {
      
        SaveSystem.SavePlayer( this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        Vector3 position;

        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
        
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (equippedItem == null)
                return;

            if (equippedItem is IInterableItem &&
                !typeof(IWeapon).IsAssignableFrom(equippedItem.GetType()))
            {
                equippedItem.UsePrimary();
            }
        }
    }
}

public class EquippedItemChangedArgs {
    public IInterableItem NewItem;
    public IInterableItem LastItem;
    public EquippedItemChangedArgs(IInterableItem newItem, IInterableItem lastItem)
    {
        NewItem = newItem;
        LastItem = lastItem;
    }
}