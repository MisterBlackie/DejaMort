using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saveCharacter_Component : MonoBehaviour
{
    public PlayerComponent joueur;
    public HealthComponent vie;
    public void SavePlayer()
    {

        SaveSystem.SavePlayer(joueur , vie);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        float vie = data.health;
        Vector3 position;

        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;

    }
}
