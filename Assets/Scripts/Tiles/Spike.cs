using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour {

    void Start() {
        
    }

    void Update() {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.GetComponent<Health>() != null) {
            collision.gameObject.GetComponent<Health>().modHp(-1000000);
            Camera.main.GetComponent<CameraController>().startShake(0.5f,0.4f);
        }

    }
}
