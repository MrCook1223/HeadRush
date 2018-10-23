using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControler : MonoBehaviour {
    public GameObject gameOvrerPanel;
    public Text scoreText;
    public static int score = 0;
    public Text bestText;
    public Text currentText;
    public GameObject newAlert;
    public GameObject NameInput;
    public GameObject SendToBtn;

	// Use this for initialization
	void Start () 
	{
        score = 0;
    	}
	
	// Update is called once per frame
	void Update () {}

    public void GameOver()
    {
        Invoke("ShowOverPanel", 1.0f);
    }

    void ShowOverPanel()
    {
        PlayerPrefs.SetInt("Best", 0);
        scoreText.gameObject.SetActive(false);
        if (score > PlayerPrefs.GetInt("Best", 0))
        {
            PlayerPrefs.SetInt("Best", score);
            newAlert.SetActive(true);
            SendToBtn.SetActive(true);
            NameInput.SetActive(true);
        }
        bestText.text = "Best Score : " + PlayerPrefs.GetInt("Best", 0).ToString();
        currentText.text = "Current Score : " + score.ToString();
        gameOvrerPanel.SetActive(true);
    }


    public void SendToServer()
    {
        string setURL = "http://localhost:8080/PostName.php?";
        string name = "name=";
        string score2 = "&points=";

        if (NameInput.GetComponent<InputField>().text != "")
        {
            name += NameInput.GetComponent<InputField>().text.ToString();
            name = name.Replace(" ", "_");
            score2 += score;
            setURL += name + score2;
            StartCoroutine(SetTheText(setURL));
            SendToBtn.SetActive(false);
            NameInput.SetActive(false);
        }

    }
    IEnumerator SetTheText(string url)
    {
        WWW www = new WWW(url);
        yield return www;
    }



    public void Restart()
    {
        Time.timeScale = 1f;
        Initiate.Fade("Game", Color.white, 2.0f);
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        //Initiate.Fade(SceneManager.GetActiveScene().buildIndex - 2, Color.white, 2.0f);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
        Initiate.Fade("MainMenu", Color.white, 2.0f);
    }

    public void IncrementScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
