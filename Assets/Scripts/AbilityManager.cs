using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    public GameObject speedAbilityPrefab;
    public GameObject[] speedAbilitySpawnPoints; 
    
    // Start is called before the first frame update
    void Start()
    {
        speedAbilitySpawnPoints = GameObject.FindGameObjectsWithTag("Speed Ability Spawn Point");
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        for (int i = 0; i < speedAbilitySpawnPoints.Length; i++)
        {
            Instantiate(speedAbilityPrefab, speedAbilitySpawnPoints[i].transform.position, Quaternion.identity);
        }
    }
}
