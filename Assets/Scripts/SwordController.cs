using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwordController : MonoBehaviour
{

    [SerializeField] private Vector2 mousePointer;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetMousePosition(InputAction.CallbackContext context)
    {
        mousePointer = context.ReadValue<Vector2>();
    }

}
