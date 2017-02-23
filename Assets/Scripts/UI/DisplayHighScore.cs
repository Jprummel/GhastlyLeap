using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayHighScore : MonoBehaviour {

    private Text _highScoreText;

	void Start () {

        _highScoreText = GetComponent<Text>();
        ShowHighScore();
    }

    void ShowHighScore()
    {
        _highScoreText.text = "Highscore : " + PlayerInformation.HighScore;
    }
}
