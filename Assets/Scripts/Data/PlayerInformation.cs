using UnityEngine;
using System.Collections;

public class PlayerInformation : MonoBehaviour {

    public static int Score;
    public static int HighScore;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
