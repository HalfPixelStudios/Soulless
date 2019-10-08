using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Melee:MonoBehaviour
{
    public float swinging;
    
    public float start;
    public float travel;
    public float angle;
    public float orbit_radius;
    public float offset_x;
    public float offset_y;
    public int damage;
    public GameObject death_particle;
    public float shake_magnitude;
    private void Start()
    {
        


    }

    private void Update()
    {
        if (swinging!=0)
        {
            
            if ((angle<start+travel&&swinging==-1)||(angle>start-travel&&swinging==1))
            {
                rotate(angle);
                

            }
            else
            {
                rotate(0);
                swinging = 0;
            }
            angle -= swinging*0.2f;
            Debug.Log(transform.rotation.eulerAngles.z);
            
            
        }
        
        
    }
    public void rotate(float angle) {
        transform.rotation = Quaternion.Euler(0, 0, angle * 180 / Mathf.PI);

    }

    public void attack(float dir)
    {
        angle = start;

        swinging = dir;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<Health>() != null&&other.gameObject.GetComponent<Enemy>()==null) {
            other.gameObject.GetComponent<Health>().modHp(-1 * damage);
        }

        if (death_particle != null) {
            (Instantiate(death_particle, transform.position, transform.rotation) as GameObject).GetComponent<ParticleSystem>();

        }

        Camera.main.GetComponent<CameraController>().startShake(shake_magnitude, 0.25f); //screen shakes
        
    }
}
