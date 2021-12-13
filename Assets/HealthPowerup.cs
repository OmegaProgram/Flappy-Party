using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerup : PowerUp
{
    public float healthAmount;

    public override void activateEffect(GameObject player)
    {
        GameManager.instance.addHealth(player.name, 1);
    }
}
