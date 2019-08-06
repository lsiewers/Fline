using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public void GameOverMethod()
    {
        GameManager.Instance.gameStarted = false;
        gameObject.SetActive(true);
    }
}
