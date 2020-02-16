using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class playerspawnerscript : MonoBehaviour
{
   
    public GameObject enemygen1, enemygen2;

    public GameObject gameover;


    public static float enemycount;


    private void Start()
    {
        enemycount = 0;
    }


    // Update is called once per frame
    void Update()
    {
        if(!GameObject.FindGameObjectWithTag("Player"))
        {
            enemygen1.SetActive(false);
            enemygen2.SetActive(false);
            Invoke("GameOver",1.34f);
        }
        if(gameover.activeSelf)
        {
            if (CrossPlatformInputManager.GetButtonDown("Jump"))  //Input.GetKeyDown(KeyCode.UpArrow))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        
    }


    void GameOver()
    {
        gameover.SetActive(true);
    }

}
