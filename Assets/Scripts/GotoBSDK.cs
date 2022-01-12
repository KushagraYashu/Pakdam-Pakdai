using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GotoBSDK : MonoBehaviour
{
    public float speed;
    private bool reached;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (reached)
        {
            moveTowardLeft();
        }
        if (!reached)
        {
            moveTowardRight();
        }
        if(transform.position.x >= 75f)
        {
            reached = true;
        }
        if (transform.position.x <= 64f)
        {
            reached = false;
        }
    }

    void moveTowardRight()
    {
        transform.Translate(speed*Time.deltaTime,0,0);
    }

    void moveTowardLeft()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0);
    }
}
