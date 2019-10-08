using UnityEngine;

public class EyesUp:PowerUp
{
    protected override void AddComponent(GameObject player)
    {
        Camera.main.orthographicSize = 4;
    }
}