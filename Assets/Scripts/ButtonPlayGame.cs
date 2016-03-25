using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class ButtonPlayGame : MonoBehaviour
{
    public GameObject tutorial;

	void Start ()
    {
        GetComponent<Button>().onClick.AddListener(() => {
            if (PlayerPrefs.GetInt("tutorialWasCompleted") == 0)
            {
                tutorial.SetActive(true);
                PlayerPrefs.SetInt("tutorialWasCompleted", 1);
            }
            else
            {
                SceneManager.LoadScene(1);
            }
        });
	}
	
}
