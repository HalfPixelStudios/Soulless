using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunWeapon : Weapon {

    [Range(1f, 7f)] public int bullet_num;

    void Start() {
        
    }

    void Update() {
        
    }

    public override void shoot(float direct) {
        base.shoot(direct);
        float spacing = spread * 2 / bullet_num;
        for (int i = 0; i < bullet_num; i++) {
            create_bullet(direct - spread + spacing * i + Random.Range(0,spread/2));
        }
    }
}
