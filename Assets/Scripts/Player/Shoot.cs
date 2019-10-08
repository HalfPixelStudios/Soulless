using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Shoot : MonoBehaviour {


    [SerializeField] private Weapon weapon;

    void Start() {
        weapon = GetComponentInChildren<Weapon>();
    }

    private void Update() {
        if (weapon == null)
        {
            weapon = GetComponentInChildren<Weapon>();
            return;
        }

        //rotate weapon based on mouse pos
        Vector2 mouse_pos = Input.mousePosition;
        float mouse_angle = Mathf.Atan2(mouse_pos.y - Screen.height / 2, mouse_pos.x - Screen.width / 2);

        weapon.rotate(mouse_angle);

        if (Input.GetMouseButtonDown(0)) {

            weapon.shoot(mouse_angle);

        }
    }

    public void UpdateWeapon()
    {
        if (weapon != null) { //destroy old weapon
            Destroy(weapon.gameObject);
        }
    }

    void FixedUpdate() {

    }

}
