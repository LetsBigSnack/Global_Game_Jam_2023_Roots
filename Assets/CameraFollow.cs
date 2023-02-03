using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _player;

    [SerializeField] private int _cameraZLayer = -10;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(_player.position.x, _player.position.y, _cameraZLayer);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(_player.position.x, _player.position.y, _cameraZLayer);
    }
}
