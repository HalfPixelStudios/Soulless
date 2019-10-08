using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fragger : MonoBehaviour
{
    public float jpPower;
    public float interval;
    public float time;
    public float shootTime;
    public float shTime;
    public bool shot;
    private Weapon weapon;
    private Enemy enem;
    void Start()
    {
        weapon=GetComponentInChildren<Weapon>();
        enem = GetComponent<Enemy>();



    }
    void Update()
    {
        if (!enem.detected)
        {
            return;
        }
        time += Time.deltaTime;
        if (shTime > 0)
        {
           

            shTime -= Time.deltaTime;
            
        }
        else
        {
            shTime = shootTime;
            weapon.shoot(Mathf.Deg2Rad*Random.Range(45,136));
        }
        
        if (time > interval) 
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up*jpPower,ForceMode2D.Impulse);
            GetComponent<Animator>().SetBool("isJumping",true);
            time = 0;
            
        }

        if (time > 1)
        {
            GetComponent<Animator>().SetBool("isJumping", false);
        }

    }
}
