using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour {


    public GameObject projectile;

    public AudioClip shootSound;

    [Range(0f, 1f)] public float spread;

    [Range(0f, 2f)] public float orbit_radius;
    [Range(-1f, 1f)] public float offset_x;
    [Range(-1f, 1f)] public float offset_y;

    void Start() {
    }

    void Update() {


    }

    public void rotate(float direct) {
        transform.rotation = Quaternion.Euler(0, 0, direct * 180 / Mathf.PI);

        //sync weapon position with owner
        float new_x = transform.parent.position.x + orbit_radius * Mathf.Cos(direct) + offset_x;
        float new_y = transform.parent.position.y + orbit_radius * Mathf.Sin(direct) + offset_y;
        transform.position = new Vector3(new_x, new_y, transform.parent.position.z);
    }

    public virtual void shoot(float direct) {
        SoundPlayer sp = (Instantiate(Resources.Load("SoundPlayer"), transform.position, transform.rotation) as GameObject).GetComponent<SoundPlayer>();
        sp.playSound(shootSound);

    }

    protected void create_bullet(float bullet_direct) {
        GameObject p = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
        //Physics2D.IgnoreCollision(gameObject.GetComponent<BoxCollider2D>(), p.GetComponent<BoxCollider2D>()); //own bullet cannot hit self
        p.GetComponent<Projectile>().setDirection(bullet_direct);
    }
}
