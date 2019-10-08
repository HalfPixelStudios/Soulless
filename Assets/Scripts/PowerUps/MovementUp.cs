using UnityEngine;

public class MovementUp:PowerUp
{
    protected override void AddComponent(GameObject player)
    {
        player.AddComponent<Movement>().speed = 5;
    }
}
