using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class fire : NetworkBehaviour{

    public GameObject shockwave;
    private GameObject ship;
    //private int a = 0;
    //public GameObject go;




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




    [SyncVar(hook = "OnPlayerName")]
    public string playername;

    ////float roty;
    ////float rotx;

    //[SyncVar] public string playerUniqueName;
    //private NetworkInstanceId playerNetID;
    //private Transform myTransfrom;

    //public override void OnStartLocalPlayer()
    //{
    //    base.OnStartLocalPlayer();

    //    playername = "Player";

    //    //GetNetIdentity();
    //    //SetIdentity();
    //}

    //private void Awake()
    //{
    //    myTransfrom = transform;
    //}

    //[Client]
    //void GetNetIdentity()
    //{
    //    playerNetID = GetComponent<NetworkIdentity>().netId;
    //    CmdTellServerMyIdentity(MakeUniqueIdentity());
    //}

    //void SetIdentity()
    //{
    //    if (!isLocalPlayer)
    //    {
    //        myTransfrom.name = playerUniqueName;
    //    }
    //    else
    //    {

    //        myTransfrom.name = MakeUniqueIdentity();
    //    }
    //}

    //string MakeUniqueIdentity()
    //{
    //    string uniqueName = "Player" + playerNetID.ToString();
    //    ship = GameObject.Find(uniqueName);
    //    return uniqueName;
    //}

    //[Command]
    //void CmdTellServerMyIdentity(string name)
    //{
    //    playerUniqueName = name;
    //}
    
    void OnPlayerName(string playername)
    {
        Text playerlist = GameObject.Find("playerlist").GetComponent<Text>();
        playerlist.text += playername + "\n";
        ship = GameObject.Find(playername);
    }

    [Command]
    public void CmdPlayerName(string newtext)
    {
//        playername = "client";
        Text playerlist = GameObject.Find("playerlist").GetComponent<Text>();
        playerlist.text = "was client";
    }

    public override void OnStartClient()
    {
        //if (isServer)
        //{
            playername = "Player" + GetComponent<NetworkIdentity>().netId.ToString();
        //}
        //else
        //{
        //    CmdPlayerName("was client");
        //}

    }

    [Command]
    public void Cmdcreateshockwave()
    {

        //var b = this.transform.parent.name;

        GameObject g = GameObject.Find("btnFire");
        g.transform.Translate(0, g.transform.position.y+5, 0);

        int energy = 4;
        float targetTime = 10.0f;
        GameObject eb = new GameObject();
        
        GameObject go = Instantiate(shockwave, this.transform.position, this.transform.rotation);
        
        go.transform.parent = this.transform;

        //Cmdspawn(go);
        NetworkServer.Spawn(go);

        eb = GameObject.Find("energybar");
        
       if (Input.GetMouseButtonDown(0))
        {
            if (energy > 0)
            {
                switch (energy)
                {
                    case 4:
                        Cmdcreateshockwave();
                        eb.transform.localScale = new Vector3(225, eb.transform.localScale.y, eb.transform.localScale.z);
                        energy--;
                        break;
                    case 3:
                        Cmdcreateshockwave();
                        eb.transform.localScale = new Vector3(150, eb.transform.localScale.y, eb.transform.localScale.z);
                        energy--;
                        break;
                    case 2:
                        Cmdcreateshockwave();
                        eb.transform.localScale = new Vector3(75, eb.transform.localScale.y, eb.transform.localScale.z);
                        energy--;
                        break;
                    case 1:
                        Cmdcreateshockwave();
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
    
    public void createshockwave()
    {
        if(!isLocalPlayer)
        { return; }
        

        Cmdcreateshockwave();
    }

    private void Start()
    {
        GetComponentInChildren<Canvas>().enabled = false;

        if (gameObject.GetComponent<NetworkIdentity>().isLocalPlayer)
        {
            GetComponentInChildren<Canvas>().enabled = true;
        }
    }

    private void Update()
    {
        
        //if (myTransfrom.name == "" || myTransfrom.name == "Player(Clone)")
        //{
        //    SetIdentity();
        //}
        //if (go != null && ship != null)
        //{
        //    //Debug.Log("update should be ship: " + go.transform.parent.tag);
        //    go.transform.position = ship.transform.position;
        //}
    }
}