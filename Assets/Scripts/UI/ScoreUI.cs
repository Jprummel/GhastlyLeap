using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreUI : MonoBehaviour {

    [SerializeField]private Text _scoreText;
	
	void Update () {
        DisplayScore();
	}

    void DisplayScore()
    {
        _scoreText.text = "Score : " + PlayerInformation.Score;
    }
}
