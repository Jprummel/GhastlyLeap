using UnityEngine;
using System.Collections;

public class Knight : MonoBehaviour, IPickUp {

    [SerializeField]private float _boostForce;
    private Rigidbody2D _playerRB;
    private GameObject _player;

    void Start()
    {
        _player     = GameObject.FindGameObjectWithTag(Tags.PLAYER);
        if (_player != null)
        {
            _playerRB = _player.GetComponent<Rigidbody2D>();
        }
    }

    public void PickUp()
    {
        StartCoroutine(Boost());
    }

    IEnumerator Boost()
    {
        Movement playerSpeed        = _player.GetComponent<Movement>();                 //Gets movement script attached to player
        float defaultSpeed          = 1.45f;                                            //Stores the players normal movement speed
        _playerRB.velocity          = new Vector2(_playerRB.velocity.x, _boostForce);   //Boosts player up
        playerSpeed.MovementSpeed   = 0;                                                //Makes sure the player wont move sidewards during the boost
        yield return new WaitForSeconds(1.5f);                                          //Wait 1.5 seconds
        playerSpeed.MovementSpeed   = defaultSpeed;                                     //Restores the players movement speed
    }
}
