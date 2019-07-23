using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadingController : MonoBehaviour
{
    public static LoadingController instance;

    public Slider slider;
    bool IsDone = false;
    float fTime = 0f;
    float speed = 3.0f;
    
    AsyncOperation async_operation;
 
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        //StartCoroutine(StartLoad(gameDB.Singleton().NowSceneName.name));
        if(PlayerPrefs.HasKey("SceneName"))
        {
            StartCoroutine(StartLoad(PlayerPrefs.GetString("SceneName")));
        }
        else if(PlayerPrefs.HasKey("SceneNumber"))
        {
            StartCoroutine(StartLoad(PlayerPrefs.GetString("SceneNumber")));
        }
    }
 
    void Update()
    {
        fTime += Time.deltaTime * speed;
        slider.value = fTime;
 
        if (fTime >= 0.6)
        {
            async_operation.allowSceneActivation = true;
        }
    }
 
    public IEnumerator StartLoad(string strSceneName)
    {
        async_operation = SceneManager.LoadSceneAsync(strSceneName);
        async_operation.allowSceneActivation = false;
 
        if (IsDone == false)
        {
            IsDone = true;
 
            while (async_operation.progress < 0.9f)
            {
                slider.value = async_operation.progress;
 
                yield return true;
            }
        }
    }

    public IEnumerator StartLoad(int strSceneNumber)
    {
        async_operation = SceneManager.LoadSceneAsync(strSceneNumber);
        async_operation.allowSceneActivation = false;

        if (IsDone == false)
        {
            IsDone = true;

            while (async_operation.progress < 0.9f)
            {
                slider.value = async_operation.progress;

                yield return true;
            }
        }
    }
}