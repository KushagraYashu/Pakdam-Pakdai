using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementPlayer2 : MonoBehaviour
{
    public float speed = 5f;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("HorizontalPlayer2");
        float v = Input.GetAxis("VerticalPlayer2");
        transform.Translate(new Vector3(h, 0, v) * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        print(collision.transform.tag);
    }
}
