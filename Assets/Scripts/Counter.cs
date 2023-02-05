using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Counter : MonoBehaviour
{
    [SerializeField] public FloatValues _points;
    [SerializeField] public TextMeshProUGUI points = null;
    [SerializeField] public FloatValues _level;
    [SerializeField] public TextMeshProUGUI lvl = null;
    [SerializeField] public FloatValues _enemies;
    [SerializeField] public TextMeshProUGUI enemies = null;
    [SerializeField] public FloatValues _wave;
    [SerializeField] public TextMeshProUGUI wave = null;
    [SerializeField] public FloatValues _finishedTime;
    [SerializeField] public FloatValues _saved;
    [SerializeField] public TextMeshProUGUI time = null;
    [SerializeField] public TextMeshProUGUI grade = null;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_saved.RuntimeValue != 1)
        {
            _finishedTime.RuntimeValue += Time.deltaTime;
        }
        if (points != null)
        {
            points.text = _points.RuntimeValue.ToString();
        }
        if (lvl != null)
        {
            lvl.text = _level.RuntimeValue.ToString();
        }
        if (enemies != null)
        {
            enemies.text = _enemies.RuntimeValue.ToString();
        }
        if (wave != null)
        {
            wave.text = _wave.RuntimeValue.ToString();
        }
        if (time != null)
        {
            time.text = _finishedTime.RuntimeValue.ToString("F2");
        }
        if (grade != null)
        {
            getGraded();
        }
    }

    public void getGraded()
    {
        switch (_points.RuntimeValue)
        {
            case  <= 500:
                grade.text = "F";;
                break;
            case <= 1000f:
                grade.text = "D";
                break;
            case <= 1500f:
                grade.text = "C";
                break;
            case <= 2000:
                grade.text = "B";
                break;
            case <= 2500:
                grade.text = "A";
                break;
            case > 2500:
                grade.text = "S";
                break;
        }
    }

    public void saveTime()
    {
        _saved.RuntimeValue = 1;
    }

}
