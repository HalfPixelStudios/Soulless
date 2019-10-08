using UnityEngine;

public class GunUp:PowerUp
{
    public GameObject weapon;

    protected override void AddComponent(GameObject player)
    {
        GameObject daweapon = Instantiate(weapon, player.transform);

        player.GetComponent<Shoot>().UpdateWeapon();

    }
}