using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayUserId : MonoBehaviour {

    public Text userId;

    void Start()
    {
        if(gameDB.Singleton().NowPlayerData.isUsing)
        {
            userId.text = gameDB.Singleton().NowPlayerData.playerName;
        }
        else
        {
            userId.text = "";
        }
    }
}