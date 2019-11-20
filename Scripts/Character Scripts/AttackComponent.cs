using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackComponent : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip[] sword;
    private AudioClip swordClip;

    private Camera _camera;
    public event EventHandler<PrimaryAttackArgs> OnPrimaryAttack;

    private void Awake()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        _camera = GetComponentInChildren<Camera>();
        Debug.Assert(_camera != null);
    }

    private void Update()
    {
        if (PlayerComponent.instance.equippedItem is IWeapon)
        {
            if (Input.GetMouseButtonDown(0))
                UsePrimary();
            else if (Input.GetMouseButtonDown(1))
                UseSecondary();
        }
    }

    private void UsePrimary()
    {
        HealthComponent obj = checkRay();
        int damageDone = PlayerComponent.instance.equippedItem.UsePrimary();

        if (obj != null)
            obj.TakeDamage(damageDone);


        OnPrimaryAttack?.Invoke(this, new PrimaryAttackArgs(damageDone));

        int index = UnityEngine.Random.Range(0, sword.Length);
        swordClip = sword[index];
        audioSource.clip = swordClip;
        audioSource.Play();

    }

    private void UseSecondary() => PlayerComponent.instance.equippedItem.UseSecondary();


    private HealthComponent checkRay() {
        RaycastHit hit;
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit)) {
            if (hit.collider != null) {
                return hit.collider.gameObject.GetComponent<HealthComponent>();
            }
        }

        return null;
    }
}

public class PrimaryAttackArgs : EventArgs
{
    public int Damage;

    public PrimaryAttackArgs(int damage)
    {
        Damage = damage;
    }
}