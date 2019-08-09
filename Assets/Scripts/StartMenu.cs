using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private GameObject highscoreText;
    private int highscore;

    private void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore"); // get saved highscore
        highscoreText.GetComponent<TextMeshProUGUI>().SetText(highscore.ToString());
    }

    public void LoadScene(string scene)
    {
        AudioManager.Instance.Play("Click");
        SceneManager.LoadScene(scene);
    }
}
