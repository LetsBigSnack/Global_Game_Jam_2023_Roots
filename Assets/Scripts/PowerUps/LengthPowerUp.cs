using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LengthPowerUp : PowerUps
{

    public LengthPowerUp(LevelUPManager lvlManger,  PlayerMovement player) : base(lvlManger,player)
    {
        base._name = "range";
        base._description = "Adds Length to the Square-Sword";
    }
    
    public override void ApplyEffect()
    {
        base._levelUpManager.AddLength();
    }
    
}
