using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {
    
    [SerializeField]private GameObject _pausePanel;
    private bool _isPaused;

    public bool IsPaused
    {
        get { return _isPaused; }
        set { _isPaused = value; }
    }

    void Update()
    {
        PauseGame();
    }

    public void PauseGame()
    {
        if (_isPaused)
        {
            Time.timeScale = 0;
            _pausePanel.SetActive(true);
        }
        else if (!_isPaused)
        {
            Time.timeScale = 1;
            _pausePanel.SetActive(false);
        }
    }

    public void TogglePause()
    {
        if (_isPaused)
        {
            _isPaused = false;
        }
        else if (!_isPaused)
        {
            _isPaused = true;
        }
    }
}
