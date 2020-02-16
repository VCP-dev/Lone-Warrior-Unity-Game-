using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Photon.Pun;

public class Manager : MonoBehaviour
{

    public GameObject playerprefab;
    Transform spawnpos;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPlayer();
    }

    void SpawnPlayer()
    {
        spawnpos = gameObject.transform;
        GameObject player = Instantiate(playerprefab,spawnpos.position,playerprefab.transform.rotation);
        DontDestroyOnLoad(player);
    }
}
