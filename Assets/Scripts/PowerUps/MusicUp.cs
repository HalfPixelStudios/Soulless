using UnityEngine;
public class MusicUp:PowerUp
{
    public GameObject music;
    protected override void AddComponent(GameObject player)
    {
        Instantiate(music).GetComponent<AudioSource>().Play();

    }
}
