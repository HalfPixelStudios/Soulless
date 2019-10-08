using UnityEngine;
public class LegUp:PowerUp
{
    public RuntimeAnimatorController legAnim;
    public LayerMask ground;

    protected override void AddComponent(GameObject player)
    {
        
        player.GetComponent<Animator>().runtimeAnimatorController = legAnim;
        player.AddComponent<Jump>();
        player.GetComponent<Jump>().platform=ground;
        

    }
}
