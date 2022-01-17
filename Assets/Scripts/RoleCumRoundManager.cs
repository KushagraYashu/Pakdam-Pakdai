using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoleCumRoundManager : MonoBehaviour
{
    public bool isAttacker;
    public bool isDefender;
    public Material attackerMaterial;
    public Material defenderMaterial;
    public GameObject finalScreen;
    public Text wonPlayerName;
    public GameObject[] players = new GameObject[2];

    // Start is called before the first frame update
    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (isAttacker)
        {
            this.GetComponent<MeshRenderer>().material = attackerMaterial;
        }
        if (isDefender)
        {
            this.GetComponent<MeshRenderer>().material = defenderMaterial;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            CheckCollisionAndEndGame(collision);
        }
        if(collision.transform.tag == "End Collider")
        {
            for(int i=0; i<2; i++)
            {
                if(players[i].transform.name != this.transform.name)
                {
                    if(!GameObject.FindGameObjectWithTag("Winner Manager").GetComponent<WinnerManager>().winnerDecided)
                    {
                        wonPlayerName.text = players[i].transform.name;
                        
                        finalScreen.gameObject.SetActive(true);
                        GameObject.FindGameObjectWithTag("Winner Manager").GetComponent<WinnerManager>().winnerDecided = true;
                    }
                }
            }
        }
    }

    public void CheckCollisionAndEndGame(Collision collision)
    {
        if (!GameObject.FindGameObjectWithTag("Winner Manager").GetComponent<WinnerManager>().winnerDecided)
        {
            if ((this.gameObject.GetComponent<RoleCumRoundManager>().isAttacker && collision.gameObject.GetComponent<RoleCumRoundManager>().isDefender))
            {
                print("Game has Ended");
                wonPlayerName.text = this.transform.name;
                
                finalScreen.gameObject.SetActive(true);
                GameObject.FindGameObjectWithTag("Winner Manager").GetComponent<WinnerManager>().winnerDecided = true;
                //Destroy(this.gameObject);
                //Destroy(collision.gameObject);
            }
            if ((this.gameObject.GetComponent<RoleCumRoundManager>().isDefender && collision.gameObject.GetComponent<RoleCumRoundManager>().isAttacker))
            {
                print("Game has Ended");
                wonPlayerName.text = collision.transform.name;
                
                finalScreen.gameObject.SetActive(true);
                GameObject.FindGameObjectWithTag("Winner Manager").GetComponent<WinnerManager>().winnerDecided = true;
                //Destroy(this.gameObject);
                //Destroy(collision.gameObject);
            }
        }
    }
}
