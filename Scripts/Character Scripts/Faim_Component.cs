using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Faim_Component : MonoBehaviour
{
    HealthComponent vieJoueur;
    public SimpleHealthBar faimBar;
    const float MAXFAIM = 2000;
    int Compteur = 0;

    private void Start()
    {
        vieJoueur = GetComponent<HealthComponent>();
    }
    private float _faimLevel = MAXFAIM;
    private float faimLevel
    {
        get => _faimLevel;
        set
        {
            if (value > MAXFAIM)
                value = MAXFAIM;

            _faimLevel = value;
        }
    }
    private CharacterMovingComponentv2 joueur;

   
    // Update is called once per frame
    void Update()
    {
        Famine();
        Compteur++;

    }

    void Famine()
    {

        if (faimLevel > 0)
        {
            faimLevel -= 0.5f;
            faimBar.UpdateBar(faimLevel, MAXFAIM);
            Compteur = 0;

        }
        else if (Compteur == 120)
        {

        
        
            vieJoueur.TakeDamage(5);
            Compteur = 0;


        }
           
       
    }

    public void Eat(float foodLvl)
    {
        faimLevel += foodLvl;
    }
}
