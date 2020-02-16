using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocketscript : MonoBehaviour
{

    public GameObject explosion;

    public float velx;
    float vely = 0;
    Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(velx, vely);
        Invoke("spawnexplosion", 0.769f);
        Destroy(gameObject, 0.7697f);
    }

    void spawnexplosion()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camerascript>().camerashake();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camerascript>().camerashake();
    }
}
