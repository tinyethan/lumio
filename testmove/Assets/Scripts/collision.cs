using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class collision : NetworkBehaviour
{
    private int size = 0;
    private GameObject[] levelones;
	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    //private void OnCollisionEnter2D(Collision2D collision)
    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "particle")
        {
            Destroy(collision.gameObject);
            grow(new Vector3(0.01F, 0.01F, 0.01F));
        }

    }

    void grow(Vector3 increase)
    {
        
        size++;
        transform.localScale += increase;
        if(size > 10)
        {
            levelones = GameObject.FindGameObjectsWithTag("level1");
            foreach (GameObject a in levelones)
            {
                a.SetActive(true);
            }
        }
        if (size > 999 && size < 5000)
        {
            //levelones = GameObject.FindGameObjectsWithTag("level1");
            //foreach (GameObject a in levelones)
            //{
            //    a.SetActive(true);
            //}
        }
        if (size > 4999 && size < 50000)
        {
            //levelones = GameObject.FindGameObjectsWithTag("level1");
            //foreach (GameObject a in levelones)
            //{
            //    a.SetActive(true);
            //}
        }
    }
}
