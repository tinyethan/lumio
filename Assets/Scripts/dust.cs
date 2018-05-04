using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dust : MonoBehaviour {

    //public Transform target;
    //public Transform dustparticle;
    public float speed = 1f;
    //private GameObject[] objects;
    //// Use this for initialization
    private GameObject target;
    void Start () {
      ////for(var i = 0; i < 100; i++)
      ////{
      ////    Vector3 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), Camera.main.farClipPlane / 2));
      ////    var particle = Instantiate(dustparticle, screenPosition, Quaternion.identity);
      ////    particle.gameObject.tag = "particle";
      ////}
        target = GameObject.Find("ship");
        
    }
	
	void Update () {
        //float dist = Vector3.Distance(target.transform.position, transform.position);

        //Debug.Log(dist);
        //if(dist < .3)
        //{
        //    float step = speed * Time.deltaTime;

        //    transform.position = Vector2.Lerp(transform.position, target.transform.position, step);
            
        //}
    }
}
