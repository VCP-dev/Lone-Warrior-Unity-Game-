using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bodypartscript : MonoBehaviour
{

    Rigidbody2D rb;
    float dirX, dirY, torque;

    // Start is called before the first frame update
    void Start()
    {
        dirX = Random.Range(-4, 4);
        dirY = Random.Range(3, 7);
        torque = Random.Range(0.6f,1.1f);
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(dirX, dirY), ForceMode2D.Impulse);
        rb.AddTorque(torque, ForceMode2D.Force);

        Destroy(gameObject, 1.3f);
    }

   
}
