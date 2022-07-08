using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    public Highscores _Highscores = new();

    private void Awake()
    {
        ReadFromJson();
    }

    public void SaveIntoJson()
    {
        // create string with the current dictionary value on this class
        string savedScores = JsonUtility.ToJson(_Highscores);
        System.IO.File.WriteAllText(Application.persistentDataPath + "/highscores.json", savedScores);
    }

    public void ReadFromJson()
    {
        // get json string saved on system
        string jsonString = System.IO.File.ReadAllText(Application.persistentDataPath + "/highscores.json");
        // transfer from json to highscore data saved in this class
        _Highscores = JsonUtility.FromJson<Highscores>(jsonString);
    }
}

[System.Serializable]
public class Highscores
{
    public Dictionary<string, int> highScores = new();
}
