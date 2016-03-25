using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class QuitGame : MonoBehaviour
{
    public Button yes;
    public Button no;

    GameManager gameManager;

    void Start()
    {
        yes.onClick.RemoveAllListeners();
        yes.onClick.AddListener(() => {
            Application.Quit();
        });

        no.onClick.RemoveAllListeners();
        no.onClick.AddListener(() => {
            Time.timeScale = 1;
            gameObject.SetActive(false);
        });

    }
}
