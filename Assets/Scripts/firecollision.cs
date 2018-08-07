using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class firecollision : NetworkBehaviour
{

    void Start()
    {
        if (!isLocalPlayer) { return; }
        var a = transform.parent;
        var b = transform.parent.name;
        Physics2D.IgnoreCollision(transform.parent.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("should be ship: " + collision.gameObject.tag);
        Debug.Log("should be shockwave: " + gameObject.tag);
        if (collision.gameObject.tag == "ship" && gameObject.tag == "shockwave")
        {
            grow(-(collision.gameObject.transform.localScale * 0.1f), collision.gameObject);
            grow(collision.gameObject.transform.localScale * 0.1f, gameObject.transform.parent.gameObject);
        }
        
    }

    void grow(Vector3 amount, GameObject target)
    {
        target.transform.localScale += amount;
    }
}
