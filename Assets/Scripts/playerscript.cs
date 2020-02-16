using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
//using Photon.Pun;




/// PLEASE NOTE:
/// 
/// Controls are currently set for mobile
/// 



//EXTRA NOTE:

//PUN was added for multiplayer which did not work..... most of it has been commented out





public class playerscript :  MonoBehaviour  //MonoBehaviourPun, IPunObservable
{

    Rigidbody2D rb;
    Vector2 localScale;
    Animator anim;
    Vector2 bulletpos;                                           // Note:       Maccho celebration is mapped to 'Right control'
    public static bool facingRight = true;                                     // Note:       Shooting is mapped to 'Z' and 'Down Arrow'
    float dirX;

    float firerate;
    float nextfire=0f;

    GameObject bulletleft, bulletright;
    //public GameObject grenade;


    public float jumpforce;
    public float moveSpeed;
    bool isgrounded;


    public GameObject Bulletleft, Bulletright;
    public GameObject Rocketleft, RocketRight;
    public GameObject Shotgunblastleft, Shotgunblastright;


    public GameObject corpseleft, corpseright;
    public GameObject blood;


    public static int playerhealth;

    
    public Sprite bullets;
    public Sprite rockets;
    public Sprite shotgunshells;


    int grenadecount;

    bool ispaused;
    GameObject pausemenu;


    // for multiplayer

    ///public PhotonView photonView;

    public GameObject sceneCamera;
    public GameObject playerCamera;

        

    // Start is called before the first frame update
    void Start()
    {
        //if (photonView.IsMine)
        //{
            //sceneCamera = GameObject.FindGameObjectWithTag("MainCamera");
           // playerCamera.SetActive(true);
           // playerCamera.transform.position = sceneCamera.transform.position;
           // sceneCamera.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        localScale = transform.localScale;
        anim = GetComponent<Animator>();
        isgrounded = false;
        setammotype("bullets");
        playerhealth = 100;
        grenadecount = 2;
        anim.SetBool("isjumping", true);
        ispaused = false;
        Time.timeScale = 1;
        pausemenu = GameObject.FindGameObjectWithTag("pause");
        pausemenu.SetActive(false);
        //}        
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKey(KeyCode.E))
        //{
        //    Application.Quit();
        //}

        //if(photonView.IsMine)
        //{
            ProcessInputs();
        //}
       
        //else
        //{
        //    smoothMovement();
        //}



        //if (playerhealth <= 0)
        //{
        //    Instantiate(((facingRight == true) ? corpseright : corpseleft), transform.position, Quaternion.identity);
        //    Destroy(gameObject, 0f);
        //}

