using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class IntroScreen : MonoBehaviour {

    [SerializeField]private string _sceneName;

	void Start () {
        StartCoroutine(GoToMenu());
	}
	
	void Update () {
        SkipIntro();
	}

    void SkipIntro()
    {
        if (Input.touchCount > 0)
        {
            SceneManager.LoadScene(_sceneName);
        }
    }

    IEnumerator GoToMenu()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(_sceneName);
    }
}
