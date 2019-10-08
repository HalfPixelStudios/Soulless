using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightWeapon : Weapon {

    
    public override void shoot(float direct) {
        base.shoot(direct);
        create_bullet(direct + Random.Range(-spread, spread));
    }
}
