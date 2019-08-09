using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    // singleton
    public static GameOver Instance { get; private set; }

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

    public void EndGame()
    {
        GameManager.Instance.gameStarted = false;
        gameObject.SetActive(true);
    }
}
