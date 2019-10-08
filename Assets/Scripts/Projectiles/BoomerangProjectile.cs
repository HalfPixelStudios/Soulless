using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class BoomerangProjectile:Projectile
{
    private bool returning=false;
    

    new void Update()
    {
        transform.Rotate(0,0,10f);
        float dist = Vector2.Distance(transform.position, spawn_pos);


        if ( !returning&&dist> range)
        {

            returning = true;
            setDirection(initAngle==0?180*Mathf.Deg2Rad:0);
            
        }

        if (returning && dist < 0.5f)
        {
            Destroy(gameObject);
            
        }


    }

    public override void onDeath()
    {
        
    }

    public override void onHit()
    {
        
    }
}