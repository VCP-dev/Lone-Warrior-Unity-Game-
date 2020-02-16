using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grenadescript : MonoBehaviour
{

    float dirX;
    Rigidbody2D rb;

    public bool collided,grounded;

    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        dirX = (playerscript.facingRight) ? 3.23f : -3.23f;
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(dirX, 2.78f), ForceMode2D.Impulse);
        collided = false;
        grounded = false;
        Invoke("spawnexplosion",1.95f);
        Destroy(gameObject,2f);

    }

    private void Update()
    {
        
    }

    void spawnexplosion()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camerascript>().camerashake();
        Instantiate(explosion, transform.position, Quaternion.identity);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collided = true;
        if(collision.gameObject.tag=="ground")
        {
            grounded = true;
        }
    }


}
