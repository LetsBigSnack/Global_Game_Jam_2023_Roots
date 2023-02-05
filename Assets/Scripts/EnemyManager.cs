using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] public float speedDebuff = 1;
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private float _spawnRadius = 10f;
    [SerializeField] private float _spawningRate = 1f;
    [SerializeField] private float _overlapRadius = 0.5f;
    private GameObject _player;
    [SerializeField] private bool currentlySpawning = false;
    [SerializeField] private Coroutine _spawning;

    [SerializeField] public int wave = 1;
    [SerializeField] public FloatValues waves;
    
    [SerializeField] private GameObject[] _easyEnemies;
    [SerializeField] private GameObject[] _mediumEnemies;
    [SerializeField] private GameObject[] _hardEnemies;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private GameObject[] _currentEnemies;

    private GameObject _mapContent;
    
    // Start is called before the first frame update
    void Start()
    {
        _player = FindObjectOfType<PlayerMovement>().gameObject;
        _mapContent = FindObjectOfType<MapContent>().gameObject;
    }

    private void Update()
    {
        if (!currentlySpawning)
        {
            wave = _player.GetComponent<PlayerMovement>().currentLevel;
            
            _spawningRate *= 0.95f;
            
            waves.RuntimeValue = wave;
            
            if (wave > 8)
            {
                _currentEnemies = _hardEnemies;
            }else if (wave > 4)
            {
                _currentEnemies = _mediumEnemies;
            }
            else
            {
                _currentEnemies = _easyEnemies;
            }
            
            currentlySpawning = true;
            _spawning = StartCoroutine(SpawnEnemy(_spawningRate, _currentEnemies));
            
        }
    }
    
    private Vector2 GetPointOnRadius()
    {
        System.Random rng = new System.Random();
        float randomAngel = (float) Math.PI * rng.Next(0, 360) / 180;

        float x_position = (float)(_spawnRadius * Math.Cos(randomAngel));
        float y_position = (float)(_spawnRadius * Math.Sin(randomAngel));
        
        return new Vector2(_player.transform.position.x + x_position, _player.transform.position.y + y_position);
    }
    
    private IEnumerator SpawnEnemy(float interval, GameObject[] enemies)
    {
        System.Random random = new System.Random();
        int rngIndex = random.Next(0, enemies.Length);
        GameObject enemy = enemies[rngIndex];
        if (!enabled)
        {
            StopAllCoroutines();
        }
        else
        { 
            yield return new WaitForSeconds(interval);
            Vector2 newPosition = GetPointOnRadius();
            Collider2D[] collisionOnNewPoint = Physics2D.OverlapCircleAll(newPosition, _overlapRadius, _layerMask);
            
            
            
            bool isInsideMap = _mapContent.GetComponent<Collider2D>().bounds.Contains(new Vector3(newPosition.x, newPosition.y, 10));
            
            if (collisionOnNewPoint.Length <= 0 && isInsideMap)
            {
                if (enabled)
                {
                    GameObject newEnemy = Instantiate(enemy, new Vector3(newPosition.x, newPosition.y, 0), Quaternion.identity);
                }
            }
            StartCoroutine(SpawnEnemy(_spawningRate, _currentEnemies));
        }
    }

    private void OnDisable()
    {
        currentlySpawning = false;
    }

    public void SlowDown()
    {
        Debug.Log("I am Slow");
        speedDebuff *= 0.9f;
    }
}
