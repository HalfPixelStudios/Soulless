using UnityEngine;
public class FinalFlag:MonoBehaviour
{
    //public string sceneName;

    public RuntimeAnimatorController default_anim;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //SceneManager.LoadScene(sceneName);
        GameObject player = collision.gameObject;
        if (Equals(player.name,"Player"))
        {
            Camera.main.GetComponent<CameraController>().target = null;
            Camera.main.transform.position=new Vector3(2000,6969696,-1);




        }


    }
        
}