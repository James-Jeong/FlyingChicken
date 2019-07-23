using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarController : MonoBehaviour {

    public static StarController instance;

    public GameObject Stars;

    public Image[] StageStars;

    void Awake()
    {
        instance = this;

        if (Stars.tag == "STAGE1STAR")
        {
            StarSituationController(PlayerPrefs.GetInt("Stage1Star"));
        }
        else if (Stars.tag == "STAGE2STAR")
        {
            StarSituationController(PlayerPrefs.GetInt("Stage2Star"));
        }
        else if (Stars.tag == "STAGE3STAR")
        {
            StarSituationController(PlayerPrefs.GetInt("Stage3Star"));
        }
        else if (Stars.tag == "STAGE4STAR")
        {
            StarSituationController(PlayerPrefs.GetInt("Stage4Star"));
        }
        else if (Stars.tag == "STAGE5STAR")
        {
            StarSituationController(PlayerPrefs.GetInt("Stage5Star"));
        }
    }

    public void StarSituationController(int starNumber)
    {
        if (starNumber == 3)
        {
            for (int i = 0; i < 3; i++)
                StageStars[i].enabled = true;
        }
        else if (starNumber == 2)
        {
            StageStars[2].enabled = false;
            for (int i = 0; i < 2; i++)
                StageStars[i].enabled = true;
        }
        else if (starNumber == 1)
        {
            for (int i = 1; i < 3; i++)
                StageStars[i].enabled = false;
            StageStars[0].enabled = true;
        }
        else if (starNumber == 0)
        {
            for (int i = 0; i < 3; i++)
                StageStars[i].enabled = false;
        }
    }
}