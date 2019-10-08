using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alfred : MonoBehaviour {

    private Enemy enemyAttr;
    private SpriteRenderer sr;
    public GameObject weapon;
    private float reload;
    private float angle;

    private float groundpound_speed = 5;
    void Start() {
        enemyAttr = GetComponent<Enemy>();
        sr = GetComponent<SpriteRenderer>();
        weapon = GetComponentInChildren<Weapon>().gameObject;
        reload = 0;
    }

    void Update() {


        if (enemyAttr.detected) {
            reload -= Time.deltaTime;

            angle = Mathf.Lerp(angle, Mathf.Atan2(enemyAttr.player.transform.position.y - transform.position.y,enemyAttr.player.transform.position.x - transform.position.x), Time.deltaTime * 4);


            if (reload <= 0) {

                float groundpound_direct = 0;
                Vector2 player_pos = enemyAttr.player.transform.position;
                if (player_pos.x > transform.position.x) {
                    groundpound_direct = 0;
                } else {
                    groundpound_direct = Mathf.PI;
                }

                Vector3 offset = new Vector3(transform.position.x+Mathf.Cos(groundpound_direct),transform.position.y,transform.position.z);
                GameObject gp = Instantiate(Resources.Load("Projectiles/ground_pound"),offset,transform.rotation) as GameObject;
                gp.GetComponent<Rigidbody2D>().velocity = new Vector2(groundpound_speed*Mathf.Cos(groundpound_direct),0);

                reload = enemyAttr.reloadTime;
            }

        } else {
            angle += 0.05f;

        }

        weapon.transform.rotation = Quaternion.Euler(0, 0, (angle * 180 / Mathf.PI));

        //sync weapon position with player
        weapon.GetComponent<Weapon>().rotate(angle);

    }
}
