using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStatus : MonoBehaviour {

    public Text[] status;

	void Awake()
    {
        int total1 = 0;

        if (gameDB.Singleton().NowPlayerData.isUsing)
        {
            status[0].text = PlayerPrefs.GetInt("Score1").ToString();
            PlayerPrefs.SetInt(status[0].text, PlayerPrefs.GetInt("Score1"));
            total1 += PlayerPrefs.GetInt("Score1");
        }
        if (gameDB.Singleton().NowPlayerData.isUsing)
        {
            status[1].text = PlayerPrefs.GetInt("Score2").ToString();
            PlayerPrefs.SetInt(status[1].text, PlayerPrefs.GetInt("Score2"));
            total1 += PlayerPrefs.GetInt("Score2");
        }
        if (gameDB.Singleton().NowPlayerData.isUsing)
        {
            status[2].text = PlayerPrefs.GetInt("Score3").ToString();
            PlayerPrefs.SetInt(status[2].text, PlayerPrefs.GetInt("Score3"));
            total1 += PlayerPrefs.GetInt("Score3");
        }
        if (gameDB.Singleton().NowPlayerData.isUsing)
        {
            status[3].text = PlayerPrefs.GetInt("Score4").ToString();
            PlayerPrefs.SetInt(status[3].text, PlayerPrefs.GetInt("Score4"));
            total1 += PlayerPrefs.GetInt("Score4");
        }
        if (gameDB.Singleton().NowPlayerData.isUsing)
        {
            status[4].text = PlayerPrefs.GetInt("Score5").ToString();
            PlayerPrefs.SetInt(status[4].text, PlayerPrefs.GetInt("Score5"));
            total1 += PlayerPrefs.GetInt("Score5");
        }

        status[5].text = total1.ToString();  
	}
}