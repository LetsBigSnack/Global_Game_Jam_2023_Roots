using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LengthPowerUp : PowerUps
{

    public LengthPowerUp(LevelUPManager lvlManger,  PlayerMovement player) : base(lvlManger,player)
    {

    }
    
    public override void ApplyEffect()
    {
        base._levelUpManager.AddLength();
    }
    
}
