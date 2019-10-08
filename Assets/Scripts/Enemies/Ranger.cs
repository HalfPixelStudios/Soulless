//pronounce R-aa-n-g-uu-r

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Ranger:MonoBehaviour
{
    private Enemy enemAttr;
    private Weapon weapon;
    private float reload;

    private void Start()
    {
        enemAttr = GetComponent<Enemy>();
        weapon = GetComponentInChildren<Weapon>();

    }

    private void Update()
    {
        if (enemAttr.detected)
        {
            reload += Time.deltaTime;
            if (reload > enemAttr.reloadTime)
            {
                weapon.shoot(enemAttr.dir == 1 ? 0 : Mathf.Deg2Rad*180);
                reload = 0;
            }

        }
        

    }
}
