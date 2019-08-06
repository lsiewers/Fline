using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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
    public GameObject finalScoreText;
    public GameObject backgroundParticles;


    [Header("Settings")]
    public int PlayerAmount = 1;

    public Color ColorGreen;

    [Header("Game balancing")]
    public float LineSpeed;
    public float CurveSize;
    public float AxisSpeed;

    public int pointsToLevelUp;
    public int pointsMultiplier;

    // not inspector
    private float level;

    private float startTime;
    private float lifeTime;

    private float points;

    [HideInInspector] public bool gameStarted;

    // start
    private void Start()
    {
        Input.multiTouchEnabled = true;

        startTime = Time.time;

        SetColors();
    }

    // update
    private void Update()
    {
        if (gameStarted)
        {
            SetPoints();
            SetLevel();
        }
    }

    private void SetColors()
    {
        scoreText.GetComponent<TextMeshProUGUI>().color = ColorGreen;
        countdownText.GetComponent<TextMeshProUGUI>().color = ColorGreen;
        finalScoreText.GetComponent<TextMeshProUGUI>().color = ColorGreen;
    }

    private void SetPoints()
    {
        lifeTime = Time.time - startTime;
        points = Mathf.Floor(lifeTime * pointsMultiplier);
        scoreText.GetComponent<TextMeshProUGUI>().SetText(points.ToString());
    }

    private void SetLevel()
    {
        var pointsToLevel = Mathf.Floor(points / pointsToLevelUp) + 1; // +1 so it will update in advance

        if (level < pointsToLevel)
        {
            LineSpeed += 0.05f;
            level = pointsToLevel;
            levelText.GetComponent<TextMeshProUGUI>().SetText(level.ToString());
            backgroundParticles.GetComponent<ParticleSystem>().startSize -= 0.1f;

            backgroundParticles.GetComponent<ParticleSystem>().startSpeed += 0.2f;
        }
    }
}
