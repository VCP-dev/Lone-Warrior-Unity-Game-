using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scorescript : MonoBehaviour
{

    public static int scorevalue=900;
    Text score;

    public GameObject gameover;

    // Start is called before the first frame update
    void Start()
    {
        scorevalue = 0;
        score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = scorevalue.ToString();
        
    }

}
