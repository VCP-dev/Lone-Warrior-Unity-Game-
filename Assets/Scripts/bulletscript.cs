using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletscript : MonoBehaviour
{

    public float velx = 6.89f;
    float vely = 0;
    Rigidbody2D rb;


    public GameObject explosion;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(velx, vely);
        Invoke("spawnexplosion",0.57f);
        Destroy(gameObject, 0.58f);
    }

    void spawnexplosion()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject, 0f);
    }

}
