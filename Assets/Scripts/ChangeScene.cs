using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] string _sceneName;
    [SerializeField] private Counter _counter;

    // Start is called before the first frame update
    void Start()
    {
        _counter = FindObjectOfType<Counter>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeScene()
    {
        _counter.saveTime();
        SceneManager.LoadScene(_sceneName);
    }
}
