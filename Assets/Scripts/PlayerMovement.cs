using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRB;
    [SerializeField] private float _normalSpeed = 8f;
    [SerializeField] private float _playerSpeed;

    [SerializeField] private Vector2 moveVector;

    [SerializeField] private Animator _playerAnim;
    [SerializeField] private SpriteRenderer _playerSprite;
    [SerializeField] public float _health = 40;
    [SerializeField] public float _maxHealth = 40;

    [SerializeField] public Collider2D _hitBox;
    [SerializeField] private Coroutine _invinc;
    [SerializeField] private bool _invincible; 
    [SerializeField] private Coroutine _flash;
    [SerializeField] private Material _standard;
    [SerializeField] private Material _hurt;

    [Header("Dash")] 
    [SerializeField] private bool canDash = true;
    [SerializeField] private bool isDashing;
    [SerializeField] private float dashingSpeed = 32f;
    [SerializeField] private float dashingTime = 0.3f;
    [SerializeField] private float dashingCooldown = 1f;

    [Header("Exp")] 
    [SerializeField] private int currentLevel = 1;
    [SerializeField] private int levelThreshold = (int) Math.Round((float)(4 * (1*1*1)) / 5);
    [SerializeField] private float currentXP = 0;
    [SerializeField] private float xpMultiplicator = 1f;

    [SerializeField] private GameObject _auroStar;
    
    [Header("UI")] 
    [SerializeField] private LevelUPManager _levelUpManager;
    
    private void Start()
    {
        _health = _maxHealth;
        _playerAnim = GetComponent<Animator>();
        _playerSprite = GetComponent<SpriteRenderer>();
        _playerSpeed = _normalSpeed;
        currentLevel = 1;
        levelThreshold = (int) Math.Round((float)(4 * (1*1*1)) / 5);
        _levelUpManager = Resources.FindObjectsOfTypeAll<LevelUPManager>()[0];
        
    }


    void Update()
    {
        Debug.Log("Update");
        playerRB.velocity = new Vector2(moveVector.x * _playerSpeed, moveVector.y * _playerSpeed);
        SetDirectionValues();
    }

    public void MovePlayer(InputAction.CallbackContext context)
    {   
        moveVector = context.ReadValue<Vector2>();
    }

    public void ActivateDash(InputAction.CallbackContext context)
    {
        //TODO Fix Action while other movement is currently pressed 
        if (context.performed && canDash)
        {
            StartCoroutine(Dash());
        }
    }

    public void SetDirectionValues()
    {
        _playerAnim.SetFloat("moveVector.x", moveVector.x);
        _playerAnim.SetFloat("moveVector.y", moveVector.y);
    }


    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        _playerSpeed = dashingSpeed;
        yield return new WaitForSeconds(dashingTime);
        isDashing = false;
        _playerSpeed = _normalSpeed;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

    public void collectXP()
    {
        currentXP += 1*xpMultiplicator;
        if (currentXP >= levelThreshold)
        {
            currentLevel++;
            currentXP = 0;
            enabled = false;
            levelThreshold = CalculateNextThreshold(currentLevel);
            Debug.Log("LEVEL UP: " + currentLevel);
            _levelUpManager.ShowLevelUp();
        }
    }

    private int CalculateNextThreshold(int level)
    {
        return (int) Math.Round((float)(4 * (level*level*level)) / 5);
    }

    private void OnDisable()
    {
        Debug.Log("Player Disabled");
        playerRB.velocity = new Vector2();
        //TODO on enable invc. / shock wave enemy
    }

    public void AddSpeed(int speed)
    {
        Debug.Log("I am SPEED");
        _playerSpeed += speed;
        _normalSpeed += speed;
        dashingSpeed += speed;
    }

    public void AddXpBonus()
    { 
        Debug.Log("I am XP");
        xpMultiplicator *= 1.25f;
        
    }

    public void OnTriggerEnter2D(Collider2D other) {

        if(other.gameObject.tag == "enemy" && _invincible == false)
        {
            //add a boolean to check if the whole DMG is possible -> otherwise u might not get dmg, but the flashing would start. Fixed that.
            _invincible = true;
            _health -= other.gameObject.GetComponent<EnemyBehaviour>()._dmg;
            if (_invinc != null)
            {
                StopCoroutine(_invinc);
            }
            _invinc = StartCoroutine(invincibility());

            //starting a flash routine for feedback to the player
            if (_flash != null)
            {
                StopCoroutine(_flash);
            }
            _flash = StartCoroutine(hurt());

            //destroying the playerObject on health 0
            if(_health <= 0)
            {
                Destroy(gameObject);
            }
        }
    
    
    }

    public void AddHealth(float health)
    {
        _health += health;
        _maxHealth += health;
    }

    public void AddAura()
    {
        GameObject newStar = Instantiate(_auroStar, playerRB.position, Quaternion.identity, playerRB.transform);
    }

    public IEnumerator invincibility()
    {
        _hitBox.enabled = false;
        yield return new WaitForSeconds(1);
        _hitBox.enabled = true;
        //changes the boolean back so dmg is possible
        _invincible = false;

    }

    public IEnumerator hurt()
    {
        //add two different types of materials to show somekind of flashing

        _playerSprite.material =  _hurt;
        yield return new WaitForSeconds(0.1f);
        _playerSprite.material =  _standard;
        yield return new WaitForSeconds(0.1f);
        _playerSprite.material =  _hurt;
        yield return new WaitForSeconds(0.1f);
        _playerSprite.material =  _standard;
        yield return new WaitForSeconds(0.1f);
        _playerSprite.material =  _hurt;
        yield return new WaitForSeconds(0.1f);
        _playerSprite.material = _standard;
    }

}
