using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockscript : MonoBehaviour
{
    public GameObject debris1;
    public GameObject debris2;
    public GameObject debris3;
  

    Vector2 pos;


    int hitcount=0;

    void Start()
    {
        pos.x = transform.position.x;
        pos.y = transform.position.y + 0.2f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="bullet")
        {
            hitcount += 1;
            Instantiate(debris1, pos, Quaternion.identity);
            Instantiate(debris2, pos, Quaternion.identity);
            Instantiate(debris3, pos, Quaternion.identity);
            if (hitcount==2)
            {
                Instantiate(debris1,pos,Quaternion.identity);
                Instantiate(debris2,pos,Quaternion.identity);
                Instantiate(debris3,pos,Quaternion.identity);
                Destroy(gameObject,0f);
            }
        }
        if(collision.gameObject.tag=="shotgunblast")
        {
            hitcount += 1;
            Instantiate(debris1, pos, Quaternion.identity);
            Instantiate(debris2, pos, Quaternion.identity);
            Instantiate(debris3, pos, Quaternion.identity);
            if (hitcount==2)
            {
                Instantiate(debris1, pos, Quaternion.identity);
                Instantiate(debris2, pos, Quaternion.identity);
                Instantiate(debris3, pos, Quaternion.identity);
                Destroy(gameObject, 0f);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="grenadeexplosion")
        {
            Instantiate(debris1, pos, Quaternion.identity);
            Instantiate(debris2, pos, Quaternion.identity);
            Instantiate(debris3, pos, Quaternion.identity);
            Destroy(gameObject, 0f);
        }
    }
}
