﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprint_Component : MonoBehaviour
{
    public SimpleHealthBar staminaBar;

    private float _staminalvl = 200;
    private float staminaLevel { get => _staminalvl;
        set
        {
            if (value > 200)
                value = 200;

            _staminalvl = value;
        }
    }
    private CharacterMovingComponentv2 joueur;

    private void Start()
    {
        joueur = GetComponent<CharacterMovingComponentv2>();
    }
    // Update is called once per frame
    void Update()
    {
        Sprint();
      
    }

    void Sprint()
    {
        if (Input.GetKey(KeyCode.LeftShift) && staminaLevel > 5)
        {
            joueur.MovementSpeed = 15;
            staminaLevel -= 0.5f;
            staminaBar.UpdateBar(staminaLevel, 200);
        }
        else
        {

            joueur.MovementSpeed = 10;
            staminaLevel += 0.1f;
            staminaBar.UpdateBar(staminaLevel, 200);
        }
    }
   
}
