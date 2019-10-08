using UnityEngine;

public class DashUp:PowerUp
{
    public RuntimeAnimatorController dashAnim;
    protected override void AddComponent(GameObject player)
    {
        player.GetComponent<Movement>().canDash = true;
        player.GetComponent<Animator>().runtimeAnimatorController = dashAnim;
    }
}