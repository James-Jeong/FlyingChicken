using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    // 틈새 높이의 범위
    public float minHeight;
    public float maxHeight;

    // Pivot 오브젝트
    public GameObject pivot;


	// Use this for initialization
	void Start () {
		// 시작할 때 틈새의 높이를 변경
        ChangeHeight();
	}
	
    void ChangeHeight()
    {
        // 임의의 높이를 생성하고 설정
        float height = Random.Range(minHeight, maxHeight);
        pivot.transform.localPosition = new Vector3(0.0f, height, 0.0f);
    }

    // ScrollObject 스크립트로부터의 메시지를 받아 높이를 변경
    void OnScrollEnd()
    {
        // 스크롤 완료 시의 틈새 재구성
        ChangeHeight();
    }
}