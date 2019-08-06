using System.Collections;
using UnityEngine;
using TMPro;

public class StartCountdown : MonoBehaviour
{
    private float startTime;
    [SerializeField] int secondsToCount;

    private void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        Countdown();
    }

    private void Countdown()
    {
        var seconds = Mathf.Floor(startTime + secondsToCount + 1 - Time.time);
        GetComponent<TextMeshProUGUI>().SetText(seconds.ToString());

        if (seconds < 0)
        {
            GameManager.Instance.gameStarted = true;
            transform.parent.gameObject.SetActive(false);
        }
    }
}
