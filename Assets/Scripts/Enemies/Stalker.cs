using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stalker : MonoBehaviour {

    [Range(0f, 10f)] public float speed;
    [Range(0f, 50f)] public float search_distance;
    private float reload;

    private Enemy enemyAttr;
    private Weapon weapon;
    private Rigidbody2D body;

    void Start() {
        weapon = GetComponentInChildren<Weapon>();
        weapon.GetComponent<Weapon>().rotate(270 * Mathf.PI / 180); //always pointed straight down 
        enemyAttr = GetComponent<Enemy>();
        body = GetComponent<Rigidbody2D>();
        reload = 0;
    }

    void Update() {


        if (enemyAttr.detected) {
            reload -= Time.deltaTime;

            //move towards player
            Vector2 player_pos = enemyAttr.player.transform.position;
            if (player_pos.x > transform.position.x) {
                body.AddForce(new Vector2(speed,0));
            } else {
                body.AddForce(new Vector2(-speed, 0));
            }

            if (reload <= 0 && player_pos.y < transform.position.y) {
                weapon.shoot(270 * Mathf.PI / 180);
                reload = enemyAttr.reloadTime;
            }
        } else { //idle state

            float move_x = 0;
            if (search_distance != 0) { move_x = Mathf.PingPong(Time.time * speed, search_distance * 2) - search_distance; }

            body.velocity = new Vector2(move_x, 0);

        }
    }
}
