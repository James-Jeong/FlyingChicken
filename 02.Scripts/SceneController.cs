using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//using UnityEngine.Advertisements;

public class SceneController : MonoBehaviour {

    public static SceneController instance = null;

    AudioSource audioSource;
    public AudioClip audioClip;

    private static int count = 2;
    

//    ShowOptions mShowOpt = new ShowOptions();

//    public string mstrAdsID = "1278138";
//    public bool mbTestMode = true;

/*    void Awake()
    {
        // Unity Ads를 초기화
        if (Advertisement.isSupported)
        {
            Advertisement.Initialize("1278138", mbTestMode);
            mShowOpt.resultCallback = OnAdsShowResultCallBack;
        }
    }*/

    void Awake()
    {
        instance = this;

        SaveStageStars(PlayerPrefs.GetInt("Score1"), 1);
        SaveStageStars(PlayerPrefs.GetInt("Score2"), 2);
        SaveStageStars(PlayerPrefs.GetInt("Score3"), 3);
        SaveStageStars(PlayerPrefs.GetInt("Score4"), 4);
        SaveStageStars(PlayerPrefs.GetInt("Score5"), 5);


        if (!PlayerPrefs.HasKey("CoinQuantity"))
            PlayerPrefs.SetInt("CoinQuantity", 0);
        if (!PlayerPrefs.HasKey("RainbowQuantity"))
            PlayerPrefs.SetInt("RainbowQuantity", 0);
        if (!PlayerPrefs.HasKey("SOSQuantity"))
            PlayerPrefs.SetInt("SOSQuantity", 0);
    }

