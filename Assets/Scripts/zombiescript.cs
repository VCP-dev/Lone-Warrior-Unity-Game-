using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombiescript : MonoBehaviour
{

    Rigidbody2D rb;
    public float speed;
    //Transform target;
    //Transform targetbottom;
    Transform player;
    Vector2 localScale;
    bool facingright;
    Animator anim;


    public bool movingright;

    

    public GameObject corpseleft;
    public GameObject corpseright;
    public GameObject blood;


    public GameObject head;
    public GameObject arm;
    public GameObject foot;
    
           

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //target = GameObject.FindGameObjectWithTag("playerbeacon").GetComponent<Transform>();
        //targetbottom = GameObject.FindGameObjectWithTag("playerbeaconbottom").GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        anim = GetComponent<Animator>();
        localScale = transform.localScale;
        speed = Random.Range(1.3f,1.7f);
        
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("ismoving",(rb.velocity.x!=0)?true:false);
    }

    void LateUpdate()
    {
        if (!movingright)//player.position.x < transform.position.x)
        {
            facingright = false;

        }
        else if (movingright)//player.position.x >= transform.position.x)              // Used to check the direction the player is in and move towards it
        {
            facingright = true;

        }
        if (((facingright) && (localScale.x < 0)) || ((!facingright) && (localScale.x > 0)))
        {
            localScale.x *= -1;
        }
        transform.localScale = localScale;
        //if ((target.position.y >= transform.position.y) && (targetbottom.position.y <= transform.position.y))
        //{
            rb.velocity = new Vector2(localScale.x * speed, rb.velocity.y);
        //}
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="bullet" || collision.gameObject.tag=="shotgunblast")
        {
            playerspawnerscript.enemycount += 1;
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camerascript>().camerashake();
            Destroy(collision.gameObject,0f);
            //Scorescript.scorevalue += 10;
            Instantiate((facingright ? corpseleft : corpseright), transform.position, Quaternion.identity);
            Instantiate(blood, transform.position, Quaternion.identity);
            Destroy(gameObject, 0f);
            
        }
        if (collision.gameObject.tag == "grenade" && (collision.gameObject.GetComponent<grenadescript>().collided == false || collision.gameObject.GetComponent<grenadescript>().grounded == false))
        {
            playerspawnerscript.enemycount += 1;
            //Scorescript.scorevalue += 10;
            Instantiate((facingright ? corpseleft : corpseright), transform.position, Quaternion.identity);
            Instantiate(blood, transform.position, Quaternion.identity);
            Destroy(gameObject, 0f);
        }

        if(collision.gameObject.tag == "wall")
        {
            movingright = (movingright == true) ? false : true;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "grenadeexplosion")
        {
            playerspawnerscript.enemycount += 1;
            //Scorescript.scorevalue += 10;
            //Instantiate((facingright ? corpseleft : corpseright), transform.position, Quaternion.identity);
            Instantiate(head, transform.position, Quaternion.identity);
            Instantiate(arm, transform.position, Quaternion.identity);
            Instantiate(foot, transform.position, Quaternion.identity);
            Instantiate(blood, transform.position, Quaternion.identity);
            Destroy(gameObject, 0f);
        }
    }


}
