using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class move : NetworkBehaviour {

    public float moveSpeed = 1f;
    public float smoothTimeY;
    public float smoothTimeX;
    float yMin = -8f;
    float yMax = 8f;
    float xMin = -8f;
    float xMax = 8f;
    //public joystick moveJoystick;
    private GameObject joystickcont;
    
    //float velocity = Mathf.Clamp(1, 1, 1);



    //public Camera cam;
    //public GameObject ship;

    // Use this for initialization
    [SyncVar(hook = "OnSetScale")] private Vector3 scale;

    [Command]
    public void CmdSetScale(Vector3 vec)
    {
        this.scale = vec; // This is just to trigger the call to the OnSetScale while encapsulating.
    }
    
    private void OnSetScale(Vector3 vec)
    {
        this.scale = vec;
        this.transform.localScale = vec;
    }

    void Start () {
        CmdSetScale(gameObject.transform.localScale);
        if (!isLocalPlayer)
        {
            return;
        }
        
        joystickcont = GameObject.FindWithTag("JoystickContainer");
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
    
    void Update () {
        CmdSetScale(gameObject.transform.localScale);
        if (!isLocalPlayer)
        {
            return;
        }

        
        Vector3 dir = Vector3.zero;

        dir.x = Input.GetAxis("Horizontal");
        dir.y = Input.GetAxis("Vertical");
        
        joystick moveJoystick = joystickcont.GetComponent<joystick>();

        if (moveJoystick.InputDirection != Vector3.zero)
        {
            dir.x = moveJoystick.InputDirection.x;
            dir.y = moveJoystick.InputDirection.y;
        }
        
        var rb = gameObject.GetComponent<Rigidbody2D>();

        if (dir == Vector3.zero)
        {

        }
        else
        {
            float heading = Mathf.Atan2(dir.x, dir.y);
            transform.rotation = Quaternion.Inverse(Quaternion.Euler(0f, 0f, heading * Mathf.Rad2Deg));
            rb.velocity = new Vector3(dir.x * .2f, dir.y * .2f, 0);
        }

        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, Camera.main.transform.position.z);
        
        //pc input
        //var mouse = Input.mousePosition;
        //var screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.localPosition);
        //var offset = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);
        //var angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;

        ////camera
        ////float posX = Mathf.SmoothDamp(transform.position.x, ship.transform.position.x, ref velocity.x, smoothTimeX);

        //gameObject.transform.rotation = Quaternion.Euler(0, 0, angle+90);

        //mouse = Camera.main.ScreenToWorldPoint(mouse);
        
        //mouse.z = transform.position.z;
        //mouse.x = Mathf.Clamp(mouse.x, xMin, xMax);
        //mouse.y = Mathf.Clamp(mouse.y, yMin, yMax);
    
        //gameObject.transform.position = Vector2.Lerp(gameObject.transform.position, mouse, moveSpeed/250);

        //Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, Camera.main.transform.position.z);
        //var distance = Vector3.Distance(gameObject.transform.position, mouse);
        //Camera.main.orthographicSize = gameObject.transform.localScale.y * 2 + (distance / 10f);
        ////Camera.main.orthographicSize = 5;

    }
}
