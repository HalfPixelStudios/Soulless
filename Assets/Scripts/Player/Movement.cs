using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float speed;
    private Rigidbody2D rb;

    //Animation stuff
    private Animator anim;
    private SpriteRenderer sr;
    private bool isMoving;
    public int facing;
    public float dashTime;
    public float dashDelta;
    public float dashSpeed;
    public bool canDash;
    void Start() {
        rb = transform.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        facing = 1;
        canDash = false;
        dashSpeed = 15;
        dashTime = 1.5f;

    }

    void FixedUpdate() {
        
        
        float dir = Input.GetAxisRaw("Horizontal");
        if (dir != 0)
        {
            
            Vector2 target_velocity = new Vector2(dir * speed, rb.velocity.y);
            if (Mathf.Abs(target_velocity.x) > Mathf.Abs(rb.velocity.x))
            {
                rb.velocity = new Vector2(Mathf.Lerp(target_velocity.x,rb.velocity.x, Time.deltaTime),target_velocity.y);
                
            }
            
            
        }
        
        


        if (anim.runtimeAnimatorController != null) {

            isMoving = false;
            if (dir != 0) {
                isMoving = true;
            }

            anim.SetBool("isMoving", isMoving);
        }
        if (canDash)
        {
            dashDelta -= Time.deltaTime;
            if (Input.GetMouseButtonDown(1) && dashDelta < 0)
            {
                dashDelta = dashTime;
                rb.AddForce(new Vector2(dashSpeed * facing, 0), ForceMode2D.Impulse);

            }
        }


    }
    private void Update() {
        //flip player based on mouse position
        Vector2 mouse_pos = Input.mousePosition;
        float mouse_angle = Mathf.Atan2(mouse_pos.y - Screen.height / 2, mouse_pos.x - Screen.width / 2);

        if (mouse_pos.x - Screen.width/2 < 0 && !sr.flipX) { //if the mouse is on the left side and the player hasnt been flipped yet
            sr.flipX = true;
            facing = -1;
        } else if (mouse_pos.x - Screen.width / 2 >= 0 && sr.flipX) {
            sr.flipX = false;
            facing = 1;
        }

   
    }

}
