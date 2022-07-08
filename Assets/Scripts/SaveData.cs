using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OdinSerializer;
using System.IO;

[System.Serializable]
public class Highscores
{
    //public Dictionary<string, int> highScores = new();
    public List<string> players;
    public List<int> scores;
}

public class SaveData : MonoBehaviour
{
    public Highscores _Highscores;

    private string fileLocation;

    private void Awake()
    {
        fileLocation = Application.persistentDataPath + "/highscores.json";
        ReadFromJson();
        SaveIntoJson();
    }

    public void SaveIntoJson()
    {
        //Debug.Log("Saving to JSON file");
        byte[] bytes = SerializationUtility.SerializeValue(_Highscores, DataFormat.JSON);
        File.WriteAllBytes(fileLocation, bytes);
    }

    public void ReadFromJson()
    {
        //Debug.Log("Reading from JSON file");
        if (File.Exists(fileLocation))
        {
            //Debug.Log("JSON file found.");
            byte[] bytes = File.ReadAllBytes(fileLocation);
            _Highscores = SerializationUtility.DeserializeValue<Highscores>(bytes, DataFormat.JSON);
        }
        //else Debug.Log("File does not exist.");
    }
}