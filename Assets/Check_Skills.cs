using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Check_Skills : MonoBehaviour
{
    [SerializeField] private GameObject _atkBtn;
    [SerializeField] private GameObject _dashBtn;
    [SerializeField] private PlayerMovement _player;
    [SerializeField] private SwordController _sword;

    // Start is called before the first frame update
    void Start()
    {
        _player = FindObjectOfType<PlayerMovement>();
        _sword = FindObjectOfType<SwordController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_sword.canAttack)
        {
            _atkBtn.GetComponent<Image>().color = new Color(1, 1, 1,0.5f);
        }
        else
        {
            _atkBtn.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        }

        if (!_player.canDash)
        {
            _dashBtn.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
        } 
        else
        {
            _dashBtn.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        }


    }


}
