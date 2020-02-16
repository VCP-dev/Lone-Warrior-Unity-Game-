using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debrisscript : MonoBehaviour
{

    Rigidbody2D rb;
    float dirX;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dirX = Random.Range(-2,2);
        rb.AddForce(new Vector2(dirX, -1), ForceMode2D.Impulse);
        Destroy(gameObject, 0.45f);
    }

    
}
