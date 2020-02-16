using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class corpsescript : MonoBehaviour
{
    int hitcount;

    public GameObject head;
    public GameObject arm;
    public GameObject foot;

    public GameObject blood;

    Rigidbody2D rb;


    private void Start()
    {
        hitcount = 0;
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 7f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="bullet" || collision.gameObject.tag=="cyborglaser")
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camerascript>().camerashake();
            hitcount += 1;
            Destroy(collision.gameObject, 0f);
            Instantiate(blood, transform.position, Quaternion.identity);
            rb.AddForce(new Vector2(0,1.67f),ForceMode2D.Impulse);
            if(hitcount==3)
            {
                //Scorescript.scorevalue += 10;
                Instantiate(head, transform.position, Quaternion.identity);
                Instantiate(arm, transform.position, Quaternion.identity);
                Instantiate(foot, transform.position, Quaternion.identity);
                Instantiate(blood, transform.position, Quaternion.identity);
                Destroy(gameObject, 0f);
            }
        }
        if(collision.gameObject.tag == "shotgunblast")
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camerascript>().camerashake();
            hitcount += 1;
            Destroy(collision.gameObject, 0f);
            Instantiate(blood, transform.position, Quaternion.identity);
            rb.AddForce(new Vector2(0, 1.67f), ForceMode2D.Impulse);
           // Scorescript.scorevalue += 10;
            if (hitcount == 2)
            {
                Instantiate(head, transform.position, Quaternion.identity);
                Instantiate(arm, transform.position, Quaternion.identity);
                Instantiate(foot, transform.position, Quaternion.identity);
                Instantiate(blood, transform.position, Quaternion.identity);
                Destroy(gameObject, 0f);
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="grenadeexplosion")
        {
           // Scorescript.scorevalue += 10;
            Instantiate(head, transform.position, Quaternion.identity);
            Instantiate(arm, transform.position, Quaternion.identity);
            Instantiate(foot, transform.position, Quaternion.identity);
            Instantiate(blood, transform.position, Quaternion.identity);
            Destroy(gameObject, 0f);
        }
    }
}
