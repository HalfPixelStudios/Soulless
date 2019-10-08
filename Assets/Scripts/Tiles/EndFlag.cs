using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndFlag:MonoBehaviour
{
    //public string sceneName;
    public GameObject spawn_flag;
    public RuntimeAnimatorController default_anim;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //SceneManager.LoadScene(sceneName);
        GameObject player = collision.gameObject;
        if (Equals(player.name,"Player")) {
            player.transform.position = spawn_flag.transform.position;

            if (player.GetComponent<Jump>() != null) {
                Destroy(player.GetComponent<Jump>());
            } 

            if (player.GetComponent<Movement>() != null) {
                player.GetComponent<Movement>().canDash = false;
            }

            if (player.GetComponent<Shoot>() != null) {
                player.GetComponent<Shoot>().UpdateWeapon();
            }

            if (player.GetComponent<Animator>()) {
                player.GetComponent<Animator>().runtimeAnimatorController = null;
            }


        }


    }
        
}
