using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletexplosionscript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 0.2f);
    }

    
}
