using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    //Editor Value
    [SerializeField]private float _movementSpeed;

    private SpriteRenderer  _spriteRenderer;
    private Rigidbody2D     _rigidBody;
    private Vector2         _moveDir;       //The side the player will move to
    private bool            _touchedLeft;
    private bool            _touchedRight;

    public bool TouchedLeft
    {
        get { return _touchedLeft; }
        set { _touchedLeft = value; }
    }

    public bool TouchedRight
    {
        get { return _touchedRight; }
        set { _touchedRight = value; }
    }

    public float MovementSpeed
    {
        get { return _movementSpeed; }
        set { _movementSpeed = value; }
    }

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidBody      = GetComponent<Rigidbody2D>();
        _touchedLeft    = true; //Makes the player move right when the game starts
    }

    void Update()
    {
        //If left side of platform is touched, move right (1), sets sprite to face right
        //If right side of platform is touched, move left (-1), sets sprite to face left
        if (_touchedLeft)
        {
            Move(new Vector2(1,0));
            _spriteRenderer.flipX = false;
        }
        if (_touchedRight)
        {
            Move(new Vector2(-1, 0));
            _spriteRenderer.flipX = true;
        }
    }

    void Move(Vector2 moveDir)
    {
        transform.Translate(moveDir * _movementSpeed * Time.deltaTime);
    }
}
