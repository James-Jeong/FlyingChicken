using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearTrigger : MonoBehaviour {

    AudioSource audioSource;
    public AudioClip audioClip;

    GameObject gameController;

	// Use this for initialization
	void Start () {
		// 게임 시작 시에 GameController를 Find해둔다
        gameController = GameObject.FindWithTag("GameController");
        audioSource = GetComponent<AudioSource>();
	}
	
    // 트리거에서 Exit하면 일단 클리어한 것으로 간주한다
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "CHICKEN")
        {
            gameController.SendMessage("IncreaseScore");
            audioSource.PlayOneShot(audioClip);
        }
    }
}
