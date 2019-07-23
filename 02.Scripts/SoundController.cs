using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundController : MonoBehaviour {

    AudioSource audioSource;
    static int n = 0;
    static bool isUsing = false;

    void Start()
    {
        PlayerPrefs.SetInt("isStage", 0);

        audioSource = GetComponent<AudioSource>();

        if (n == 0)
        {
            audioSource.Play();
            isUsing = true;
            n++;
        }

        DontDestroyOnLoad(audioSource);
    }
	
	void Update ()
    {
        if(audioSource.isPlaying)
        {
            if (PlayerPrefs.GetInt("isStage") == 1)
            {
                audioSource.Pause();
                isUsing = false;
            }
            else if (PlayerPrefs.GetInt("isStage") == 2)
            {
                audioSource.Pause();
                isUsing = false;
            }
            else if (PlayerPrefs.GetInt("isStage") == 3)
            {
                audioSource.Pause();
                isUsing = false;
            }
            else if (PlayerPrefs.GetInt("isStage") == 4)
            {
                audioSource.Pause();
                isUsing = false;
            }
            else if (PlayerPrefs.GetInt("isStage") == 5)
            {
                audioSource.Pause();
                isUsing = false;
            }
        }
        else if (PlayerPrefs.GetInt("isStage") == 0 && !audioSource.isPlaying && !isUsing)
        {
            audioSource.Play();
            isUsing = true;
        }
	}
}