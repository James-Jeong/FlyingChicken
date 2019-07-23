using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[System.Serializable]
public class FadeSetting
{
    public bool _fadeIn;
    public bool _fadeOut;
}

public class FadeInOut : MonoBehaviour
{
    public static FadeInOut instance;

    private Color _fadeColor;

    //public SpriteRenderer _fadeImage;
    public Image _fadeImage;
    public float _fadeTime;
    public bool _isLoadScene;
    public FadeSetting _fadeSetting;
    public string _loadSceneName = null;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        _fadeColor = new Color(0f, 0f, 0f, 1f);
        _fadeImage.color = _fadeColor;
        if (_fadeSetting._fadeIn)
            StartCoroutine(FadeIn());
        else if (_fadeSetting._fadeOut)
            StartCoroutine(FadeOut());
    }

    public IEnumerator FadeIn()
    {
        float elapsedTime = 0f;

        while (elapsedTime < _fadeTime)
        {
            yield return new WaitForEndOfFrame();
            elapsedTime += Time.deltaTime;
            _fadeColor.a = 1.0f - Mathf.Clamp01(elapsedTime / _fadeTime);
            _fadeImage.color = _fadeColor;
        }

        if (_fadeSetting._fadeOut)
            StartCoroutine(FadeOut());
    }

    public IEnumerator FadeOut()
    {
        float elapsedTime = 0f;

        while (elapsedTime < _fadeTime)
        {
            yield return new WaitForEndOfFrame();
            elapsedTime += Time.deltaTime;
            _fadeColor.a = Mathf.Clamp01(elapsedTime / _fadeTime);
            _fadeImage.color = _fadeColor;
        }
        /*if (_isLoadScene)
        {
            if (_loadSceneName != null)
                SceneManager.LoadScene(_loadSceneName);
        }*/
    }
}