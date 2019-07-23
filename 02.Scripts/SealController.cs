using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SealController : MonoBehaviour {

    AudioSource audioSource;
    public AudioClip audioClip1;
    public AudioClip audioClip2;
    public AudioClip audioClip3;
    public AudioClip audioClip4;

    Rigidbody2D rb2d;

    Animator animator;
    float angle;

    bool isDead;
    public ScrollObjects[] scrollObjects;
    public GameObject speedUpCanvas;
    public GameObject speedDownCanvas;

    public float maxHeight;
    public float flapVelocity;
    public float relativeVelocityX;
    public GameObject sprite;

    public Image[] Lifes;
    private int LifeCount = 2;

    public bool IsDead()
    {
        return isDead;
    }


	// Use this for initialization
	void Awake () {
        rb2d = GetComponent<Rigidbody2D>();
        animator = sprite.GetComponent<Animator>();

        audioSource = GetComponent<AudioSource>();

	}

    void Start()
    {
        speedUpCanvas.SetActive(false);
        speedDownCanvas.SetActive(false);
    }

	// Update is called once per frame
	void Update () {

		/*if(transform.position.y < maxHeight)
        {
            Flap();
        }*/

        // 각도를 반영
        ApplyAngle();

        // angle이 수평 이상이라면 애니메이터의 flap플래그를 true로 한다
        animator.SetBool("flap", angle >= 0.0f);
	}

    public void Flap()
    {
        // 죽으면 날아 올라가지 않는다
        if (isDead) return;

        // 중력을 받지 않을 때는 조작하지 않는다
        if (rb2d.isKinematic) return;

        audioSource.PlayOneShot(audioClip1);

        if(transform.position.y < maxHeight)
        {
            // Velocity를 직접 바꿔 써서 위쪽 방향으로 초기화
            rb2d.velocity = new Vector2(0.0f, flapVelocity);
            //rb2d.AddForce(new Vector2(0.0f, flapVelocity));
        }
    }

    void ApplyAngle()
    {
        // 현재 속도, 상대 속도로부터 진행되고 있는 각도를 구한다
        float targetAngle;

        // 사망하면 항상 아래를 향한다
        if(isDead)
        {
            targetAngle = -90.0f;
        }
        else
        {
            targetAngle = Mathf.Atan2(rb2d.velocity.y, relativeVelocityX) * Mathf.Rad2Deg;
        }

        // 회전 애니메이션을 스무딩
        angle = Mathf.Lerp(angle, targetAngle, Time.deltaTime * 10.0f);

        // Rotation을 반영
        sprite.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, angle);
    }

    IEnumerator OnTriggerEnter2D(Collider2D coll)
    {
        if(!isDead)
        {
            if (coll.gameObject.tag == "COIN")
            {
                int n = 0;
                GameController.instance.IncreaseScore();
                audioSource.PlayOneShot(audioClip3);
                coll.gameObject.SetActive(false);

                n = PlayerPrefs.GetInt("CoinQuantity") + 1;
                PlayerPrefs.SetInt("CoinQuantity", n);
                yield return new WaitForSeconds(4.0f);
            }
            else if(coll.gameObject.tag == "COIN2")
            {
                int n = 0;
                GameController.instance.IncreaseScore();
                GameController.instance.IncreaseScore();
                audioSource.PlayOneShot(audioClip3);
                coll.gameObject.SetActive(false);

                n = PlayerPrefs.GetInt("CoinQuantity") + 1;
                PlayerPrefs.SetInt("CoinQuantity", n);
                yield return new WaitForSeconds(4.0f);
            }
            else if(coll.gameObject.tag == "Obstacles")
            {
                GameController.instance.IncreaseScore();
                audioSource.PlayOneShot(audioClip4);
                coll.gameObject.SetActive(false);
                yield return new WaitForSeconds(4.0f);
            }

            coll.gameObject.SetActive(true);
        }
    }

    IEnumerator OnCollisionEnter2D(Collision2D collision)
    {
        if (!isDead)
        {
            if (collision.gameObject.tag == "SPEEDUP")
            {
                audioSource.PlayOneShot(audioClip3);
                speedUpCanvas.SetActive(true);
                speedDownCanvas.SetActive(false);

                for (int i = 0; i < scrollObjects.Length; i++)
                {
                    scrollObjects[i].speed += 3.0f;
                }
                
                collision.gameObject.SetActive(false);
                yield return new WaitForSeconds(2.0f);

                for (int i = 0; i < scrollObjects.Length; i++)
                {
                    scrollObjects[i].speed -= 3.0f;
                }

                speedUpCanvas.SetActive(false);

                yield return new WaitForSeconds(3.0f);
                collision.gameObject.SetActive(true);
            }
            else if (collision.gameObject.tag == "SPEEDDOWN")
            {
                audioSource.PlayOneShot(audioClip3);
                speedDownCanvas.SetActive(true);
                speedUpCanvas.SetActive(false);

                for (int i = 13; i < 21; i++)
                {
                    scrollObjects[i].speed += 2.0f;
                }
                for (int i = 0; i < scrollObjects.Length; i++)
                {
                    scrollObjects[i].speed -= 6.0f;
                }

                collision.gameObject.SetActive(false);
                yield return new WaitForSeconds(2.0f);

                for (int i = 13; i < 21; i++)
                {
                    scrollObjects[i].speed -= 2.0f;
                }
                for (int i = 0; i < scrollObjects.Length; i++)
                {
                    scrollObjects[i].speed += 6.0f;
                }

                speedDownCanvas.SetActive(false);

                yield return new WaitForSeconds(3.0f);
                collision.gameObject.SetActive(true);
            }
            else if (LifeCount == 0)
            {
                speedUpCanvas.SetActive(false);
                speedDownCanvas.SetActive(false);

                isDead = true;
                Lifes[LifeCount].enabled = false;
                // 충돌 효과
                Camera.main.SendMessage("Clash");

                audioSource.PlayOneShot(audioClip2);
            }
            else
            {
                Lifes[LifeCount].enabled = false;
                LifeCount--;

                // 충돌 효과
                Camera.main.SendMessage("Clash");

                audioSource.PlayOneShot(audioClip2);
            }
        }
    }

    // 외부에서 isKinematic을 조작하기 위한 함수
    public void SetSteerActive(bool active)
    {
        // Rigidbody의 On, Off를 전환한다
        rb2d.isKinematic = !active;

        // isKinematic이 true이면 물리적인 영향을 받지 않으므로 중력이 없다 -> 플레이되지 않는 것으로 간주
    }
}