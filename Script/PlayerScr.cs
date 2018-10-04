using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScr : MonoBehaviour {
    public float JumpPower = 10.0f;
    public Text Test;
    Rigidbody2D myRigedbody;
    private bool isGrounded = false;
    float posX = 0.0f;
    float posY = 0.0f;
    bool isGameOver = false;
    bool JumpCheck = false;
    ChallengeScroller mychallengeScroller;
    GameControler myGameControler;
    public GameObject GameUI;
    public AudioClip JumpSound;
    public AudioClip DieSound;
    public AudioClip PickUpSound;

    public GameObject Test1;
    public Texture2D tex;

    float threshold = 0.775f;

    AudioSource myAudioPlayer;
    int Count = 0;
    Animator[] Trse;

    // Use this for initialization
    void Start () {
        GameUI.SetActive(true);
        myRigedbody = transform.GetComponent<Rigidbody2D>();
        posX = transform.position.x;
        posY = transform.position.y;
        mychallengeScroller = GameObject.FindObjectOfType<ChallengeScroller>();
        myGameControler = GameObject.FindObjectOfType<GameControler>();
        myAudioPlayer = GameObject.FindObjectOfType<AudioSource>();
        Trse = GameObject.FindObjectsOfType<Animator>();
        Test1.GetComponent<SpriteRenderer>().sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
        



    }
	
	// Update is called once per frame
	public void Jump() {
        if (isGrounded && !isGameOver && !JumpCheck )
        {
            myRigedbody.AddForce(Vector3.up * (JumpPower * myRigedbody.mass * myRigedbody.gravityScale * 20.0f));
            Count++;
            myAudioPlayer.PlayOneShot(JumpSound);
            isGrounded = false;
            JumpCheck = true;
        }
        //Hit in the face check
        //if(transform.position.x < posX)
        //{
        //    GameOver();
        //}
    }

    void GameOver()
    {
        Trse[0].speed = 0;
        myAudioPlayer.PlayOneShot(DieSound);
        GameUI.SetActive(false);
        isGameOver = true;
        mychallengeScroller.GameOver();
    }

    void Update()
    {
        posX = transform.position.x;
        if (posX <= - 10.0f && !isGameOver)
        {
            GameOver();
        }


        Test.text=Input.acceleration.x.ToString()+","+(Input.acceleration.y * -1).ToString()+"," + Input.acceleration.z.ToString()+":"+Count.ToString();

        if (System.Math.Round((Input.acceleration.y) * -1, 3) >= threshold && Pouse.Pospeskometre)
        {
           Jump();
        }
        
        posY = transform.position.y;
        if (posY < -3.07 || -1.7f > posY  && -1.8f < posY || -0.8f > posY && -0.93f < posY)
        {
            JumpCheck = false;
        }

    }
    

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Ground")
        {
            isGrounded = true;
        }
        posY = transform.position.y;
        if (posY < -3.1f || posY < -0.28f && posY > -0.29f)
        {
            JumpCheck = false;
        }

        if (other.collider.tag == "Enemy" )
        {
            GameOver();
        }
    }

    //void OnCollisionExit2D(Collision2D other)
    //{
    //    if (other.collider.tag == "Ground")
    //    {
    //        isGrounded = false;
    //    }
    //}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Star") {
            myAudioPlayer.PlayOneShot(PickUpSound);
            myGameControler.IncrementScore();
            Destroy(other.gameObject);
        }
    }
}
