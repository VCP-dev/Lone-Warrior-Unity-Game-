using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammocratescript : MonoBehaviour
{

    public string ammotype;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<playerscript>().setammotype(ammotype);
            Destroy(gameObject, 0f);
            Scorescript.scorevalue += 1;
        }
    }
}
