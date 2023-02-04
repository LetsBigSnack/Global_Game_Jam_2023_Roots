using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUps
{
    protected LevelUPManager _levelUpManager;
    protected PlayerMovement _player { get; set; }
    private string _name;
    private string _description;
    private Image _image;

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
