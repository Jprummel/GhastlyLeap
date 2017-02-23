using UnityEngine;
using System.Collections;

public class PlayerCollisions : MonoBehaviour {

    private Movement _movement;
    private Jump _jump;

    void Awake()
    {
        _movement = GetComponent<Movement>(); //Gets movement script attached to the player
        _jump = GetComponent<Jump>();
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == Tags.LEFTBORDER)
        {
            _movement.TouchedRight = false;
            _movement.TouchedLeft = true;
        }
        if (coll.tag == Tags.RIGHTBORDER)
        {
            _movement.TouchedLeft = false;
            _movement.TouchedRight = true;
        }

        if (coll.tag == Tags.PICKUP)
        {
            IPickUp pickUp = coll.GetComponent<IPickUp>();
            pickUp.PickUp();
        }

        if (coll.tag == Tags.FLOOR)
        {
            PlayerDeath gameOver = coll.GetComponent<PlayerDeath>();
            gameOver.GameOver();
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == Tags.PLATFORM)
        {
            _jump.IsGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == Tags.PLATFORM)
        {
            _jump.IsGrounded = false;
        }
    }
}
