using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cratespawner : MonoBehaviour
{

    public Transform[] cratespawnpositions;
    Transform[] positions;
    Vector2 spawnpos;


    GameObject cratespawned;

    public GameObject bulletcrate;
    public GameObject shotguncrate;
    public GameObject rocketcrate;



    // Start is called before the first frame update
    void Start()
    {
        cratespawned = Instantiate(spawncrate(Random.Range(0, 3)),cratespawnpositions[Random.Range(0,cratespawnpositions.Length)].position,Quaternion.identity);
        positions = cratespawnpositions;
    }

    // Update is called once per frame
    void Update()
    {
        if(cratespawned == null)
        {
            cratespawned = Instantiate(spawncrate(Random.Range(0, 3)), cratespawnpositions[Random.Range(0, cratespawnpositions.Length)].position, Quaternion.identity);
        }
    }

    GameObject spawncrate(int crate)
    {       
        switch(crate)
        {
            case 0:
               return shotguncrate;
                
            case 1:
               return bulletcrate;
                
            case 2:
               return rocketcrate;

            default:
                return null;                           
        }        
    }
}
