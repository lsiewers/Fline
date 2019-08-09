using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // singleton
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // inspector
    [Header("Reference objects")]
    public GameObject scoreText;
    public GameObject levelText;
    public GameObject countdownText;
    public GameObject gameOverScreen;
    public GameObject backgroundParticles;
    //public GameObject logText;


    [Header("Settings")]
    public int PlayerCount;

    [Header("Game balancing")]
    public float LineSpeed;
    public float CurveSize;
    public float AxisSpeed;

    public int pointsToLevelUp;
    public int pointsMultiplier;

    // not inspector
    private float level;

    [HideInInspector] public float startTime;
    private float lifeTime;

    private float points;

    [HideInInspector] public bool gameStarted;
    [HideInInspector] public int activePlayers;

    private void Start()
    {
        Input.multiTouchEnabled = true;
    }

    // update
    private void Update()
    {
        if (gameStarted)
        {
            SetPoints();
            SetLevel();
        }

        // PlayerCount is equal to active players. If 0 than all players are game over.
        if (PlayerCount <= 0)
        {
            GameOver();
        }

        //logText.GetComponent<TextMeshProUGUI>().SetText(PlayerCount.ToString());
    }

    private void SetPoints()
    {
        lifeTime = Time.time - startTime; // points based on time, Time.time to make it start on 0
        points = Mathf.Floor(lifeTime * pointsMultiplier); // no decimals and to make points feel more valuable times a multiplier
        scoreText.GetComponent<TextMeshProUGUI>().SetText(points.ToString()); // set points in text as feedback
    }

    private void SetLevel()
    {
        var pointsToLevel = Mathf.Floor(points / pointsToLevelUp) + 1; // +1 so it will update in advance

        if (level < pointsToLevel)
        {
            LineSpeed += 0.05f; // increase speed on higher level
            level = pointsToLevel;

            levelText.GetComponent<TextMeshProUGUI>().SetText(level.ToString()); // set new level on background text
            backgroundParticles.GetComponent<ParticleSystem>().startSize -= 0.2f; // smaller particles, because they grow on speed and speed increases

            backgroundParticles.GetComponent<ParticleSystem>().startSpeed += 0.2f; // on speed increase game, increase particle speed
        }
    }

    public void GameOver()
    {
        gameStarted = false; // stop the game
        gameOverScreen.SetActive(true); // make game over screen appear
        gameOverScreen.transform.Find("Score").GetComponent<TextMeshProUGUI>().SetText(points.ToString()); // set final score
        AudioManager.Instance.Play("Game Over");

        // if highscore
        if (points > PlayerPrefs.GetInt("highscore"))
        {
            AudioManager.Instance.Play("Highscore");
            gameOverScreen.transform.Find("New highscore").gameObject.SetActive(true); // show highscore text
            PlayerPrefs.SetInt("highscore", (int)points); // save highscore on device
        }
    }

    // button functions
    public void Retry()
    {
        AudioManager.Instance.Play("Click");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Back()
    {
        AudioManager.Instance.Play("Click");
        SceneManager.LoadScene("Menu");
    }
}
