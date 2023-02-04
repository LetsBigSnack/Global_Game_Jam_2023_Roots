using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelUPManager : MonoBehaviour
{
    public PowerUps[] _powerUpOptions;
    public List<PowerUps> _allAvailablePowerUps;
    
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
        SwordController sc = FindObjectOfType<SwordController>();
        if (sc.currentLength >= sc.maxLength)
        {
            var itemToRemove = _allAvailablePowerUps.Single(r => r.GetType() == typeof(LengthPowerUp));
            _allAvailablePowerUps.Remove(itemToRemove);
        }
        
        System.Random rnd = new System.Random();
        _allAvailablePowerUps = _allAvailablePowerUps.OrderBy(x => rnd.Next()).Take(3).ToList();

        _powerUpOptions[0] = _allAvailablePowerUps[0];
        _powerUpOptions[1] = _allAvailablePowerUps[1];
        _powerUpOptions[2] = _allAvailablePowerUps[2];
    }
    
    public void ShowLevelUp()
    {
        //Pause Game
        disableAllEntities();
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
        ShuffelOptions();
        enableAllEntities();
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
            enemyBehaviour.enabled = false;
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
