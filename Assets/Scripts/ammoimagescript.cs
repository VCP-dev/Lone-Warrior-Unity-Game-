using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ammoimagescript : MonoBehaviour
{
    Image ammoimage;

    public static Sprite ICON;


    // Start is called before the first frame update
    void Start()
    {
        ammoimage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        ammoimage.sprite = ICON;
    }
}
