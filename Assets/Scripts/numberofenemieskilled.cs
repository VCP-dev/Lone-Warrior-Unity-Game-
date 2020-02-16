using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class numberofenemieskilled : MonoBehaviour
{

    Text enemycounttext;

    // Start is called before the first frame update
    void Start()
    {
        enemycounttext = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        enemycounttext.text = playerspawnerscript.enemycount.ToString() + " zombies killed";
    }
}
