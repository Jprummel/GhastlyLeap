using UnityEngine;
using System.Collections;

public class PlayerDeath : MonoBehaviour {

    [SerializeField]private PlayAudio _deathSound;
    private SaveLoadData _scoreSaver;
    public GameObject _gameOverPanel;

	void Start () {
        _scoreSaver = GameObject.FindGameObjectWithTag(Tags.SAVELOADOBJECT).GetComponent<SaveLoadData>();
	}

    public void GameOver()
    {
        //If the player dies and his final score is higher than the current highscore
        //Set a new highscore
        if (PlayerInformation.Score >= PlayerInformation.HighScore)
        {
            PlayerInformation.HighScore = PlayerInformation.Score;
        }
        _deathSound.PlaySound();
        _scoreSaver.SaveData();
        _gameOverPanel.SetActive(true);
    }
}
