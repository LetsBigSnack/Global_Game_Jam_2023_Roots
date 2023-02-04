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
    [SerializeField] private GameObject _swordHead;
    [SerializeField] private GameObject _swordBody;
    [SerializeField] public int currentLength = 0;
    [SerializeField] public int maxLength = 4;
    
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
        BoxCollider2D[] childColliders = GetComponentsInChildren<BoxCollider2D>();
        foreach (var boxCollider2D in childColliders)
        {
            boxCollider2D.enabled = true;
        }
        canAttack = false;
        yield return new WaitForSeconds(_attackDuration);
        _collider2D.enabled = false;
        foreach (var boxCollider2D in childColliders)
        {
            boxCollider2D.enabled = false;
        }
        yield return new WaitForSeconds(_attackCooldown);
        canAttack = true;
    }

    public void AddLength()
    {
        if (currentLength <= maxLength)
        {
            GameObject newBody = Instantiate(_swordBody, new Vector3(_swordHead.transform.position.x, _swordHead.transform.position.y, 0),
                _swordBody.transform.rotation, transform);
            newBody.transform.Rotate(0,0,-newBody.transform.rotation.z);
            Debug.Log("Rotation: "+newBody.transform.rotation.z);
            _swordHead.transform.localPosition =
                new Vector3(_swordHead.transform.localPosition.x, _swordHead.transform.localPosition.y+1, 0);
            Debug.Log("Rotation: "+newBody.transform.rotation.z);
            currentLength++;
        }
    }
}
