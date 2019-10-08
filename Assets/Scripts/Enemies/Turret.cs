using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

    private Enemy enemAttr;
    private float reload;
    private float angle;

    private GameObject weapon;

    void Start() {
        weapon = GetComponentInChildren<Weapon>().gameObject;
        enemAttr = GetComponent<Enemy>();
        reload = 0;

    }
    
    void Update()
    {
        
        
        
        if (enemAttr.detected)
        {
            reload -= Time.deltaTime;
            angle = Mathf.Lerp(angle,Mathf.Atan2(enemAttr.player.transform.position.y - transform.position.y,
                enemAttr.player.transform.position.x - transform.position.x),Time.deltaTime*4);
            
            if (reload <=0)
            {

                weapon.GetComponent<Weapon>().shoot(angle);
            

                reload = enemAttr.reloadTime;
            }
        }
        else
        {
            angle += 0.05f;

        }
        

        weapon.transform.rotation = Quaternion.Euler(0, 0, (angle * 180 / Mathf.PI));

        //sync weapon position with player
        weapon.GetComponent<Weapon>().rotate(angle);
        
    }
}
