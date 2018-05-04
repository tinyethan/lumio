using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class main : NetworkBehaviour {

    private GameObject[] levelones;
    public GameObject dustparticle;
    public GameObject background;
    
    // Use this for initialization
    void Start () {
        ////RectTransform rt = (RectTransform)background.transform;

        ////float width = rt.rect.width;
        ////float height = rt.rect.height;

        //levelones = GameObject.FindGameObjectsWithTag("level1");
        //foreach (GameObject a in levelones)
        //{
        //    a.SetActive(false);
        //}

        ////create particles
        //for (var i = 0; i < 1000; i++)
        //{
        //    //Vector3 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), Camera.main.farClipPlane / 2));

        //    Vector3 screenPosition = new Vector3(Random.Range(-25, 25), Random.Range(-15, 15), 0);
        //    var particle = Instantiate(dustparticle, screenPosition, Quaternion.identity);
        //    particle.gameObject.tag = "particle";
        //}
        
        for (int i = 0; i < 2000; i++)
        {
            //var spawnPosition = new Vector3(
            //    Random.Range(-8.0f, 8.0f),
            //    0.0f,
            //    Random.Range(-8.0f, 8.0f));

            //var spawnRotation = Quaternion.Euler(
            //    0.0f,
            //    Random.Range(0, 180),
            //    0.0f);

            //var enemy = (GameObject)Instantiate(dustparticle, spawnPosition, spawnRotation);
            //NetworkServer.Spawn(enemy);
            float x = Random.Range(-40f, 40f);
            float y = Random.Range(-20f, 20f);

            Vector3 screenPosition = new Vector3(x, y, 0);
            var enemy = Instantiate(dustparticle, screenPosition, Quaternion.identity);

            enemy.gameObject.tag = "particle";
            //NetworkServer.Spawn(enemy);

            ////#if UNITY_ANDROID || UNITY_IOS
            //            if (unity)
            //            {
            //                GUIStyle buttonStyle = GUI.skin.button;
            //                buttonStyle.normal.textColor = Color.white;
            //                buttonStyle.fontSize = 30;
            //                GUI.skin.textField.fontSize = 30;

            //                float wr = 3.5f;
            //                float hr = 3.5f;
            //                const float sr = 4.0f;
            //            }
            //            else
            //            {
            //                float wr = 1.0f;
            //                float hr = 1.0f;
            //                const float sr = 1.0f;
            //            }
#if UNITY_ANDROID && !UNITY_EDITOR
            GUIStyle buttonStyle = GUI.skin.button;
            buttonStyle.normal.textColor = Color.white;
            buttonStyle.fontSize = 300;
            GUI.skin.textField.fontSize = 300;

            float wr = 3.5f;
            float hr = 3.5f;
            const float sr = 4.0f;
#endif
        }
    }

    //public override void OnStartServer()
    //{
    //    Debug.Log("asdf");
    //    for (int i = 0; i < 1000; i++)
    //    {
    //        //var spawnPosition = new Vector3(
    //        //    Random.Range(-8.0f, 8.0f),
    //        //    0.0f,
    //        //    Random.Range(-8.0f, 8.0f));

    //        //var spawnRotation = Quaternion.Euler(
    //        //    0.0f,
    //        //    Random.Range(0, 180),
    //        //    0.0f);

    //        //var enemy = (GameObject)Instantiate(dustparticle, spawnPosition, spawnRotation);
    //        //NetworkServer.Spawn(enemy);

    //        Vector3 screenPosition = new Vector3(Random.Range(-25, 25), Random.Range(-15, 15), 0);
    //        var enemy = Instantiate(dustparticle, screenPosition, Quaternion.identity);

    //        enemy.gameObject.tag = "particle";
    //        NetworkServer.Spawn(enemy);
    //    }
    //}

    // Update is called once per frame
    void Update () {
        int particles = GameObject.FindGameObjectsWithTag("particle").Length;

        for(int i = 0; i < 2000-particles; i++)
        {
            float x = Random.Range(-40f, 40f);
            float y = Random.Range(-20f, 20f);

            Vector3 screenPosition = new Vector3(x, y, 0);
            var enemy = Instantiate(dustparticle, screenPosition, Quaternion.identity);

            enemy.gameObject.tag = "particle";
        }
    }
}
