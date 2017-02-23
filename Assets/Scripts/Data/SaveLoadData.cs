using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveLoadData : MonoBehaviour {

    void Awake()
    {
        //DontDestroyOnLoad(this.gameObject);
        LoadData();
    }

    public void SaveData()
    {
        BinaryFormatter bf      = new BinaryFormatter();
        FileStream file         = File.Create(Application.persistentDataPath + "/SaveData.dat");
        SaveData saveData       = new SaveData();
        saveData.Highscore      = PlayerInformation.HighScore;
        saveData.MusicVolume    = AudioData.MusicVolume;
        saveData.SFXVolume      = AudioData.SFXVolume;
        bf.Serialize(file, saveData);
        file.Close();
    }

    public void LoadData()
    {
        if (File.Exists(Application.persistentDataPath + "/SaveData.dat"))
        {
            BinaryFormatter bf          = new BinaryFormatter();
            FileStream file             = File.Open(Application.persistentDataPath + "/SaveData.dat", FileMode.Open);
            SaveData saveData           = (SaveData)bf.Deserialize(file);
            PlayerInformation.HighScore = saveData.Highscore;
            AudioData.MusicVolume       = saveData.MusicVolume;
            AudioData.SFXVolume         = saveData.SFXVolume;
            file.Close();
        }
    }
}

[System.Serializable]
public class SaveData
{
    public int Highscore;
    public float MusicVolume;
    public float SFXVolume;
}
