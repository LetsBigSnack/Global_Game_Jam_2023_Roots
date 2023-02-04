using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class XpPowerUp : PowerUps
{

    public XpPowerUp(LevelUPManager lvlManger,  PlayerMovement player) : base(lvlManger,player)
    {

    }
    
    public override void ApplyEffect()
    {
        base._player.AddXpBonus();
    }
    
}
