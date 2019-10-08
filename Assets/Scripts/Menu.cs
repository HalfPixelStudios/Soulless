using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu:MonoBehaviour
{
    public GameObject player;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Camera.main.orthographicSize = 0.1f;
            
            
            Camera.main.GetComponent<CameraController>().target = player;
            player.GetComponent<Rigidbody2D>().gravityScale = 3;
            
            Destroy(gameObject);
        }
        
    }
}
