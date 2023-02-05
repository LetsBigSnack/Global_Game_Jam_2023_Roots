using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    [SerializeField] private PlayerMovement _player;
    // Start is called before the first frame update
    void Start()
    {
        _player = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "enemy" && _player._invincible == false)
        {
            //add a boolean to check if the whole DMG is possible -> otherwise u might not get dmg, but the flashing would start. Fixed that.
           _player._invincible = true;
            _player._health -= other.gameObject.GetComponent<EnemyBehaviour>()._dmg;
            if (_player._invinc != null)
            {
                StopCoroutine(_player._invinc);
            }
            _player._invinc = StartCoroutine(_player.invincibility());

            //starting a flash routine for feedback to the player
            if (_player._flash != null)
            {
                StopCoroutine(_player._flash);
            }
            _player._flash = StartCoroutine(_player.hurt());

            //destroying the playerObject on health 0
            if (_player._health <= 0)
            {
                Destroy(gameObject);
            }
        }


    }
}
