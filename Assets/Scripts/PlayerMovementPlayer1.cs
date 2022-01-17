using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementPlayer1 : MonoBehaviour
{
    public float speed = 5f;
    public float jumpStrength = 5f;
    public bool isJumping = false;
    public float jumps;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal Player 1");
        float v = Input.GetAxis("Vertical Player 1");
        transform.Translate(new Vector3(h, 0, v) * speed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (!isJumping)
            {
                print("Jump");
                jumps++;
                isJumping = true;
                gameObject.GetComponent<Rigidbody>().velocity = transform.up * jumpStrength;
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        //print(collision.transform.tag);
        if (collision.transform.tag == "ground")
        {
            isJumping = false;
            jumps = 0;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "ground")
        {
            isJumping = true;
            jumps++;
        }
    }
}
