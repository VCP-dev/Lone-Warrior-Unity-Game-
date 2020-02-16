using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleporterscript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject teleportedobject = collision.gameObject;
        teleportedobject.transform.position = new Vector2(transform.position.x, transform.position.y + 6.78f);
    }
}
