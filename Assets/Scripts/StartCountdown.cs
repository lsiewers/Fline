using System.Collections;
using UnityEngine;
using TMPro;

public class StartCountdown : MonoBehaviour
{
    private float startTime;
    [SerializeField] private int secondsToCount;

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
        var seconds = Mathf.Floor(startTime + secondsToCount + 1 - Time.time); // Plus 1 because it will decrease immidiately when starts counting
        GetComponent<TextMeshProUGUI>().SetText(seconds.ToString());

        // if countdown done
        if (seconds < 0)
        {
            GameManager.Instance.gameStarted = true;
            GameManager.Instance.startTime = Time.time;
            transform.parent.gameObject.SetActive(false);
        }
    }
}
