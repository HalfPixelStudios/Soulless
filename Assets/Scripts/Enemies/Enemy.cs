using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool detected = false;
    public bool attack = false;
    public float attack_range;
    public float sight;
    public float reloadTime;
    public float dir = 0;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        float dist=Mathf.Sqrt(Mathf.Pow(transform.position.x-player.transform.position.x,2)+Mathf.Pow(transform.position.y-player.transform.position.y,2));
        dir = Mathf.Sign( player.transform.position.x-transform.position.x);
        if (dist < sight)
        {
            detected = true;
        }
        else
        {
            detected = false;
            //just in case sight is greater than attack for some stupid reason
            attack = false;
        }

        if (dist < attack_range)
        {
            attack = true;
            
            


        }
        else
        {
            attack = false;
        }


    }

    void turnEnemy()
    {
        GetComponent<SpriteRenderer>().flipX = dir == -1;
        
    }
}