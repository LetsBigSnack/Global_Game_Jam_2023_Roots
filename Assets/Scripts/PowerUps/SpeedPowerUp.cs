using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpeedPowerUp : PowerUps
{

    public SpeedPowerUp(LevelUPManager lvlManger,  PlayerMovement player) : base(lvlManger,player)
    {

    }
    
    public override void ApplyEffect()
    {
        base._player.AddSpeed(3);
    }
    
}
