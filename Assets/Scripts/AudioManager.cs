using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{

    public AudioClip loseALifeSFX;

    public void PlayLoseALifeSFX()
    {
        GetComponent<AudioSource>().PlayOneShot(loseALifeSFX);
    }
}
