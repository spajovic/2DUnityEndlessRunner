using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePlayManager : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOver;
    private Text scoreText,highScoreText,livesText,gameOverText;
    [HideInInspector]
    public  static GamePlayManager instance;
    public int lives, score;
    // Start is called before the first frame update
    [SerializeField]
    public GameObject pausePanel;
    void Awake()
    {
        MakeInstance();
        scoreText = GameObject.Find("Score").GetComponent<Text>();
        highScoreText = GameObject.Find("HighScore").GetComponent<Text>();
        livesText = GameObject.Find("Lives").GetComponent<Text>();
        gameOverText = GameObject.Find("Score Text").GetComponent<Text>();
        lives = 3;
        gameOver.SetActive(false);
        GameManagerScript.Instance.highscore = PlayerPrefs.GetInt("highscore");
        pausePanel.SetActive(false);
        
    }
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoadedEvent;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoadedEvent;

    }
    void MakeInstance()
    {
        if(instance == null)
        {
            instance = this;
        }
    }


    void OnSceneLoadedEvent(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "MainScene")
        {
            if (GameManagerScript.Instance.GameStartedFromMainMenu)
            {
                GameManagerScript.Instance.GameStartedFromMainMenu = false;
                lives = 3;
                score = 0;
            }
            else if (GameManagerScript.Instance.gameRestarted)
            {
                GameManagerScript.Instance.gameRestarted = false;
                lives = GameManagerScript.Instance.lives;
                score = GameManagerScript.Instance.score;
            }
            livesText.text = "Lives: " + lives.ToString();
            gameOverText.text = "Score: " + score.ToString();
            
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(IgracAnimacija.instance.death == false)
        {
            IncrementScore();
        }
        //else if((GameManagerScript.Instance.score > GameManagerScript.Instance.highscore)
        //    && IgracAnimacija.instance.death == true)
        //{
        //    GameManagerScript.Instance.highscore = GameManagerScript.Instance.score;
        //    highScoreText.text ="HighScore: " + GameManagerScript.Instance.highscore.ToString();
        //}
        
    }

    void IncrementScore()
    {
        GameManagerScript.Instance.score++;
        scoreText.text = "Score: " + GameManagerScript.Instance.score.ToString();

        if(GameManagerScript.Instance.score > GameManagerScript.Instance.highscore)
        {
            GameManagerScript.Instance.highscore = GameManagerScript.Instance.score;
        }
    }
    public void PlayerTakeDamage()
    {
        lives--;
        if (lives > 0)
        {
            StartCoroutine(GameReload("MainScene"));
            livesText.text = "Lives: " + lives.ToString();
            scoreText.text = "Score: " + GameManagerScript.Instance.score.ToString();
        }
        else
        {
            StartCoroutine(WaitBeforeReplay());
        }
    }
    IEnumerator GameReload(string SceneName)
    {
        GameManagerScript.Instance.lives = lives;
        GameManagerScript.Instance.score = GameManagerScript.Instance.score;
        GameManagerScript.Instance.gameRestarted = true;
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneName);
    }

    IEnumerator WaitBeforeReplay()
    {
        yield return new WaitForSeconds(1.5f);
        livesText.text = "Lives: " + 0;
        gameOverText.text = "Score: " + GameManagerScript.Instance.score.ToString();
        highScoreText.text = "HighScore: " + GameManagerScript.Instance.highscore.ToString();
        gameOver.SetActive(true);
    }
    public void PlayAgain()
    {
        Time.timeScale = 1f;
        GameManagerScript.Instance.score = 0;
        SceneManager.LoadScene("StartMenuScene");
    }
    void OnDestroy()
    {
        PlayerPrefs.SetInt("highscore", GameManagerScript.Instance.highscore);
    }
    public void PauseGame()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void Zvuk()
    {
        
    }
}
