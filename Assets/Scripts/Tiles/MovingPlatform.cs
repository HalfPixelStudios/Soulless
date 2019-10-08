using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

    [Range(0f, 20f)] public float speed;
    [Range(0f, 40f)] public float max_move_x;
    [Range(0f, 40f)] public float max_move_y;
    [Range(-1, 1)] public int start_direct_x = 1;
    [Range(-1, 1)] public int start_direct_y = 1;

    private Rigidbody2D body;

    private Vector2 start_pos;
    private Vector2 end_pos;
    private Vector2 move_direct;

    void Awake() {
        body = GetComponent<Rigidbody2D>();

        start_pos = transform.position;
        //end_pos = new Vector2(start_pos.x + max_move_x, start_pos.y + max_move_y);
        //move_direct = new Vector2(end_pos.x-start_pos.x,end_pos.y-start_pos.y).normalized;
    }

    void FixedUpdate() {
        /*
        Vector2 cur_pos = transform.position;

        if (end_pos.x-cur_pos.x <= 0 || end_pos.y - cur_pos.y <= 0) {
            move_direct = new Vector2(-1 * move_direct.x, -1 * move_direct.y);
        }
        if (cur_pos.x-start_pos.x <= 0 || cur_pos.y-start_pos.x <= 0) {
            move_direct = new Vector2(-1 * move_direct.x, -1 * move_direct.y);
        }

        body.velocity = new Vector2(speed * move_direct.x, speed * move_direct.y);
        */

        
        float move_x = 0;
        float move_y = 0;
        if (max_move_x != 0) { move_x = Mathf.PingPong(Time.time * speed, max_move_x*2)-max_move_x; }
        if (max_move_y != 0) { move_y = Mathf.PingPong(Time.time * speed, max_move_y*2)-max_move_y; }

        body.velocity = new Vector2(move_x*start_direct_x,move_y*start_direct_y);
        

        /*
        float move_x = start_pos.x;
        float move_y = start_pos.y;
        if (max_move_x != 0) { move_x = Mathf.PingPong(Time.time * speed, max_move_x); }
        if (max_move_y != 0) { move_y = Mathf.PingPong(Time.time * speed, max_move_y); }

        transform.position = new Vector2(move_x, move_y);
        */
    }
}
