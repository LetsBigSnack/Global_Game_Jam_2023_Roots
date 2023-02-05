using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealthPowerUp : PowerUps
{

    public HealthPowerUp(LevelUPManager lvlManger,  PlayerMovement player) : base(lvlManger,player)
    {
        base._name = "health";
        base._description = "Heals the Player";
    }
    
    public override void ApplyEffect()
    {
        base._player.AddHealth(25);
    }
    
}
