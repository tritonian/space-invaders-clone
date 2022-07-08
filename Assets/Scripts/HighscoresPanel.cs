using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighscoresPanel : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject playerScorePrefab;
    public GameObject scorePanel; // holds all player scores

    public TMP_InputField nameInput;

    public SaveData saveData;

    void Start()
    {
        saveData = GetComponent<SaveData>();
        RefreshHighScores();
    }

    public void RefreshHighScores()
    {
        Highscores highscores = saveData._Highscores;

        foreach (RectTransform item in scorePanel.GetComponentsInChildren<RectTransform>())
        {
            if (item == scorePanel.GetComponent<RectTransform>()) continue;
            Destroy(item.gameObject);
        }

        if (highscores.players.Count <= 0)
        {
            Debug.Log("Empty highscores."); 
            return;
        }

        for (int i = 0; i < highscores.players.Count; i++)
        {
            Debug.Log("Number of players in high score list: " + highscores.players.Count);
            Debug.Log("Setting player: " + highscores.players[i]);
            GameObject lineItem = Instantiate(playerScorePrefab, scorePanel.transform);
            lineItem.GetComponent<PlayerHighScoreLineItem>().SetLineItem(highscores.players[i], highscores.scores[i]);
        }
    }

    public void AddHighScore()
    {
        Highscores highscores = saveData._Highscores;

        if (nameInput.text == "")
        {
            Debug.Log("They didn't type anything into the name field. Do they not want recognition?");
            nameInput.text = "AAA";
        }

        highscores.players.Add(nameInput.text);
        highscores.scores.Add(gameManager.currentScore);

        RefreshHighScores();
        saveData.SaveIntoJson();
    }
}
