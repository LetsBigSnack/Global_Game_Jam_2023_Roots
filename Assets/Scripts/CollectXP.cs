using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectXP : MonoBehaviour
{
    private PlayerMovement _player;
    private void Start()
    {
        _player = FindObjectOfType<PlayerMovement>();
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "exp")
        {
            _player.collectXP(col.gameObject.GetComponent<FollowPlayer>().value);
            Destroy(col.gameObject);
        }
    }
}
