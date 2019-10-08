using UnityEngine;

public class ArmUp:PowerUp
{
    public RuntimeAnimatorController armAnim;
    protected override void AddComponent(GameObject player)
    {
        player.GetComponent<Animator>().runtimeAnimatorController = armAnim;
        player.GetComponent<Jump>().walls.Add(new Vector2(-0.3f,0));
        player.GetComponent<Jump>().walls.Add(new Vector2(0.3f,0));
        
    }
}