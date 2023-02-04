using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{

    private Rigidbody2D _enemyRB;
    private GameObject _player;
    [SerializeField] private float _movementSpeed = 3;
    // Start is called before the first frame update
    void Start()
    {
        _player = FindObjectOfType<PlayerMovement>().gameObject;
        _enemyRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float x_Direction =  _player.transform.position.x - transform.position.x;
        float y_Direction = _player.transform.position.y - transform.position.y;
        double hypotenuse = Math.Sqrt(x_Direction * x_Direction + y_Direction * y_Direction);
        float x_Direction_normalized = (float)(x_Direction / hypotenuse);
        float y_Direction_normalized = (float)(y_Direction / hypotenuse);
        _enemyRB.velocity = new Vector2(x_Direction_normalized * _movementSpeed, y_Direction_normalized * _movementSpeed);
        
    }

    
    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.gameObject.tag);
        if (col.gameObject.tag == "sword")
        {
            Debug.Log("HIT");
            Destroy(this.gameObject);
        }
    }
}
