using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class GameOver : MonoBehaviour
{
    public Text scoreText;
    public Text highScoreText;
    public Button quit;
    public Button tryAgain;

    GameManager gameManager;

	void Start ()
    {
        quit.onClick.RemoveAllListeners();
        quit.onClick.AddListener(() => {
            Application.Quit();        
        });

        tryAgain.onClick.RemoveAllListeners();
        tryAgain.onClick.AddListener(() => {
            SceneManager.LoadScene(1);
        });

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        scoreText.text = "score: " + gameManager.score.ToString("0.00");
        highScoreText.text = "high score: " + gameManager.highScore.ToString("0.00");
    }
	
}
