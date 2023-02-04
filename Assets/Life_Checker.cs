using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Life_Checker : MonoBehaviour
{
    [SerializeField] PlayerMovement _player;
    float _playerHealth;
    [SerializeField] TextMeshProUGUI _text;


    // Start is called before the first frame update
    void Start()
    {
        _player = FindObjectOfType<PlayerMovement>();
        _playerHealth = _player._health;

    }

    // Update is called once per frame
    void Update()
    {
        SwitchLife();
    }

    public void SwitchLife()
    {
        _playerHealth = _player._health;

        switch (_playerHealth)
        {
            case 0:
                _text.text = "0 * 91029380912 = 0";
                break;
            case 1:
                _text.text = "1";
                break;
            case 2:
                _text.text = "1 + 1 = 2";
                break;
            case 3:
                _text.text = "4 - 1 = 3";
                break;
            case 4:
                _text.text = "2 * 2 = 4";
                break;
            case 5:
                _text.text = "6 - 1 = 5";
                break;
            case 6:
                _text.text = "3 x 2 = 6";
                break;
            case 7:
                _text.text = "(3 x 2) + 1 = 7";
                break;
            case 8:
                _text.text = "2² = 8";
                break;
            case 9:
                _text.text = "3 * 3 = 9";
                break;
            case 10:
                _text.text = " 5 * 2 = 10";
                break;
            case 11:
                _text.text = "(3 * 3) + 2 = 11";
                break;
            case 12:
                _text.text = "2 * 2 * 2 + 4 = 12";
                break;
            case 13:
                _text.text = "5 * 3 - 2 = 13";
                break;
            case 14:
                _text.text = "7 * 2 = 14";
                break;
            case 15:
                _text.text = "3 * 5 = 15";
                break;
            case 16:
                _text.text = "4 * 4 = 16";
                break;
            case 17:
                _text.text = "(5 * 2) + 7 = 17";
                break;
            case 18:
                _text.text = "6 * 3 = 18";
                break;
            case 19:
                _text.text = "5 * 4 - 1 = 19";
                break;
            case 20:
                _text.text = "5 * 4 = 20";
                break;
            case 21:
                _text.text = "7 * 3 = 21";
                break;
            case 22:
                _text.text = "6 * 4 - 2 = 22";
                break;
            case 23:
                _text.text = "5 * 4 + 3 = 23";
                break;
            case 24:
                _text.text = "8 * 3 = 24";
                break;
            case 25:
                _text.text = "5² = 25";
                break;
            case 26:
                _text.text = "5 * 5 + 1 = 26";
                break;
            case 27:
                _text.text = "3 * 9 = 27";
                break;
            case 28:
                _text.text = "7 * 4 = 28";
                break;
            case 29:
                _text.text = "7 * 4 + 1 = 29";
                break;
            case 30:
                _text.text = "5 * 6 = 30";
                break;
            case 31:
                _text.text = "5 * 6 + 1 = 31";
                break;
            case 32:
                _text.text = "8 * 4 = 32";
                break;
            case 33:
                _text.text = "4 * 9 - 3 = 33";
                break;
            case 34:
                _text.text = "7 * 5 - 1 = 34";
                break;
            case 35:
                _text.text = "5 * 7 = 35";
                break;
            case 36:
                _text.text = "6 * 6 = 36";
                break;
            case 37:
                _text.text = "6 * 6 + 1 = 37";
                break;
            case 38:
                _text.text = "4 * 10 - 2 = 38";
                break;
            case 39:
                _text.text = "13 * 3 = 39";
                break;
            case 40:
                _text.text = "2 * 20 = 40";
                break;
        }
    }
}
