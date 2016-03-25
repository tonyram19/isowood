using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{

    public AudioClip loseALifeSFX;
    private static bool spawned = false;

    void Awake()
    {
        if (spawned == false)
        {
            spawned = true;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DestroyImmediate(gameObject); 
        }
    }

    public void PlayLoseALifeSFX()
    {
        GetComponent<AudioSource>().PlayOneShot(loseALifeSFX);
    }
}
