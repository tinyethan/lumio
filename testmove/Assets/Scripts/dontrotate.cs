using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontrotate : MonoBehaviour {

	// Use this for initialization
	Quaternion iniRot;

    void Start () { 
		iniRot = transform.rotation;
	}
    
    void LateUpdate()
    {
        transform.rotation = iniRot;
    }
}
