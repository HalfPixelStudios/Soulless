using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveProjectile : Projectile {

    [Range(0f, 4f)] public float explosion_radius;
    [Range(0f, 1000f)] public float explosion_force;

    private void explode() {
        Collider2D[] nearby = Physics2D.OverlapCircleAll(transform.position, explosion_radius); //get all nearby colliders

        foreach (Collider2D obj in nearby) {
            Rigidbody2D body = obj.GetComponent<Rigidbody2D>();
            if (body != null) {
                //Find out what direction to apply the explosion force in
                Vector2 obj_pos = obj.gameObject.transform.position;
                Vector2 origin_pos = transform.position;
                Vector2 force_direct = new Vector2(obj_pos.x-origin_pos.x,obj_pos.y-origin_pos.y).normalized;

                body.AddForce(new Vector2(explosion_force*force_direct.x, explosion_force * force_direct.y));
            }
        }
    }

    public override void onDeath() {
        explode();
        Destroy(this.gameObject);
    }
}
