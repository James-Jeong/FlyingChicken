using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip audioClip;

    public static ShopController instance;

    public Text[] Status;

    int RainbowQ = 0;
    int SOSQ = 0;

    void Awake()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        Status[0].text = "COIN : " + PlayerPrefs.GetInt("CoinQuantity").ToString();
        Status[1].text = "RAINBOW : " + PlayerPrefs.GetInt("RainbowQuantity").ToString();
        Status[2].text = "S.O.S : " + PlayerPrefs.GetInt("SOSQuantity").ToString();
    }

    public void OnClickRainbow()
    {
        audioSource.PlayOneShot(audioClip);
        if (PlayerPrefs.GetInt("CoinQuantity") >= 30)
        {
            int n = 0;
            RainbowQ = PlayerPrefs.GetInt("RainbowQuantity") + 1;
            PlayerPrefs.SetInt("RainbowQuantity", RainbowQ);
            Debug.Log(PlayerPrefs.GetInt("RainbowQuantity").ToString());

            n = PlayerPrefs.GetInt("CoinQuantity") - 30;
            PlayerPrefs.SetInt("CoinQuantity", n);
        }
    }

    public void OnClickSOS()
    {
        audioSource.PlayOneShot(audioClip);
        if (PlayerPrefs.GetInt("CoinQuantity") >= 15)
        {
            int n = 0;
            SOSQ = PlayerPrefs.GetInt("SOSQuantity") + 1;
            PlayerPrefs.SetInt("SOSQuantity", SOSQ);
            Debug.Log(PlayerPrefs.GetInt("SOSQuantity").ToString());
            n = PlayerPrefs.GetInt("CoinQuantity") - 15;
            PlayerPrefs.SetInt("CoinQuantity", n);
        }
    }
}