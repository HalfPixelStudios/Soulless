using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class PowerUp : MonoBehaviour
{
    // Start is called before the first frame update
    private float initialY;
    private GameObject powerup_particle;

    public AudioClip powerup_sound;

    void Start()
    {

        if (powerup_particle == null) {
            powerup_particle = Resources.Load("Particles/powerup_particle") as GameObject;
        }
        initialY = transform.position.y;


    }

    // Update is called once per frame
    void Update()
    {
        transform.position=new Vector3(transform.position.x,initialY+Mathf.PingPong(Time.time*0.3f,0.5f),transform.position.z);
        transform.Rotate(3,6,2);
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //stupid way to check if it is the player
        if (other.gameObject.name == "Player")
        {
            
            SoundPlayer sp = (Instantiate(Resources.Load("SoundPlayer"), transform.position, transform.rotation) as GameObject).GetComponent<SoundPlayer>();
            sp.playSound(powerup_sound);
            

            Instantiate(powerup_particle, other.gameObject.transform);
            Camera.main.GetComponent<CameraController>().startShake(0.8f,0.5f);
            AddComponent(other.gameObject);
            Destroy(gameObject);

            
            
        }
        
        
        

    }

    protected abstract void AddComponent(GameObject player);
}
