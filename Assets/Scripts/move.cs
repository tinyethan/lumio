﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class move : NetworkBehaviour {

    public float moveSpeed = 1f;
    public float smoothTimeY;
    public float smoothTimeX;
    //public Camera cam;
    //public GameObject ship;

    // Use this for initialization
    void Start () {
        if (!isLocalPlayer)
        {
            return;
        }
        gameObject.transform.localScale = new Vector3(0.05f, 0.05f, 1);

        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, Camera.main.transform.position.z);

        var mouse = Input.mousePosition;
        mouse = Camera.main.ScreenToWorldPoint(mouse);
        mouse.z = transform.position.z;
        mouse.x = Mathf.Clamp(mouse.x, xMin, xMax);
        mouse.y = Mathf.Clamp(mouse.y, yMin, yMax);

        var distance = Vector3.Distance(gameObject.transform.position, mouse);
        Camera.main.orthographicSize = gameObject.transform.localScale.y * 2 + (distance / 10f);
    }

    // Update is called once per frame
    float yMin = -8f;
    float yMax = 8f;
    float xMin = -8f;
    float xMax = 8f;
    void Update () {
        if (!isLocalPlayer)
        {
            return;
        }
        var mouse = Input.mousePosition;
        var screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.localPosition);
        var offset = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);
        var angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;

        //camera
        //float posX = Mathf.SmoothDamp(transform.position.x, ship.transform.position.x, ref velocity.x, smoothTimeX);

        gameObject.transform.rotation = Quaternion.Euler(0, 0, angle+90);

        mouse = Camera.main.ScreenToWorldPoint(mouse);
        
        mouse.z = transform.position.z;
        mouse.x = Mathf.Clamp(mouse.x, xMin, xMax);
        mouse.y = Mathf.Clamp(mouse.y, yMin, yMax);
    
        gameObject.transform.position = Vector2.Lerp(gameObject.transform.position, mouse, moveSpeed/250);

        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, Camera.main.transform.position.z);
        var distance = Vector3.Distance(gameObject.transform.position, mouse);
        Camera.main.orthographicSize = gameObject.transform.localScale.y * 2 + (distance / 10f);
        //Camera.main.orthographicSize = 5;

    }
}
