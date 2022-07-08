using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighscoresPanel : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject playerScorePrefab;
    public GameObject scorePanel; // holds all player scores

    void Start()
    {
        RefreshHighScores();
    }

    public void RefreshHighScores()
    {
        //gameManager.saveData._Highscores
        // display high scores in list
        // get high scores from saveData in gamemanager
        // foreach name in list, create a player score line item and set the score
        Highscores highscores = gameManager.saveData._Highscores;

        if (highscores.highScores.Count <= 0) return;

        foreach (string name in highscores.highScores.Keys)
        {
            GameObject lineItem = Instantiate(playerScorePrefab, scorePanel.transform);
            lineItem.GetComponent<PlayerHighScoreLineItem>().SetLineItem(name, highscores.highScores[name]);
        }
    }
}
