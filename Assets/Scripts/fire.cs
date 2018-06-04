using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class fire : NetworkBehaviour{

    public GameObject shockwave;
    public GameObject ship;
    //private int a = 0;
    
    //private GameObject go;

    //float roty;
    //float rotx;
 
    

    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
        gameObject.name = "Local";
    }

    [Command]
    public void Cmdspawn(GameObject go)
    {
        NetworkServer.Spawn(go);
    }

    public void createshockwave()
    {
        int energy = 4;
        float targetTime = 10.0f;
        GameObject eb = new GameObject();
        ship = GameObject.Find("Local");

        Debug.Log(ship);
        //if (!ship.GetComponent<NetworkIdentity>().isLocalPlayer)
        //{
        //    return;
        //}
        
        GameObject go = Instantiate(shockwave, ship.transform.position, ship.transform.rotation);
        go.transform.parent = ship.transform;
        Cmdspawn(go);

        eb = GameObject.Find("energybar");
        
       if (Input.GetMouseButtonDown(0))
        {
            if (energy > 0)
            {
                switch (energy)
                {
                    case 4:
                        createshockwave();
                        eb.transform.localScale = new Vector3(225, eb.transform.localScale.y, eb.transform.localScale.z);
                        energy--;
                        break;
                    case 3:
                        createshockwave();
                        eb.transform.localScale = new Vector3(150, eb.transform.localScale.y, eb.transform.localScale.z);
                        energy--;
                        break;
                    case 2:
                        createshockwave();
                        eb.transform.localScale = new Vector3(75, eb.transform.localScale.y, eb.transform.localScale.z);
                        energy--;
                        break;
                    case 1:
                        createshockwave();
                        eb.transform.localScale = new Vector3(1, eb.transform.localScale.y, eb.transform.localScale.z);
                        energy--;
                        break;
                    default:
                        Debug.Log("Default case");
                        break;
                }
            }
        }

        if (energy < 4)
        {
            targetTime -= Time.deltaTime;
            if (targetTime <= 0.0f)
            {
                targetTime = 10.0f;
                energy++;

                switch (energy)
                {
                    case 4:
                        Debug.Log("case 4: " + eb.transform.localScale.x);
                        eb.transform.localScale = new Vector3(300, eb.transform.localScale.y, eb.transform.localScale.z);

                        break;
                    case 3:
                        Debug.Log("case 3: " + eb.transform.localScale.x);
                        eb.transform.localScale = new Vector3(225, eb.transform.localScale.y, eb.transform.localScale.z);

                        break;
                    case 2:
                        Debug.Log("case 2: " + eb.transform.localScale.x);
                        eb.transform.localScale = new Vector3(150, eb.transform.localScale.y, eb.transform.localScale.z);

                        break;
                    case 1:
                        Debug.Log("case 1: " + eb.transform.localScale.x);
                        eb.transform.localScale = new Vector3(75, eb.transform.localScale.y, eb.transform.localScale.z);

                        break;
                    default:
                        Debug.Log("Default case");
                        break;
                }
            }

        }
        
    }

    //private void Update()
    //{
    //    if (go != null)
    //    {
    //        Debug.Log("update should be ship: " + go.transform.parent.tag);
    //        go.transform.position = ship.transform.position;
    //    }
    //}
}
