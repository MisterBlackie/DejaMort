using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackComponent : MonoBehaviour
{
    private Camera _camera;

    private void Awake()
    {
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

        if (obj != null)
            obj.TakeDamage(PlayerComponent.instance.equippedItem.UsePrimary());
        
        // Animatiom
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