using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AuraController : MonoBehaviour
{
    [SerializeField] private Transform pivot;
    [SerializeField] private float radius = 1.5f;
    [SerializeField] private Transform center;
    [SerializeField] private BoxCollider2D _collider2D;
    [SerializeField] private float angleDegree = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        center = pivot.transform;
        transform.parent = pivot;
        transform.position += Vector3.up * radius;
        _collider2D = GetComponent<BoxCollider2D>();
        _collider2D.enabled = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        float angle = angleDegree  * Mathf.Rad2Deg;
        
        angleDegree += 0.05f;
        
        //center.position = pivot.position;
        center.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

    }

    
    
}
