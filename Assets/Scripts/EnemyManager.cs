using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private float _spawnRadius = 10f;
    [SerializeField] private float _spawningRate = 1f;
    private GameObject _player;
    
    // Start is called before the first frame update
    void Start()
    {
        _player = FindObjectOfType<PlayerMovement>().gameObject;
        GetPointOnRadius();
        StartCoroutine(SpawnEnemy(_spawningRate, _enemyPrefab));
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
        //TODO check if enemy can be spawned
        // Reduce Interval
        yield return new WaitForSeconds(interval);
        Vector2 newPosition = GetPointOnRadius();
        GameObject newEnemy = Instantiate(enemy, new Vector3(newPosition.x, newPosition.y, 0), Quaternion.identity);
        StartCoroutine(SpawnEnemy(_spawningRate, _enemyPrefab));
    }
}
