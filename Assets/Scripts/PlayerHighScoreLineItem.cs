using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerHighScoreLineItem : MonoBehaviour
{
    public TMP_Text nameText, scoreText;

    public void SetLineItem(string name, int score)
    {
        nameText.text = name;
        scoreText.text = score.ToString();
    }
}
