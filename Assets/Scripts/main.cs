using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class main : NetworkBehaviour {

    private GameObject[] levelones;
    public GameObject dustparticle;
    public GameObject nebula1;
    public GameObject nebula2;
    public GameObject nebula3;

    // Use this for initialization
    void Start () {
        levelones = GameObject.FindGameObjectsWithTag("level1");
        foreach (GameObject a in levelones)
        {
            a.SetActive(false);
        }
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

        for (int i = 0; i < 1000; i++)
        {
            float x = Random.Range(-8f, 8f);
            float y = Random.Range(-8f, 8f);

            Vector3 screenPosition = new Vector3(x, y, 0);
            var enemy = Instantiate(dustparticle, screenPosition, Quaternion.identity);

            enemy.gameObject.tag = "particle";
        }

        for (int i = 0; i < 20; i++)
        {
            int r = Random.Range(1, 3);
            float x = Random.Range(-8f, 8f);
            float y = Random.Range(-8f, 8f);
            Vector3 randomscale = new Vector3(r*3, r*3, 1);
            Vector3 screenPosition = new Vector3(x, y, 0);
            var blob = new GameObject();

            switch (r)
            {
                case 3:
                    blob = Instantiate(nebula3, screenPosition, Quaternion.identity);
                    blob.transform.localScale = randomscale;
                    break;
                case 2:
                    blob = Instantiate(nebula2, screenPosition, Quaternion.identity);
                    blob.transform.localScale = randomscale;
                    break;
                case 1:
                    blob = Instantiate(nebula1, screenPosition, Quaternion.identity);
                    blob.transform.localScale = randomscale;
                    break;
                default:
                    Debug.Log("Default case");
                    break;
            }
            
        }

    }
    
    void Update () {
        int particles = GameObject.FindGameObjectsWithTag("particle").Length;

        for(int i = 0; i < 1000-particles; i++)
        {
            float x = Random.Range(-8f, 8f);
            float y = Random.Range(-8f, 8f);

            Vector3 screenPosition = new Vector3(x, y, 0);
            var enemy = Instantiate(dustparticle, screenPosition, Quaternion.identity);
            //float sizex = enemy.transform.localScale.x * (GameObject.Find("ship").transform.localScale.x*1);
            //float sizey = enemy.transform.localScale.y * (GameObject.Find("ship").transform.localScale.y*1);
            //enemy.transform.localScale = new Vector3(sizex, sizey, 1);
            enemy.gameObject.tag = "particle";
        }
    }
}