        //if ((Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.Z)) && Time.time > nextfire)
        //{
        //    anim.SetBool("ishootingstanding", true);
        //    nextfire = Time.time + firerate;
        //    fire();
        //}
        //else
        //{
        //    anim.SetBool("ishootingstanding", false);
        //}
        //if ((Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.Z)) && Time.time > nextfire && !isgrounded)
        //{
        //    anim.SetBool("ishootingjumping", true);
        //    nextfire = Time.time + firerate;
        //    fire();
        //}
        //else
        //{
        //    anim.SetBool("ishootingjumping", false);
        //}
        //if ((Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.RightShift)) && grenadecount > 0)
        //{
        //    Instantiate(grenade, transform.position, Quaternion.identity);
        //    grenadecount -= 1;
        //}
        //if (Input.GetKey(KeyCode.RightControl))
        //{
        //    anim.SetBool("isflexing", true);
        //}
        //else
        //{
        //    anim.SetBool("isflexing", false);
        //}
        //if (isgrounded)
        //{
        //    anim.SetBool("isjumping", false);
        //    if (Input.GetKeyDown(KeyCode.UpArrow) && isgrounded)
        //    {
        //        rb.AddForce(Vector2.up * jumpforce);
        //        anim.SetBool("isjumping", true);
        //        isgrounded = false;
        //    }
        //    if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        //    {
        //        anim.SetBool("isrunning", true);
        //    }
        //    else
        //    {
        //        anim.SetBool("isrunning", false);
        //    }
        //}

    }

    //private void smoothMovement()
    //{

    //}


    private void ProcessInputs()
    {
        ///// from fixedupdate method
        //dirX = Input.GetAxisRaw("Horizontal") * moveSpeed;
        //rb.velocity = new Vector2(dirX, rb.velocity.y);


        ///// from lateupdate method
        //if (photonView.IsMine)
        //{
        //    if (dirX > 0)
        //    {
        //        facingRight = true;
        //    }
        //    else if (dirX < 0)
        //    {
        //        facingRight = false;
        //    }
        //    if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
        //    {
        //        localScale.x *= -1;
        //    }
        //    transform.localScale = localScale;
        //}

        if(Input.GetKeyDown(KeyCode.E))
        {
            Application.Quit();
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            ispaused = (ispaused == true) ? false : true;
            if(ispaused)
            {
                pausemenu.SetActive(true);
                Time.timeScale = 0;                
            }
            else
            {
                pausemenu.SetActive(false);
                Time.timeScale = 1;
            }
        }


        if (playerhealth <= 0)
        {
            Instantiate(((facingRight == true) ? corpseright : corpseleft), transform.position, Quaternion.identity);
            Destroy(gameObject, 0f);
        }

        if (CrossPlatformInputManager.GetButton("Shoot")/*(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.Z))*/ && Time.time > nextfire)
        {
            anim.SetBool("ishootingstanding", true);
            nextfire = Time.time + firerate;
            fire();
        }
        else
        {
            anim.SetBool("ishootingstanding", false);
        }
        if (CrossPlatformInputManager.GetButton("Shoot")/*(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.Z))*/ && Time.time > nextfire && !isgrounded)
        {
            anim.SetBool("ishootingjumping", true);
            nextfire = Time.time + firerate;
            fire();
        }
        else
        {
            anim.SetBool("ishootingjumping", false);
        }
        //if ((Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.RightShift)) && grenadecount > 0)
        //{
        //    Instantiate(grenade, transform.position, Quaternion.identity);
        //    grenadecount -= 1;
        //}
        if (Input.GetKey(KeyCode.RightControl))
        {
            anim.SetBool("isflexing", true);
        }
        else
        {
            anim.SetBool("isflexing", false);
        }
        if (isgrounded)
        {
            anim.SetBool("isjumping", false);
            if (CrossPlatformInputManager.GetButtonDown("Jump")/*Input.GetKeyDown(KeyCode.UpArrow)*/ && isgrounded)
            {
                rb.AddForce(Vector2.up * jumpforce);
                anim.SetBool("isjumping", true);
                isgrounded = false;
            }
            if (dirX != 0/*Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)*/)
            {
                anim.SetBool("isrunning", true);
            }
            else
            {
                anim.SetBool("isrunning", false);
            }
        }
    }


    public void setammotype(string ammotype)
    {
        switch(ammotype)
        {
            case "rockets":
                bulletleft = Rocketleft;
                bulletright = RocketRight;
                firerate = 0.23f;
                ammoimagescript.ICON = rockets;
                break;
            case "shotgunshells":
                bulletleft = Shotgunblastleft;
                bulletright = Shotgunblastright;
                firerate = 0.09f;
                ammoimagescript.ICON = shotgunshells;
                break;
            case "bullets":
                bulletleft = Bulletleft;
                bulletright = Bulletright;
                firerate = 0.078f;
                ammoimagescript.ICON = bullets;
                break;
        }
    }



    private void FixedUpdate()
    {
        //if (photonView.IsMine)
        //{
            dirX = CrossPlatformInputManager.GetAxisRaw("Horizontal") * moveSpeed;  //Input.GetAxisRaw("Horizontal") * moveSpeed;
            rb.velocity = new Vector2(dirX, rb.velocity.y);
        //}
    }

    private void LateUpdate()
    {
        //if (photonView.IsMine)
        //{
            if (dirX > 0)
            {
                facingRight = true;
            }
            else if (dirX < 0)
            {
                facingRight = false;
            }
            if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
            {
                localScale.x *= -1;
            }
            transform.localScale = localScale;
        //}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("ground") || collision.gameObject.CompareTag("indestructibleground"))
        {
            isgrounded = true;
        }
        if(collision.gameObject.tag=="cyborglaser")
        {
            playerhealth -= 50;
            Destroy(collision.gameObject, 0f);
        }
        if(collision.gameObject.tag=="zombie")
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camerascript>().camerashake();
            Instantiate((facingRight ? corpseleft : corpseright), transform.position, Quaternion.identity);
            Instantiate(blood, transform.position, Quaternion.identity);
            Destroy(gameObject, 0f);
        }
        
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "grenadeexplosion")
    //    {
    //        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camerascript>().camerashake();
    //        Instantiate((facingRight ? corpseleft : corpseright), transform.position, Quaternion.identity);
    //        Instantiate(blood, transform.position, Quaternion.identity);
    //        Destroy(gameObject, 0f);
    //    }
    //}


    void fire()
    {
        bulletpos = transform.position;
        if (facingRight)
        {
            bulletpos += new Vector2(+0.25f, -0.03f);
            Instantiate(bulletright, bulletpos, Quaternion.identity);
        }
        else
        {
            bulletpos += new Vector2(-0.25f, -0.03f);
            Instantiate(bulletleft, bulletpos, Quaternion.identity);
        }
    }

    //public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    //{
    //    if(stream.IsWriting)
    //    {
    //        stream.SendNext(transform.position);
    //    }
    //    else if(stream.IsReading)
    //    {
    //        stream.ReceiveNext();
    //    }
    //}
}
