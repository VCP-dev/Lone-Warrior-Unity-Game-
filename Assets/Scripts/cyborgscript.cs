using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class cyborgscript : MonoBehaviour
{

    Rigidbody2D rb;
    float speed;
    //  Transform target;
    //   Transform targetbottom;
    Transform player;
    Vector2 localScale;
    bool facingright;
    Animator anim;
    Vector2 bulletpos;

    float range = 2.67f;

    bool move;

    float nextfire = 0f;
    public float firerate;


    public GameObject corpseright;
    public GameObject corpseleft;
    public GameObject blood;
    public GameObject laserleft;
    public GameObject laserright;


   
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // target = GameObject.FindGameObjectWithTag("playerbeacon").GetComponent<Transform>();
        // targetbottom = GameObject.FindGameObjectWithTag("playerbeaconbottom").GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        localScale = transform.localScale;
        speed = Random.Range(1.4f, 2.3f);
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.velocity.x!=0)
        {
            anim.SetBool("ismoving",true);
        }
        if((Vector2.Distance(transform.position,player.position/*target.position*/) < range) /*&& (target.position.y >= transform.position.y) && (targetbottom.position.y <= transform.position.y)*/)
        {
            anim.SetBool("ismoving",false);
            move = false;
            if (Time.time > nextfire)
            {
                anim.SetBool("isshooting", true);
                nextfire = Time.time + firerate;
                fire();
            }

        }
        else
        {
            move = true;
            anim.SetBool("isshooting", false);
        }
        //if(Vector2.Distance(transform.position, player.position) > range/*!(target.position.y >= transform.position.y) || !(targetbottom.position.y <= transform.position.y)*/)
        //{
        //    anim.SetBool("ismoving", false);       //////    TO BE ADDED TO zombiezcript along with idle animation for zombie
        //}
    }


    
    void LateUpdate()
    {
        if (player.position.x < transform.position.x)
        {
            facingright = false;
        }
        else if (player.position.x >= transform.position.x)              // Used to check the direction the player is in and move towards it
        {
            facingright = true;
        }
        if (((facingright) && (localScale.x < 0)) || ((!facingright) && (localScale.x > 0)))
        {
            localScale.x *= -1;
        }
        transform.localScale = localScale;
        if(move /*&& (target.position.y >= transform.position.y) && (targetbottom.position.y <= transform.position.y)*/)  
        {                                                                      /// move towards player if his
            rb.velocity = new Vector2(localScale.x * speed, rb.velocity.y);
                                                                               /// position is more or less on the 
        }                                                                      /// same level as the enemy
        

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bullet" || collision.gameObject.tag=="shotgunblast")
        {
            Destroy(collision.gameObject, 0f);
            Instantiate((facingright ? corpseleft : corpseright), transform.position, Quaternion.identity);
            Instantiate(blood, transform.position, Quaternion.identity);
            Destroy(gameObject, 0f);

        }
        if(collision.gameObject.tag == "grenade" && (collision.gameObject.GetComponent<grenadescript>().collided == false || collision.gameObject.GetComponent<grenadescript>().grounded == false))
        {
            Instantiate((facingright ? corpseleft : corpseright), transform.position, Quaternion.identity);
            Instantiate(blood, transform.position, Quaternion.identity);
            Destroy(gameObject, 0f);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="grenadeexplosion")
        {
            Instantiate((facingright ? corpseleft : corpseright), transform.position, Quaternion.identity);
            Instantiate(blood, transform.position, Quaternion.identity);
            Destroy(gameObject, 0f);
        }
    }


    void fire()
    {
        bulletpos = transform.position;
        if (facingright)
        {
            bulletpos += new Vector2(+0.25f, -0.03f);
            Instantiate(laserright, bulletpos, Quaternion.identity);
        }
        else
        {
            bulletpos += new Vector2(-0.25f, -0.03f);
            Instantiate(laserleft, bulletpos, Quaternion.identity);
        }
    }

}
