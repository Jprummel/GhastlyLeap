using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {

    //Editor Values
    [SerializeField]private float       _jumpForce;         //Jump height
    [SerializeField]private GameObject  _jumpParticle;      //Particle to spawn when jumping
    [SerializeField]private Transform   _jumpParticlePos;   //Position to spawn particle at

    private Pause       _pause;     //Script to check if game if paused
    private Rect        _jumpRect;  //Clickable area to jump
    private PlayAudio   _jumpAudio; //Audio script
    private Animator    _anim;      //Gets the animator
    private Rigidbody2D _rb2D;      //Players rigidbody
    private bool        _isGrounded;//Checks if the player is grounded

    public bool IsGrounded
    {
        get { return _isGrounded; }
        set { _isGrounded = value; }
    }

	void Start () 
    {
        _pause      = GameObject.FindGameObjectWithTag(Tags.PAUSEOBJECT).GetComponent<Pause>();
        _anim       = GetComponent<Animator>();
        _jumpAudio  = GetComponent<PlayAudio>();
        _rb2D       = GetComponent<Rigidbody2D>();
        _isGrounded = true; //Makes the player able to jump at the start of the game
        _jumpRect = new Rect(0, 0, Screen.width, Screen.height * 0.90f);    //sets touchable area for jumping
	}

    void Update()
    {
        //If player clicks or taps the screen and its inside the jumpRect, let the player jump
        if (Input.GetMouseButtonDown(0) && _jumpRect.Contains(Input.mousePosition)) 
        {
            PlayerJump(); 
        }
        JumpAnimStatus(); //Checks if animation should be triggered or not
    }

    public void PlayerJump()
    {
        if (_isGrounded && !_pause.IsPaused)
        {
            _rb2D.velocity              = new Vector2(_rb2D.velocity.x, _jumpForce);    //Boosts player from the ground
            _jumpAudio.PlaySound(); //Plays jump sound
            GameObject particle         = Instantiate(_jumpParticle);   //Spawn particle
            particle.transform.position = _jumpParticlePos.position;    //Sets the particles position
        }
    }

    void JumpAnimStatus()
    {
        //Checks if the jump animation should play or not
        if (_isGrounded)
        {
            _anim.SetBool("isJumping", false);
        }
        else if(!_isGrounded)
        {
            _anim.SetBool("isJumping", true);
        }
    }
}
