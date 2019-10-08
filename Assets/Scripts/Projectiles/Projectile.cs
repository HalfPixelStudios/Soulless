using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Projectile : MonoBehaviour {

    protected Rigidbody2D body;
    public GameObject death_particle;
    public float initAngle;
    public bool isEnemy;

    [Range(0f, 10f)] public int damage;
    [Range(0f, 30f)] public float speed;
    [Range(0f, 20f)] public float range;
    [Range(0f, 1f)] public float shake_magnitude;

    protected Vector2 spawn_pos;

    public AudioClip deathSound;

    public void Awake() {
        body = GetComponent<Rigidbody2D>();
        spawn_pos = transform.position;
    }
    

    public void Update() {
        
        if (Vector2.Distance(transform.position,spawn_pos) > range) { //projectile can only travel a certain range
            Destroy(this.gameObject);
        }
    }

    public void setDirection(float direct)
    {
        initAngle = Mathf.Rad2Deg*direct;
        body.velocity = new Vector2(speed * Mathf.Cos(direct), (speed * Mathf.Sin(direct)));
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (isEnemy&&collision.gameObject.GetComponent<Enemy>()!=null)
        {
            return;
        }
        //Particles for when bullet dies

        //Particles for hitting the enemy
        if (collision.GetComponent<Health>() != null) {
            collision.GetComponent<Health>().modHp(-1 * damage);
            onHit();
        }

        if (death_particle != null) {
          
            (Instantiate(death_particle, transform.position, transform.rotation) as GameObject).GetComponent<ParticleSystem>();

        }

        SoundPlayer sp = (Instantiate(Resources.Load("SoundPlayer"), transform.position, transform.rotation) as GameObject).GetComponent<SoundPlayer>();
        sp.playSound(deathSound);

        onDeath();
        Camera.main.GetComponent<CameraController>().startShake(shake_magnitude, 0.25f); //screen shakes
    }

    public virtual void onDeath() {
        Destroy(this.gameObject);
    }

    public virtual void onHit() {
        Destroy(this.gameObject);
    }

}
