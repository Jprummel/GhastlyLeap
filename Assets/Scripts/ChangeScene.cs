using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class ChangeScene : MonoBehaviour {

    public void LoadScene(string sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
