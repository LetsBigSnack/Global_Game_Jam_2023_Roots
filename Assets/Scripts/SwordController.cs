using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwordController : MonoBehaviour
{
    [SerializeField] private Transform pivot;
    [SerializeField] private Vector2 mousePosition;
    [SerializeField] private float radius = 1.5f;
    [SerializeField] private Transform center;
    [SerializeField] private Camera cam;
    
    [SerializeField] private BoxCollider2D _collider2D;

    [SerializeField] private bool canAttack = true;
    [SerializeField] private float _attackDuration = 0.3f;
    [SerializeField] private float _attackCooldown = 0.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        center = pivot.transform;
        transform.parent = pivot;
        transform.position += Vector3.up * radius;
        _collider2D = GetComponent<BoxCollider2D>();
        _collider2D.enabled = false;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 newVector = cam.WorldToScreenPoint(pivot.position);
        newVector = new Vector3(mousePosition.x, mousePosition.y, 0) - newVector;
        float angle = Mathf.Atan2(newVector.y, newVector.x) * Mathf.Rad2Deg;
 
        //center.position = pivot.position;
        center.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

    }

    public void GetMousePosition(InputAction.CallbackContext context)
    {
        mousePosition = context.ReadValue<Vector2>();
    }

    
    public void ActivateAttack(InputAction.CallbackContext context)
    {
        if (context.performed && canAttack)
        {
            StartCoroutine(Attack());
        }
    }

    
    private IEnumerator Attack()
    {
        _collider2D.enabled = true;
        canAttack = false;
        yield return new WaitForSeconds(_attackDuration);
        _collider2D.enabled = false;
        yield return new WaitForSeconds(_attackCooldown);
        canAttack = true;
    }
    
}
