using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using GoogleMobileAds.Api;

public class GameManager : MonoBehaviour
{
    public int deadTrees;
    public GameObject[] hearts;
    private List<GameObject> heartsList;

    [Header("Tree Positions")]
    public Vector3[] treePositions;

    [Header("Timer")]
    public float timer;
    public Text timerText;

    [Header("Timer")]
    public float score;
    public float highScore;

    [Header("Managers")]
    public AudioManager audioManager;

    [Header("Dialogues")]
    public GameObject gameOverDialog;
    public GameObject quitGameDialog;

	void Start ()
    {
        LoadAds();

        timer = 0f;
        heartsList = new List<GameObject>();

        for (int i = 0; i < hearts.Length; i++)
            heartsList.Add(hearts[i]);

        score = 0;
        highScore = PlayerPrefs.GetFloat("highScore");

        ReassignAudioManager();

    }

    void LoadAds()
    {
        AdSize adSize = new AdSize(250, 40);
        BannerView bannerView = new BannerView("ca-app-pub-2928229545764146/5535362916", adSize, AdPosition.BottomRight);
        AdRequest request = new AdRequest.Builder().Build();
        bannerView.LoadAd(request);
    }

    public void LoseALife()
    {
        if (heartsList.Count > 0)
        {
            Destroy(heartsList[heartsList.Count - 1]);
            heartsList.RemoveAt(heartsList.Count - 1);
            audioManager.PlayLoseALifeSFX();
            deadTrees++;
        }
    }

    void ReassignAudioManager()
    {
        if (audioManager == null)
        {
            audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        }
    }

	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            quitGameDialog.SetActive(true);
            Time.timeScale = 0;
        }

        timer += Time.deltaTime;
        timerText.text = "Time: " + timer.ToString("0.0");

        if (deadTrees >= 3)
        {
            score = timer;

            if (score > highScore)
                PlayerPrefs.SetFloat("highScore", score);

            highScore = PlayerPrefs.GetFloat("highScore");

            gameOverDialog.SetActive(true);
        }

	}
}
