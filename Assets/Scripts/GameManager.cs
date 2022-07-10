using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // game settings (these are private so that we know other scripts aren't getting access to them. SerialzieField makes it show up in inspector)
    [SerializeField] private int startingNumLives;
    [SerializeField] private float specialEnemySpawnRate;
    [SerializeField] private float lifeSpriteOffset = 70f;

    // object references (need to be setup before starting scene)
    [SerializeField] private GameObject lifeSpritePrefab;
    [SerializeField] private Transform lifeSpriteTextGameObject; // the parent object that the life sprites will be placed under in the heirarchy
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private GameObject enemyParent;
    [SerializeField] private GameObject GameOverCanvas;
    [SerializeField] private TMP_Text finalScoreText;

    // internal private references
    private List<GameObject> lifeSprites;
    public int currentScore;
    private int lives; // current number of lives - as opposed to number you start with
    private int levelNumber;

    private void Start()
    {       
        InitializeLives();
        currentScore = 0;
        UpdateScore();
        levelNumber = 1;
    }

    // instantiate lives parametrically based on number of lives and distance between them
    private void InitializeLives()
    {
        lifeSprites = new List<GameObject>(startingNumLives);

        for (int i = 0; i < startingNumLives; i++)
        {
            RectTransform rectTransform = Instantiate(lifeSpritePrefab, lifeSpriteTextGameObject).GetComponent<RectTransform>();
            // place first life at (150, 37.5) (relative to parent), each subsequent one some units further right
            rectTransform.localPosition = new Vector3(140f + i * lifeSpriteOffset, 37.5f, 0f);

            lifeSprites.Add(rectTransform.gameObject); // add to list of lifeSprite game objects
        }

        lives = startingNumLives;
    }

    public void GameOver()
    {
        Debug.Log("Game manager game over.");
        finalScoreText.text = currentScore.ToString();
        GameOverCanvas.SetActive(true);
        // freeze projectiles, enemies, don't allow movement/shooting?
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Start_Menu");
    }

    public void NextLevel()
    {
        levelNumber += 1;
        Instantiate(enemyParent);
    }

    public void LostLife()
    {
        
        if (lives <= 1)
        {
            Destroy(lifeSprites[lifeSprites.Count - 1]);
            lifeSprites.Remove(lifeSprites[lifeSprites.Count - 1]);
            GameOver();
            return;
        }

        // get last life sprite in line and destroy it
        Destroy(lifeSprites[lifeSprites.Count - 1]);
        lifeSprites.Remove(lifeSprites[lifeSprites.Count - 1]);
        
        lives -= 1;

        // maybe clear projectiles on the screen?
    }

    // called by enemy when killed
    public void KilledEnemy()
    {
        currentScore += 10 * levelNumber;
        UpdateScore();
    }

    private void UpdateScore()
    {
        scoreText.text = "Score: " + currentScore;
    }

    // called by special enemy when killed
    public void KilledSpecialEnemy()
    {
        currentScore += 50 * levelNumber;
        UpdateScore();
    }
}
