using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health {

    public GameObject respawn_particle;

    private GameObject last_checkpoint;
    public int deaths=0;
    private Vector2 world_spawn;

    void Start() {
        base.Start();
        world_spawn = transform.position;
    }

    public void updateCheckpoint(GameObject new_checkpoint) {
        last_checkpoint = new_checkpoint;
    }

    public override void onDeath()
    {
        deaths += 1;
        

        if (last_checkpoint == null) {
            transform.position = world_spawn;
        } else {
            transform.position = last_checkpoint.transform.position;
        }
        

        current_health = base_health;
    }


}
