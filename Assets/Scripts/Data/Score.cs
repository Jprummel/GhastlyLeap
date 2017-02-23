using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

    [SerializeField]private Transform _player;
    [SerializeField]private Transform _startPoint;

    void Update()
    {
        ChangeScore();
    }

    void ChangeScore()
    {
        //If the player isnt null (not dead), calculate distance between starting point and player and convert that to score
        //If the score is higher then the highscore, update the highscore
        if (_player != null)
        {
            Vector2 difference = _player.position - _startPoint.position;
            float DifferenceY = Mathf.Abs(difference.y);
            PlayerInformation.Score = (int)DifferenceY;
        }
    }
}
