using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Fighter : MonoBehaviour
{
    Enemy enemAttr;
    private float reload;
    private Rigidbody2D rb;
    public GameObject weapon;
    public float speed;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemAttr = GetComponent<Enemy>();
    }

    private void Update()
    {
        weapon.GetComponent<SpriteRenderer>().flipX = enemAttr.dir == -1;
        if (enemAttr.attack)
        {
            rb.velocity=new Vector2(0,rb.velocity.y);
            reload += Time.deltaTime;
            if (reload > enemAttr.reloadTime)
            {
                weapon.GetComponent<Melee>().attack(enemAttr.dir);
                reload = 0;

            }
        }else if (enemAttr.detected)
        {
            rb.velocity=new Vector2(enemAttr.dir*speed,rb.velocity.y);
            
        }
    }
}
