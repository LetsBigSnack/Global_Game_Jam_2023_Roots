using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{

    private Rigidbody2D _enemyRB;
    private GameObject _player;
    private EnemyManager manager;
    [SerializeField] private float _movementSpeed = 3;
    [SerializeField] public float _dmg;
    [SerializeField] private AudioSource _bounce;
    [SerializeField] public float _value;
    [SerializeField] public Counter _counter;
    [SerializeField] private GameObject spawnedEnemy;
    [SerializeField] private GameObject explosion;
    [SerializeField] private int invincibilityFrame = 5;
    [SerializeField] private int currentinvincibilityFrame = 0;
    [SerializeField] private bool isInvincible = true;
    [SerializeField] private GameObject exp;

    [SerializeField] private bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        _counter = FindObjectOfType<Counter>();
        _player = FindObjectOfType<PlayerMovement>().gameObject;
        _enemyRB = GetComponent<Rigidbody2D>();
        manager = FindObjectOfType<EnemyManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.enabled)
        {
            float x_Direction =  _player.transform.position.x - transform.position.x;
            float y_Direction = _player.transform.position.y - transform.position.y;
            double hypotenuse = Math.Sqrt(x_Direction * x_Direction + y_Direction * y_Direction);
            float x_Direction_normalized = (float)(x_Direction / hypotenuse);
            float y_Direction_normalized = (float)(y_Direction / hypotenuse);
            _enemyRB.velocity = new Vector2(x_Direction_normalized * _movementSpeed * manager.speedDebuff, y_Direction_normalized * _movementSpeed * manager.speedDebuff);
        }
        else
        {
            _enemyRB.velocity = new Vector2();
        }
    }

    private void FixedUpdate()
    {
        if (currentinvincibilityFrame >= invincibilityFrame && isInvincible)
        {
            isInvincible = false;
        }else if (currentinvincibilityFrame < invincibilityFrame)
        {
            currentinvincibilityFrame++;
        }
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "sword" && !isInvincible)
        {
            if (!isDead)
            {
                _counter._points.RuntimeValue += _value;
                _counter._enemies.RuntimeValue += 1;
                GameObject newExplosion = Instantiate(explosion, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
                isDead = true;
                if (spawnedEnemy)
                {
                
                    float x_Direction =  _player.transform.position.x - transform.position.x;
                    float y_Direction = _player.transform.position.y - transform.position.y;
                    double hypotenuse = Math.Sqrt(x_Direction * x_Direction + y_Direction * y_Direction);
                    float x_Direction_normalized = (float)(x_Direction / hypotenuse);
                    float y_Direction_normalized = (float)(y_Direction / hypotenuse);
                
                    GameObject newEnemy1 = Instantiate(spawnedEnemy, new Vector3(transform.position.x-x_Direction_normalized*2, transform.position.y, 0), Quaternion.identity);
                    GameObject newEnemy2 = Instantiate(spawnedEnemy, new Vector3(transform.position.x, transform.position.y-y_Direction_normalized*2, 0), Quaternion.identity);
                }
                GameObject exp1 = Instantiate(exp, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
                exp1.GetComponent<FollowPlayer>().value = (int) _dmg;
                Destroy(this.gameObject);
            }
            
        }
    }

    public void Bounce()
    {
        if (_bounce)
        {
            _bounce.Play();
        }
    }
    private void OnDisable()
    {
        try
        {
            _enemyRB.velocity = new Vector2();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }
}
