using UnityEngine;

public class GlassesUp:PowerUp
{
    protected override void AddComponent(GameObject player)
    {
        Camera.main.orthographicSize = 6;
    }
}
