using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableBlock : MonoBehaviour {

    private Health health;
    private Animator anim;

    void Start() {
        health = GetComponent<Health>();
        anim = GetComponent<Animator>();
        anim.speed = 0;
        //transform.rotation = Quaternion.Euler(0,0,Random.Range(0,3)*90*Mathf.PI/180); //spawn block in a random orientation
    }

    void Update() {
        float normalized_hp = (float)health.current_health / (float)health.base_health;
        anim.Play("breakable_block",0,1-normalized_hp);
    }
}
