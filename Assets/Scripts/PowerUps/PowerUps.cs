using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUps
{
    public LevelUPManager _levelUpManager;
    public PlayerMovement _player { get; set; }
    public string _name;
    public string _description;
    
    public PowerUps(LevelUPManager lvlUPManger, PlayerMovement player)
    {
        _levelUpManager = lvlUPManger;
        _player = player;
    }
    
    public void OnSelect()
    {
        ApplyEffect();
        _levelUpManager.CloseLevelUp();
        
    }

    public virtual void ApplyEffect()
    {
        
    }
    
}
