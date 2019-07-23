using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    AudioSource audioSource;
    public AudioClip audioClip;

    public static GameController instance = null;

    // 게임 스테이트
    enum State
    {
        Ready, Play, GameOver
    }

    State state;

    // 블락 통과 시의 획득 점수
    int score;

    public SealController seal;
    public GameObject blocks;
    public GameObject grounds;
    public GameObject clouds;
    public GameObject[] Obstacles;
    public GameObject[] Speed;

    // 화면에 나타낼 텍스트들
    public Text scoreLabel;
    public Text stateLabel;

    public Canvas pause;
    public Canvas canvas;

    public Text text;

    public Text CoinQuantityText;

    public GameObject[] Items;
    public Text[] ItemNumbers;

    CircleCollider2D chickenCircle;

    public GameObject ReadyPanel;

    void Awake()
    {
        instance = this;

        Items[0].SetActive(false);
        Items[1].SetActive(false);
        
        CoinQuantityText.text = "COIN : " + PlayerPrefs.GetInt("CoinQuantity").ToString();
        ItemNumbers[0].text = PlayerPrefs.GetInt("RainbowQuantity").ToString();
        ItemNumbers[1].text = PlayerPrefs.GetInt("SOSQuantity").ToString();

        audioSource = GetComponent<AudioSource>();
    }

	// Use this for initialization
	void Start () {

        chickenCircle = seal.GetComponent<CircleCollider2D>();

        ReadyPanel.SetActive(true);

		// 시작과 동시에 Ready 스테이트로 전환
        Ready();

        canvas.enabled = false;
        pause.enabled = false;
	}

    void Update()
    {
        CoinQuantityText.text = "COIN : " + PlayerPrefs.GetInt("CoinQuantity").ToString();
        ItemNumbers[0].text = PlayerPrefs.GetInt("RainbowQuantity").ToString();
        ItemNumbers[1].text = PlayerPrefs.GetInt("SOSQuantity").ToString();
    }

	// Update is called once per frame
	void LateUpdate () {
        // 게임의 스테이트마다 이벤트를 감시
        switch(state)
        {
            case State.Ready:
                // 탭하면 게임 시작
                if (Input.GetButtonDown("Fire1"))
                {
                    ReadyPanel.SetActive(false);
                    GameStart();
                }
                break;
            case State.Play:
                // 캐릭터가 사망하면 게임 오버
                if (seal.IsDead()) GameOver();
                break;
            /*case State.GameOver:
                // 탭하면 씬을 로드
                if (Input.GetButtonDown("fire1")) Reload();
                break;*/
        }
	}

    public void Ready()
    {
        state = State.Ready;

        // 각 오브젝트를 무효 상태로 한다
        seal.SetSteerActive(false);
        blocks.SetActive(false);
        clouds.SetActive(false);
        grounds.SetActive(false);
        for(int i=0; i<Obstacles.Length; i++)
        {
            Obstacles[i].SetActive(false);
        }
        for (int i = 0; i < Speed.Length; i++)
        {
            Speed[i].SetActive(false);
        }
        
        // 레이블을 업데이트
        scoreLabel.text = "Score : " + 0;

        stateLabel.gameObject.SetActive(true);
        stateLabel.text = "Ready";
    }

    public void GameStart()
    {
        pause.enabled = true;
        canvas.enabled = false;

        state = State.Play;

        // 각 오브젝트를 유효로 한다
        seal.SetSteerActive(true);
        blocks.SetActive(true);
        clouds.SetActive(true);
        grounds.SetActive(true);
        for (int i = 0; i < Obstacles.Length; i++)
        {
            Obstacles[i].SetActive(true);
        }
        for (int i = 0; i < Speed.Length; i++)
        {
            Speed[i].SetActive(true);
        }

        // 처음의 입력만 게임 컨트롤러부터 건넨다
        seal.Flap();

        // 레이블을 업데이트
        stateLabel.gameObject.SetActive(false);
        stateLabel.text = "";
    }

    void GameOver()
    {
        ReadyPanel.SetActive(true);
        pause.enabled = false;
        canvas.enabled = true;

        state = State.GameOver;

        // 씬 안의 모든 ScrollObject 컴포넌트를 찾아낸다
        ScrollObjects[] scrollObjects = GameController.FindObjectsOfType<ScrollObjects>();

        // 모든 ScrollObject의 스크롤 처리를 무효로 한다
        foreach (ScrollObjects so in scrollObjects) so.enabled = false;

        if(text.gameObject.tag == "STAGE1") // Stage1
        {
            SceneController.instance.SaveStageScore(score, 1);
        }
        else if (text.gameObject.tag == "STAGE2") // Stage2
        {
            SceneController.instance.SaveStageScore(score, 2);
        }
        else if (text.gameObject.tag == "STAGE3") // Stage3
        {
            SceneController.instance.SaveStageScore(score, 3);
        }
        else if (text.gameObject.tag == "STAGE4") // Stage4
        {
            SceneController.instance.SaveStageScore(score, 4);
        }
        else if (text.gameObject.tag == "STAGE5") // Stage5
        {
            SceneController.instance.SaveStageScore(score, 5);
        }

        // 레이블을 업데이트
        stateLabel.gameObject.SetActive(true);
        stateLabel.text = "GameOver";
    }

    public void Reload()
    {
        // 현재 로딩하고 있는 씬을 리로딩
        // Application.LoadLevel(Application.loadedLevel);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void IncreaseScore()
    {
        if(!seal.IsDead())
        {
            if (text.gameObject.tag == "STAGE5")
            {
                score++;
                scoreLabel.text = "Score : " + score;
            }
            else
            {
                score++;
                scoreLabel.text = "Score : " + score;
                if (score > 99)
                {
                    if (text.gameObject.tag == "STAGE1") // Stage1
                    {
                        SceneController.instance.SaveStageScore(score, 1);
                    }
                    else if (text.gameObject.tag == "STAGE2") // Stage2
                    {
                        SceneController.instance.SaveStageScore(score, 2);
                    }
                    else if (text.gameObject.tag == "STAGE3") // Stage3
                    {
                        SceneController.instance.SaveStageScore(score, 3);
                    }
                    else if (text.gameObject.tag == "STAGE4") // Stage4
                    {
                        SceneController.instance.SaveStageScore(score, 4);
                    }
                    else if (text.gameObject.tag == "STAGE5") // Stage5
                    {
                        SceneController.instance.SaveStageScore(score, 5);
                    }
                    SceneManager.LoadScene("IntervalStage");
                }
            }
        }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public void OnClickRainbow1()
    {
        audioSource.PlayOneShot(audioClip);
        if(PlayerPrefs.GetInt("RainbowQuantity") > 0)
        {
            int n = 0;
            n = PlayerPrefs.GetInt("RainbowQuantity") - 1;
            StartCoroutine("OnClickRainbow2", n);
        }
    }

    IEnumerator OnClickRainbow2(int n)
    {
        chickenCircle.enabled = false;
        Items[0].SetActive(true);
        PlayerPrefs.SetInt("RainbowQuantity", n);
        yield return new WaitForSeconds(3.0f);
        Items[0].SetActive(false);
        chickenCircle.enabled = true;
    }

    public void OnClickSOS1()
    {
        audioSource.PlayOneShot(audioClip);
        if (PlayerPrefs.GetInt("SOSQuantity") > 0)
        {
            int n = 0;
            n = PlayerPrefs.GetInt("SOSQuantity") - 1;
            StartCoroutine("OnClickSOS2", n);
        }
    }

    public IEnumerator OnClickSOS2(int n)
    {
        Items[1].SetActive(true);
        PlayerPrefs.SetInt("SOSQuantity", n);
        yield return new WaitForSeconds(3.0f);
        Items[1].SetActive(false);
    }
}