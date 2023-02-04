using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SlowPowerUp : PowerUps
{

    public SlowPowerUp(LevelUPManager lvlManger,  PlayerMovement player) : base(lvlManger,player)
    {
        base._name = "slow";
        base._description = "Slows down the enemy";
    }
    
    public override void ApplyEffect()
    {
        base._levelUpManager.SlowDownEnemies();
    }
    
}
