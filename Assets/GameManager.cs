using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public GameObject scoreText;
    public GameObject levelText;

    public float LineSpeed;
    public float CurveSize;
    public float AxisSpeed;

    public Color ColorGreen;

    private float level = 1;

    private float startTime;
    private float lifeTime;

    private float points;

    private void Start()
    {
        startTime = Time.time;
    }

    private void Update()
    {
        lifeTime = Time.time - startTime;
        points = Mathf.Floor(lifeTime * 10);
        scoreText.GetComponent<TextMeshProUGUI>().SetText(points.ToString());

        var pointsToLevel = Mathf.Floor(points / 150) + 1;

        if (level < pointsToLevel)
        {
            LineSpeed += 0.05f;
            level = pointsToLevel;
            levelText.GetComponent<TextMeshProUGUI>().SetText(level.ToString());
        }
    }
}
