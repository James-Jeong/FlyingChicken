using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SelectID : MonoBehaviour {

    public static SelectID instance = null;

    public Text idList;

    string[] text;

    static int n;

    void Awake()
    {
        instance = this;

        if(PlayerPrefs.HasKey("USER_ID"))
        {
            idList.text = PlayerPrefs.GetString("USER_ID");
        }
    }

    void Start()
    {
        if(!gameDB.Singleton().NowPlayerData.isUsing)
        {
            idList.text = PlayerPrefs.GetString("USER_ID");
            PlayerPrefs.SetString(idList.text, PlayerPrefs.GetString("USER_ID"));
            PlayerPrefs.Save();

            gameDB.Singleton().NowPlayerData.playerName = PlayerPrefs.GetString("USER_ID");
            gameDB.Singleton().NowPlayerData.isUsing = true;
        }
    }
}