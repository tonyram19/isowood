using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class ButtonPlayGame : MonoBehaviour
{

	void Start ()
    {
        GetComponent<Button>().onClick.AddListener(() => {
            SceneManager.LoadScene(1);
        });
	}
	
}
