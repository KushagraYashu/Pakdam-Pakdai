using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TimeManager : MonoBehaviour
{
    float currentTime;
    public GameObject finalScreen;
    public Text wonPlayerName;
    public Text currentTimeText;
    public int maxTimeInSeconds = 10;
    public GameObject[] players = new GameObject[2];

    // Start is called before the first frame update
    void Start()
    {
        currentTime = maxTimeInSeconds;
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Winner Manager").GetComponent<WinnerManager>().winnerDecided)
            Destroy(gameObject);
        
        
        if (currentTime >= 0)
            currentTime = currentTime - Time.deltaTime;
        
        if(currentTime <= 10)
        {
            currentTimeText.color = new Color(255, 0, 0);
        }
        
        if(currentTime <= 0)
        {
            Debug.Log("Time Over");
            GameFinish();
        }
        Debug.Log(currentTime);
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        currentTimeText.text = time.Minutes.ToString() + " : " + time.Seconds.ToString();
       //currentTimeText.text = "Hello";
    }

    void GameFinish()
    {
        if (!GameObject.FindGameObjectWithTag("Winner Manager").GetComponent<WinnerManager>().winnerDecided)
        {
            for (int i = 0; i < 2; i++)
            {
                if (players[i].gameObject.GetComponent<RoleCumRoundManager>().isDefender)
                {
                    wonPlayerName.text = players[i].transform.name;
                    finalScreen.SetActive(true);
                }
            }
        }
        
    }
}
