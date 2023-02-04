using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelUPManager : MonoBehaviour
{
    [SerializeField] private PowerUps[] _powerUpOptions;
    
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        _powerUpOptions = new PowerUps[3];
        _powerUpOptions[0] = new SpeedPowerUp(this, FindObjectOfType<PlayerMovement>());
        _powerUpOptions[1] = new SlowPowerUp(this, FindObjectOfType<PlayerMovement>());
        _powerUpOptions[2] = new PowerUps(this, FindObjectOfType<PlayerMovement>());
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
    
}
