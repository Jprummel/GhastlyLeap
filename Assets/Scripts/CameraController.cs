using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    [SerializeField]private Transform   _player;
    private float       _upSpeed;

	void Update () 
    {
        AutomaticCameraUp();
	}

    void AutomaticCameraUp()
    {
        //This function makes the camera go up automatically
        //If the player is higher up in the screen the camera will move faster
        if (_player != null)
        {
            if (_player.position.y >= transform.position.y * 1.2f)
            {
                _upSpeed = 2;
            }
            else if (_player.position.y >= transform.position.y)
            {
                _upSpeed = 1.5f;
            }
            else if (_player.position.y <= transform.position.y)
            {
                _upSpeed = 0.8f;
            }
        }
        transform.position = new Vector3(transform.position.x, transform.position.y + _upSpeed * Time.deltaTime, transform.position.z);
    }
}
