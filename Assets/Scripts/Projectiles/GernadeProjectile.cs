using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GernadeProjectile : Projectile {


    [Range(0f, 4f)] public float explosion_radius;
    [Range(0f, 1000f)] public float explosion_force;

    [Range(0f, 10f)] public float lifetime;

    private GameObject idle_particle;
    private Rigidbody2D rb;

    private float time_alive = 0;

    void Start() {
        base.Awake();
        rb = GetComponent<Rigidbody2D>();
    }

    new void Update() {
        base.Update();
        time_alive += Time.deltaTime;

        if (time_alive > lifetime) {
            explode();
            (Instantiate(death_particle, transform.position, transform.rotation) as GameObject).GetComponent<ParticleSystem>();
            Destroy(this.gameObject);
        }

        
        if (rb.velocity.x == 0 && rb.velocity.y == 0 && idle_particle == null) { //starts particles when gernade is on ground and not moving
            idle_particle = Instantiate(Resources.Load("Particles/gernade_particle"),transform.position,transform.rotation) as GameObject;
            idle_particle.transform.parent = transform;
        } else if (rb.velocity.x != 0 && rb.velocity.y != 0 && idle_particle != null) { //if the gernade starts to move, destroy particles
            Destroy(idle_particle);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        //Particles for when bullet dies

        //Particles for hitting the enemy
        if (collision.gameObject.GetComponent<Health>() != null) {
            collision.gameObject.GetComponent<Health>().modHp(-1 * damage);
            (Instantiate(death_particle, transform.position, transform.rotation) as GameObject).GetComponent<ParticleSystem>();
        }

        Camera.main.GetComponent<CameraController>().startShake(shake_magnitude, 0.25f); //screen shakes
    }

    private void explode() {
        Collider2D[] nearby = Physics2D.OverlapCircleAll(transform.position, explosion_radius); //get all nearby colliders

        foreach (Collider2D obj in nearby) {
            Rigidbody2D body = obj.GetComponent<Rigidbody2D>();
            if (body != null) {
                //Find out what direction to apply the explosion force in
                Vector2 obj_pos = obj.gameObject.transform.position;
                Vector2 origin_pos = transform.position;
                Vector2 force_direct = new Vector2(obj_pos.x - origin_pos.x, obj_pos.y - origin_pos.y).normalized;

                body.AddForce(new Vector2(explosion_force * force_direct.x, explosion_force * force_direct.y));
            }
        }
    }

}
