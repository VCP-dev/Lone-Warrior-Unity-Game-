using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercamera : MonoBehaviour
{

    Vector3 characterpos;
    Transform origlocalscale;
    Transform character;

    // Start is called before the first frame update
    void Start()
    {
        character = transform.parent.gameObject.transform;
        origlocalscale = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(character.position.x,character.position.y,-7);
        //transform.localScale = origlocalscale.localScale;
    }
}
