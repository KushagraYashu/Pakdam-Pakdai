using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityScriptPlayer2 : MonoBehaviour
{
    public float abilityDecrease = 2f;
    private float maxAbility = 100f;
    public float curAbilitySpeed;
    public bool abilityPickedUp = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(curAbilitySpeed >= 0)
        {
            curAbilitySpeed -= abilityDecrease * Time.deltaTime;
        }
        else if(abilityPickedUp)
        {
            gameObject.GetComponent<PlayerMovementPlayer2>().speed -= 3f;
            curAbilitySpeed = 0;
            abilityPickedUp = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Speed Ability")
        {
            abilityPickedUp = true;
            curAbilitySpeed = maxAbility;
            gameObject.GetComponent<PlayerMovementPlayer2>().speed += 3f;
            Destroy(collision.gameObject);
        }
    }
}
