using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    [Range(0, 10)] public int base_health;
    public GameObject death_particle;
    public int current_health;

    public AudioClip hitSound;
    public AudioClip deathSound;


    protected void Start() {

        current_health = base_health;  

        if (death_particle == null) { death_particle = Resources.Load("Particles/death_particle") as GameObject; }
    }

    void Update() {
    }

    public void modHp(int deltaHp) {
        current_health += deltaHp;

        if (deltaHp < 0 && current_health > 0) {
            (Instantiate(Resources.Load("Particles/hit_particle"), transform.position, transform.rotation) as GameObject).GetComponent<ParticleSystem>();
            //Camera.main.GetComponent<CameraController>().startShake(0.08f, 0.25f);

            SoundPlayer sp = (Instantiate(Resources.Load("SoundPlayer"), transform.position, transform.rotation) as GameObject).GetComponent<SoundPlayer>();
            sp.playSound(hitSound);

        }

        if (current_health < 0) {
            (Instantiate(death_particle, transform.position, transform.rotation) as GameObject).GetComponent<ParticleSystem>();
            onDeath();
            SoundPlayer sp = (Instantiate(Resources.Load("SoundPlayer"), transform.position, transform.rotation) as GameObject).GetComponent<SoundPlayer>();
            sp.playSound(deathSound);
        }
        
    }

    public virtual void onDeath() {
        Destroy(this.gameObject);
    }
}
