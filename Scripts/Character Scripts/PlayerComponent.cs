using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterMovingComponentv2))]
[RequireComponent(typeof(ItemPickUpComponent))]
[RequireComponent(typeof(HealthComponent))]
[RequireComponent(typeof(AnimationTriggerComponent))]
[RequireComponent(typeof(AttackComponent))]
public class PlayerComponent : MonoBehaviour
{
    public static PlayerComponent instance { get; private set; }

    public IInterableItem equippedItem { get; set; }

    private void Awake()
    {
        // Pour le multiplayer, on peux faire une liste de PlayerComponent
        instance = this;
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(null, this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        Vector3 position;

        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
    }
}