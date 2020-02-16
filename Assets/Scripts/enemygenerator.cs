using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemygenerator : MonoBehaviour
{

   // public GameObject cyborg;
    public GameObject zombie;
    // public GameObject barrel;

    public bool stopspawning;
    public float spawnTime;
    public float spawnDelay;
    
    
    public bool moveright;


    int zombiecount;

    
    // Start is called before the first frame update
    //void Start()
    //{
    //    InvokeRepeating("SpawnEnemy",spawnTime,spawnDelay);
    //}

    private void Update()
    {
        zombiecount = GameObject.FindGameObjectsWithTag("zombie").Length;
        if(zombiecount < 10)
        {
            stopspawning = false;
            InvokeRepeating("SpawnEnemy", spawnTime, spawnDelay);
        }
        else
        {
            stopspawning = true;
        }
    }


    public void SpawnEnemy()
    {
        createenemy();
        if(stopspawning)
        {
            CancelInvoke("SpawnEnemy");
        }
    }   


    void createenemy()
    {
        GameObject enemy = Instantiate(zombie, transform.position, Quaternion.identity);//, transform.position, Quaternion.identity);
        if (moveright)
        {
            enemy.GetComponent<zombiescript>().movingright = true;
        }
        else
        {
            enemy.GetComponent<zombiescript>().movingright = false;
        }
        
    }
}
