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
    
    // Start is called before the first frame update
    void Start()
    {
        _player = FindObjectOfType<PlayerMovement>().gameObject;
    }

    private void Update()
    {
        if (!currentlySpawning)
        {
            Debug.Log("VAR");
            currentlySpawning = true;
            _spawning = StartCoroutine(SpawnEnemy(_spawningRate, _enemyPrefab));
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
    
    private IEnumerator SpawnEnemy(float interval, GameObject enemy)
    {
        if (!enabled)
        {
            StopAllCoroutines();
        }
        else
        { 
            yield return new WaitForSeconds(interval);
            Vector2 newPosition = GetPointOnRadius();
            Collider2D[] collisionOnNewPoint = Physics2D.OverlapCircleAll(newPosition, _overlapRadius);
            if (collisionOnNewPoint.Length <= 0)
            {
                if (enabled)
                {
                    GameObject newEnemy = Instantiate(enemy, new Vector3(newPosition.x, newPosition.y, 0), Quaternion.identity);
                }
            }
            StartCoroutine(SpawnEnemy(_spawningRate, _enemyPrefab));
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
