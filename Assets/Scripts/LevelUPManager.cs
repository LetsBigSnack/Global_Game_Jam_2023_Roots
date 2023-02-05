using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class LevelUPManager : MonoBehaviour
{
    public PowerUps[] _powerUpOptions;
    public List<PowerUps> _allAvailablePowerUps;
    public List<ImageInfo> images;
    public FloatValues _currentLevel;

    public GameObject option1;
    public GameObject option2;
    public GameObject option3;

    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;
    public TextMeshProUGUI text3;
    
    // Start is called before the first frame update
    void Start()
    {
        _allAvailablePowerUps = new List<PowerUps>();
        _allAvailablePowerUps.Add(new SpeedPowerUp(this, FindObjectOfType<PlayerMovement>()));
        _allAvailablePowerUps.Add(new SlowPowerUp(this, FindObjectOfType<PlayerMovement>()));
        _allAvailablePowerUps.Add(new HealthPowerUp(this, FindObjectOfType<PlayerMovement>()));
        _allAvailablePowerUps.Add(new AuraPowerUp(this, FindObjectOfType<PlayerMovement>()));
        _allAvailablePowerUps.Add(new LengthPowerUp(this, FindObjectOfType<PlayerMovement>()));
        _allAvailablePowerUps.Add(new XpPowerUp(this, FindObjectOfType<PlayerMovement>()));
        
        gameObject.SetActive(false);
        _powerUpOptions = new PowerUps[3];
        ShuffelOptions();
    }

    private void ShuffelOptions()
    {
        List<int> choices = new List<int>();
        bool finisehdGenerating = false;
        System.Random rnG = new System.Random();
        while (!finisehdGenerating)
        {
            int tempNumber = rnG.Next(0, _allAvailablePowerUps.Count);
            if (!choices.Contains(tempNumber))
            {
                choices.Add(tempNumber);
                if (choices.Count == 3)
                {
                    finisehdGenerating = true;
                }
            }
        }
        
        _powerUpOptions[0] = _allAvailablePowerUps[choices[0]];
        _powerUpOptions[1] = _allAvailablePowerUps[choices[1]];
        _powerUpOptions[2] = _allAvailablePowerUps[choices[2]];
    }
    
    public void ShowLevelUp()
    {
        //Pause Game
        Time.timeScale = 0;
        disableAllEntities();
        option1.GetComponent<RawImage>().texture = images.Where(c => c.name == _powerUpOptions[0]._name).Single().value;
        text1.text = _powerUpOptions[0]._description;
        option2.GetComponent<RawImage>().texture = images.Where(c => c.name == _powerUpOptions[1]._name).Single().value;
        text2.text = _powerUpOptions[1]._description;
        option3.GetComponent<RawImage>().texture = images.Where(c => c.name == _powerUpOptions[2]._name).Single().value;
        text3.text = _powerUpOptions[2]._description;
        // Create 3 Options
        gameObject.SetActive(true);
    }

    public void SelectOption1()
    {
        _powerUpOptions[0].OnSelect();
    }
    
    public void SelectOption2()
    {
        _powerUpOptions[1].OnSelect();
    }
    
    public void SelectOption3()
    {
        _powerUpOptions[2].OnSelect();
    }
    

    public void CloseLevelUp()
    {
        _currentLevel.RuntimeValue += 1;
        ShuffelOptions();
        enableAllEntities();
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }

    public void disableAllEntities()
    {
        Debug.Log("Disable");
        EnemyBehaviour[] allEnemies = FindObjectsOfType<EnemyBehaviour>();
        
        EnemyManager spawner = FindObjectOfType<EnemyManager>();
        spawner.enabled = false;

        PlayerMovement player = FindObjectOfType<PlayerMovement>();
        player.enabled = false;

        foreach (EnemyBehaviour enemyBehaviour in allEnemies)
        {
            try
            {
                enemyBehaviour.enabled = false;
            }
            catch (Exception e)
            {
                
            }
            
        }
        
    }
    
    public void enableAllEntities()
    {
        Debug.Log("Enable");
        EnemyBehaviour[] allEnemies = FindObjectsOfType<EnemyBehaviour>();
        
        EnemyManager spawner = FindObjectOfType<EnemyManager>();
        spawner.enabled = true;

        PlayerMovement player = FindObjectOfType<PlayerMovement>();
        player.enabled = true;

        foreach (EnemyBehaviour enemyBehaviour in allEnemies)
        {
            enemyBehaviour.enabled = true;
        }
        
    }

    public void SlowDownEnemies()
    {
        EnemyManager spawner = FindObjectOfType<EnemyManager>();
        spawner.SlowDown();
    }

    public void AddLength()
    {
        SwordController sword = FindObjectOfType<SwordController>();
        sword.AddLength();
    }
    
}
