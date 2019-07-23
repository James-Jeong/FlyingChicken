using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LoginManager : MonoBehaviour {

    AudioSource audioSource;
    public AudioClip audioClip;

    public InputField userId;


	void Start () {
        audioSource = GetComponent<AudioSource>();
	}

    public void OnClickGetIdButton()
    {
        audioSource.PlayOneShot(audioClip);

        if (userId.text == "")
        {
            Debug.Log("Fail");

            return;
        }
        else
        {
            PlayerPrefs.SetString("USER_ID", userId.text);

            Debug.Log("Success to Get ID!");
            PlayerPrefs.SetString("SceneName", "Login");
            SceneManager.LoadScene("LoadingScene");
        }
    }

    public void OnClickGoLoginButton()
    {
        PlayerPrefs.SetString("SceneName", "Login");
        SceneManager.LoadScene("LoadingScene");
        audioSource.PlayOneShot(audioClip);
    }

    public void OnClickMainButton()
    {
        PlayerPrefs.SetString("SceneName", "Title");
        SceneManager.LoadScene("LoadingScene");
        audioSource.PlayOneShot(audioClip);
    }
}