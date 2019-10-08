using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldWeapon : Weapon {

    [Range(0f, 10f)] public float fire_speed;
    private float reload_timer;

    void Start() {

    }

    void Update() {
        /*
        if (reload_timer <= 0) {
            if (Input.)

        } else {
            reload_timer -= Time.deltaTime;
        }
        */
    
    }

    public override void shoot(float direct) {

    }
}