    static int n = 0;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
        DontDestroyOnLoad(audioSource);
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public void InitializeData()
    {
        gameDB.Singleton().NowPlayerData.playerName = "";
        gameDB.Singleton().NowPlayerData.maxScore1 = 0;
        gameDB.Singleton().NowPlayerData.maxScore2 = 0;
        gameDB.Singleton().NowPlayerData.maxScore3 = 0;
        gameDB.Singleton().NowPlayerData.maxScore4 = 0;
        gameDB.Singleton().NowPlayerData.isUsing = false;

        gameDB.Singleton().NowPlayerData.Stage1Star = 0;
        gameDB.Singleton().NowPlayerData.Stage2Star = 0;
        gameDB.Singleton().NowPlayerData.Stage3Star = 0;
        gameDB.Singleton().NowPlayerData.Stage4Star = 0;
        gameDB.Singleton().NowPlayerData.Stage5Star = 0;

        gameDB.Singleton().NowPlayerData.CoinQuantity = 0;
        gameDB.Singleton().NowPlayerData.RainbowQuantity = 0;
        gameDB.Singleton().NowPlayerData.SOSQuantity = 0;
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    /*void OnAdsShowResultCallBack(ShowResult result)
    {
        if(result == ShowResult.Finished)
        {
            Debug.Log("Result");
        }
    }
     * 

    public void OnBtnUnityAds()
    {
        if (!Advertisement.isInitialized)
            return;

        //Advertisement.Show(null, mShowOpt);
    }*/

    public void OnClickExit()
    {
        FadeInOut.instance.StartCoroutine(FadeInOut.instance.FadeOut());
        audioSource.PlayOneShot(audioClip);
        Application.Quit();
    }

    public void OnClickToMain()
    {
        //if (Advertisement.IsReady()) Advertisement.Show();
        //if (Advertisement.IsReady()) OnBtnUnityAds();

        PlayerPrefs.SetInt("isStage", 0);
        PlayerPrefs.SetString("SceneName", "Title");
        SceneManager.LoadScene("LoadingScene");
        audioSource.PlayOneShot(audioClip);
    }

    public void OnClickPause()
    {
        PlayerPrefs.SetInt("isStage", 0);
        PlayerPrefs.SetString("SceneName", "Pause");
        SceneManager.LoadScene("LoadingScene");
        audioSource.PlayOneShot(audioClip);
    }

    public void OnClickNextStage()
    {
        audioSource.PlayOneShot(audioClip);

        if (count > 5)
        {
            PlayerPrefs.SetString("SceneName", "Title");
            SceneManager.LoadScene("LoadingScene");
        }
        else
        {
            PlayerPrefs.SetInt("SceneNumber", count);
            SceneManager.LoadScene("LoadingScene");
            count++;
        }
    }

    public void CountNumber(int number)
    {
        count = number;
    }

    public void OnClickMainButton()
    {
        PlayerPrefs.SetInt("isStage", 0);
        PlayerPrefs.SetString("SceneName", "Title");
        SceneManager.LoadScene("LoadingScene");
        audioSource.PlayOneShot(audioClip);
    }

    public void OnClickStage1Button()
    {
        PlayerPrefs.SetInt("isStage", 1);
        PlayerPrefs.SetString("SceneName", "Stage1");
        SceneManager.LoadScene("LoadingScene");
        audioSource.PlayOneShot(audioClip);
        CountNumber(2);
    }
    public void OnClickStage2Button()
    {
        PlayerPrefs.SetInt("isStage", 2);
        PlayerPrefs.SetString("SceneName", "Stage2");
        SceneManager.LoadScene("LoadingScene");
        audioSource.PlayOneShot(audioClip);
        CountNumber(3);
    }
    public void OnClickStage3Button()
    {
        PlayerPrefs.SetInt("isStage", 3);
        PlayerPrefs.SetString("SceneName", "Stage3");
        SceneManager.LoadScene("LoadingScene");
        audioSource.PlayOneShot(audioClip);
        CountNumber(4);
    }
    public void OnClickStage4Button()
    {
        PlayerPrefs.SetInt("isStage", 4);
        PlayerPrefs.SetString("SceneName", "Stage4");
        SceneManager.LoadScene("LoadingScene");
        audioSource.PlayOneShot(audioClip);
        CountNumber(5);
    }
    public void OnClickStage5Button()
    {
        PlayerPrefs.SetInt("isStage", 5);
        PlayerPrefs.SetString("SceneName", "Stage5");
        SceneManager.LoadScene("LoadingScene");
        audioSource.PlayOneShot(audioClip);
        CountNumber(6);
    }

    public void OnClickReturnButton()
    {
        PlayerPrefs.SetString("SceneName", "StageSelect");
        SceneManager.LoadScene("LoadingScene");
        audioSource.PlayOneShot(audioClip);
    }

    public void OnClickAgainButton()
    {
        audioSource.PlayOneShot(audioClip);
        GameController.instance.Reload();
    }

    public void OnClickGetInButton()
    {
        PlayerPrefs.SetInt("isStage", 1);
        PlayerPrefs.SetString("SceneName", "Stage1");
        SceneManager.LoadScene("LoadingScene");
        audioSource.PlayOneShot(audioClip);
    }

    public void OnClickCreateIDButton()
    {
        PlayerPrefs.SetString("SceneName", "CreateID");
        SceneManager.LoadScene("LoadingScene");
        audioSource.PlayOneShot(audioClip);
    }

    public void OnClickGoLoginButton()
    {
        PlayerPrefs.SetString("SceneName", "Login");
        SceneManager.LoadScene("LoadingScene");
        audioSource.PlayOneShot(audioClip);
    }

    public void OnClickShowID()
    {
        PlayerPrefs.SetString("SceneName", "ShowID");
        SceneManager.LoadScene("LoadingScene");
        audioSource.PlayOneShot(audioClip);
    }


    public void OnClickFirstID()
    {
        audioSource.PlayOneShot(audioClip);

        if(gameDB.Singleton().NowPlayerData.isUsing)
        {
            PlayerPrefs.SetString("SceneName", "StageSelect");
            SceneManager.LoadScene("LoadingScene");
        }
        else
        {
            PlayerPrefs.SetString("SceneName", "CreateID");
            SceneManager.LoadScene("LoadingScene");
        }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public void OnClickFirstPlayer()
    {
        PlayerPrefs.SetString("SceneName", "PlayerStatusController");
        SceneManager.LoadScene("LoadingScene");
        audioSource.PlayOneShot(audioClip);
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public void OnClickHelp()
    {
        PlayerPrefs.SetString("SceneName", "Help");
        SceneManager.LoadScene("LoadingScene");
        audioSource.PlayOneShot(audioClip);
    }

    public void OnClickShop()
    {
        PlayerPrefs.SetString("SceneName", "Shop");
        SceneManager.LoadScene("LoadingScene");
        audioSource.PlayOneShot(audioClip);
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public void SaveStageScore(int score, int stageNumber)
    {
        switch(stageNumber)
        {
            case 1:
                if(score > PlayerPrefs.GetInt("Score1"))
                {
                    gameDB.Singleton().NowPlayerData.maxScore1 = score;
                    PlayerPrefs.SetInt("Score1", score);
                    PlayerPrefs.Save();
                    SaveStageStars(PlayerPrefs.GetInt("Score1"), stageNumber);
                }
                break;

            case 2:
                if (score > PlayerPrefs.GetInt("Score2"))
                {
                    gameDB.Singleton().NowPlayerData.maxScore2 = score;
                    PlayerPrefs.SetInt("Score2", score);
                    PlayerPrefs.Save();
                    SaveStageStars(PlayerPrefs.GetInt("Score2"), stageNumber);
                }
                break;

            case 3:
                if (score > PlayerPrefs.GetInt("Score3"))
                {
                    gameDB.Singleton().NowPlayerData.maxScore3 = score;
                    PlayerPrefs.SetInt("Score3", score);
                    PlayerPrefs.Save();
                    SaveStageStars(PlayerPrefs.GetInt("Score3"), stageNumber);
                }
                break;
                
            case 4:
                if (score > PlayerPrefs.GetInt("Score4"))
                {
                    gameDB.Singleton().NowPlayerData.maxScore4 = score;
                    PlayerPrefs.SetInt("Score4", score);
                    PlayerPrefs.Save();
                    SaveStageStars(PlayerPrefs.GetInt("Score4"), stageNumber);
                }
                break;
            case 5:
                if (score > PlayerPrefs.GetInt("Score5"))
                {
                    gameDB.Singleton().NowPlayerData.maxScore5 = score;
                    PlayerPrefs.SetInt("Score5", score);
                    PlayerPrefs.Save();
                    SaveStageStars(PlayerPrefs.GetInt("Score5"), stageNumber);
                }
                break;
        }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public void SaveStageStars(int score, int stageNumber)
    {
        switch (stageNumber)
        {
            case 1:
                if (score >= 90) gameDB.Singleton().NowPlayerData.Stage1Star = 3;
                else if (40 <= score && score <= 89) gameDB.Singleton().NowPlayerData.Stage1Star = 2;
                else if (2 <= score && score <= 39) gameDB.Singleton().NowPlayerData.Stage1Star = 1;
                else if (score <= 1) gameDB.Singleton().NowPlayerData.Stage1Star = 0;

                PlayerPrefs.SetInt("Stage1Star", gameDB.Singleton().NowPlayerData.Stage1Star);
                PlayerPrefs.Save();
                break;

            case 2:
                if (score >= 90) gameDB.Singleton().NowPlayerData.Stage2Star = 3;
                else if (40 <= score && score <= 89) gameDB.Singleton().NowPlayerData.Stage2Star = 2;
                else if (2 <= score && score <= 39) gameDB.Singleton().NowPlayerData.Stage2Star = 1;
                else if (score <= 1) gameDB.Singleton().NowPlayerData.Stage2Star = 0;

                PlayerPrefs.SetInt("Stage2Star", gameDB.Singleton().NowPlayerData.Stage2Star);
                PlayerPrefs.Save();
                break;

            case 3:
                if (score >= 90) gameDB.Singleton().NowPlayerData.Stage3Star = 3;
                else if (40 <= score && score <= 89) gameDB.Singleton().NowPlayerData.Stage3Star = 2;
                else if (2 <= score && score <= 39) gameDB.Singleton().NowPlayerData.Stage3Star = 1;
                else if (score <= 1) gameDB.Singleton().NowPlayerData.Stage3Star = 0;

                PlayerPrefs.SetInt("Stage3Star", gameDB.Singleton().NowPlayerData.Stage3Star);
                PlayerPrefs.Save();
                break;

            case 4:
                if (score >= 90) gameDB.Singleton().NowPlayerData.Stage4Star = 3;
                else if (40 <= score && score <= 89) gameDB.Singleton().NowPlayerData.Stage4Star = 2;
                else if (2 <= score && score <= 39) gameDB.Singleton().NowPlayerData.Stage4Star = 1;
                else if (score <= 1) gameDB.Singleton().NowPlayerData.Stage4Star = 0;

                PlayerPrefs.SetInt("Stage4Star", gameDB.Singleton().NowPlayerData.Stage4Star);
                PlayerPrefs.Save();
                break;
            case 5:
                if (score >= 90) gameDB.Singleton().NowPlayerData.Stage5Star = 3;
                else if (40 <= score && score <= 89) gameDB.Singleton().NowPlayerData.Stage5Star = 2;
                else if (2 <= score && score <= 39) gameDB.Singleton().NowPlayerData.Stage5Star = 1;
                else if (score <= 1) gameDB.Singleton().NowPlayerData.Stage5Star = 0;

                PlayerPrefs.SetInt("Stage5Star", gameDB.Singleton().NowPlayerData.Stage5Star);
                PlayerPrefs.Save();
                break;
        }
    }
}