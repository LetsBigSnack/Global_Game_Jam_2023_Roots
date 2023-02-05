using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FollowPlayer : MonoBehaviour
{
    private PlayerMovement _player;
    private bool searchingPlayer;
    private void Start()
    {
        _player = FindObjectOfType<PlayerMovement>();
        searchingPlayer = false;
        StartCoroutine(waitToFollow());
    }
    
    public IEnumerator waitToFollow()
    {
        yield return new WaitForSeconds(1f);
        searchingPlayer = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (searchingPlayer)
        {
           /**
            *  float x_Direction =  _player.transform.position.x - transform.position.x;
            float y_Direction = _player.transform.position.y - transform.position.y;
            double hypotenuse = Math.Sqrt(x_Direction * x_Direction + y_Direction * y_Direction);
            float x_Direction_normalized = (float)(x_Direction / hypotenuse);
            float y_Direction_normalized = (float)(y_Direction / hypotenuse);
            transform.position += new Vector3( x_Direction_normalized * 1 * Time.deltaTime, 
                transform.position.x + y_Direction_normalized * 1 * Time.deltaTime, 0);
            */
        }
        
    }
}
