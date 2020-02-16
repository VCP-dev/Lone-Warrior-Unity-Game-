using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerascript : MonoBehaviour
{

    Transform target;

    Vector3 nextpos,origpos;

    private void Start()
    {
        origpos = transform.position;
        nextpos = new Vector3(origpos.x + 0.05f, origpos.y, origpos.z);
    }


    // Update is called once per frame
    void Update()
    {
        ////target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        ////nextpos = new Vector3(transform.position.x + 0.11f, target.position.y + 0.213f, -7);
        ////if (target.gameObject != null)
        ////{            
        ////    transform.position = new Vector3(transform.position.x, target.position.y+0.213f, -7);
        ////}
        ////else
        ////{
        ////    transform.position = nextpos;
        ////}
        ///
                      
    }

    public void camerashake()
    {
        gameObject.transform.position = nextpos;
        Invoke("Moveback", 0.096f);
    }

    private void Moveback()
    {
        gameObject.transform.position = origpos;
    }
}
