using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeScroller : MonoBehaviour {
    public float scrollSpeed = 8.0f;
    public GameObject[] challenges;
    public float frequency = 0.5f;
    float counter = 0.0f;
    public Transform challengesSpawnPoint;
    bool isGameOver = false;
    bool check = true;
    

    // Use this for initialization
    void Start () {
        GenerateRandomChalenge();
        check = true;
        GameObject.FindObjectOfType<AudioSource>().mute = Pouse.soundMute;
    }
	
	// Update is called once per frame
	void Update () {
        
        if (isGameOver) return;
        if ((GameControler.score) == 5 && check==true)
        {
            check = false;
            scrollSpeed += 1f;
        }
        if ((GameControler.score) == 10 && check == false)
        {
            check = true;
            scrollSpeed += 1f;
            frequency += 0.1f;
        }
        if ((GameControler.score) == 15 && check == true)
        {
            check = false;
            scrollSpeed += 1f;
            frequency += 0.1f;
        }
        if ((GameControler.score) == 20 && check == false)
        {
            check = true;
            scrollSpeed += 1f;
            frequency += 0.1f;
        }
        if ((GameControler.score) == 25 && check == true)
        {
            check = false;
            scrollSpeed += 1f;
            frequency += 0.1f;
        }
        if ((GameControler.score) == 30 && check == false)
        {
            check = true;
            scrollSpeed += 1f;
            frequency += 0.1f;
        }
        if ((GameControler.score) == 35 && check == true)
        {
            check = false;
            scrollSpeed += 1f;
            frequency += 0.1f;
        }
        if ((GameControler.score) == 40 && check == false)
        {
            check = true;
            scrollSpeed += 1f;
            frequency += 0.1f;
        }
        if ((GameControler.score) == 45 && check == true)
        {
            check = false;
            scrollSpeed += 1f;
        }
        if ((GameControler.score) == 50 && check == false)
        {
            check = true;
            scrollSpeed += 1f;
        }
        if ((GameControler.score) == 55 && check == true)
        {
            check = false;
            scrollSpeed += 1f;
        }
        if ((GameControler.score) == 60 && check == false)
        {
            check = true;
            scrollSpeed += 1f;
        }
        if ((GameControler.score) == 65 && check == true)
        {
            check = false;
            scrollSpeed += 1f;
        }
        //scrolling
        //generate rendom object
        if (counter <= 0.0f)
        {
            GenerateRandomChalenge();
        }
        else
        {
            counter -= Time.deltaTime * frequency;
        }

        GameObject currentChild;
        for(int i = 0; i < transform.childCount; i++)
        {
            currentChild = transform.GetChild(i).gameObject;
            ScrollChallenge(currentChild);
            if(currentChild.transform.position.x <= -15.0f)
            {
                Destroy(currentChild);
            }
        }
	}

    void ScrollChallenge(GameObject currentChallenge)
    {
        currentChallenge.transform.position -= Vector3.right * (scrollSpeed * Time.deltaTime);
    }
    void GenerateRandomChalenge()
    {
        GameObject NewChallenge = Instantiate(challenges[Random.Range(0, challenges.Length)], challengesSpawnPoint.position, Quaternion.identity) as GameObject;
        NewChallenge.transform.parent = transform;


        counter = 1.0f;
    }
    public void GameOver()
    {
        isGameOver = true;
        transform.GetComponent<GameControler>().GameOver();
    }
}
