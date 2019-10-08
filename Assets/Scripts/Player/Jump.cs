using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{

    public AudioClip jump_sound;

    private bool onPlatform = false;
    public float jpPower=14;
    public List<Vector2> walls;
    public LayerMask platform;
    public int numJumps=1;
    public int jumps=1;
    
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        jump_sound = Resources.Load("Audio/jump") as AudioClip;
        walls = new List<Vector2>();
        rb = transform.GetComponent<Rigidbody2D>();
        walls.Add(new Vector2(0,-0.4f));

    }

    // Update is called once per frame
    private void Update()
    {
        onPlatform = false;
        foreach (var wall in walls)
        {
            
            onPlatform |= Physics2D.OverlapCircle(new Vector2(transform.position.x+wall.x,transform.position.y+wall.y), 0.2f, platform);
        }
        

        if (onPlatform&&jumps<=0)
        {
            
            jumps = numJumps;
        }
        if (Input.GetButtonDown("Jump")&&jumps>0)
        {
            SoundPlayer sp = (Instantiate(Resources.Load("SoundPlayer"), transform.position, transform.rotation) as GameObject).GetComponent<SoundPlayer>();
            sp.playSound(jump_sound);
            rb.AddForce(Vector2.up*jpPower,ForceMode2D.Impulse);
            jumps-=1;
        }
    }


    
}
