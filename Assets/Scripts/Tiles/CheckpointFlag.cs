using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointFlag : MonoBehaviour {

    private Animator anim;
    private bool isWaving;

    public AudioClip checkpoint_sound;
    void Start() {
        anim = GetComponent<Animator>();
    }

    void Update() {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        
        if (Equals(collision.gameObject.name,"Player") && !isWaving) {
            PlayerHealth hp = collision.gameObject.GetComponent<PlayerHealth>();
            hp.updateCheckpoint(this.gameObject);
            hp.current_health = hp.base_health;

            isWaving = true;
            anim.SetBool("isWaving", isWaving);

            SoundPlayer sp = (Instantiate(Resources.Load("SoundPlayer"), transform.position, transform.rotation) as GameObject).GetComponent<SoundPlayer>();
            sp.playSound(checkpoint_sound);
        }
    }

}
