using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrelscript : MonoBehaviour
{

    List<string> tags = new List<string>();
    
    public GameObject explosion;

    private void Start()
    {
        tags.Add("bullet");
        tags.Add("cyborglaser");
        tags.Add("shotgunblast");
        tags.Add("rocket");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(tags.Contains(collision.gameObject.tag))
        {
            Instantiate(explosion,transform.position,Quaternion.identity);
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camerascript>().camerashake();
            Destroy(gameObject,0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "grenadeexplosion")
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camerascript>().camerashake();
            Destroy(gameObject, 0f);
        }
    }

}
