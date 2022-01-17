using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    
    public int randNo;
    
    // Start is called before the first frame update
    void Start()
    {
        AssignRoles();
    }

    // Update is called once per frame
    void Update()
    {
        //print(randNo);

    }

    public void AssignRoles()
    {
        randNo = Random.Range(0, 10);
        if(randNo % 2 == 0)
        {
            player1.GetComponent<RoleCumRoundManager>().isDefender = false;
            player1.GetComponent<RoleCumRoundManager>().isAttacker = true;
            player2.GetComponent<RoleCumRoundManager>().isDefender = true;
            player2.GetComponent<RoleCumRoundManager>().isAttacker = false;
        }
        else
        {
            player2.GetComponent<RoleCumRoundManager>().isAttacker = true;
            player2.GetComponent<RoleCumRoundManager>().isDefender = false;
            player1.GetComponent<RoleCumRoundManager>().isAttacker = false;
            player1.GetComponent<RoleCumRoundManager>().isDefender = true;
        }
    }
}
