using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class fire : NetworkBehaviour{

    public GameObject shockwave;
    private int a = 0;
    private GameObject eb;

    // Use this for initialization
    void Start () {
       eb = GameObject.Find("energybar");
    }

    // Update is called once per frame
    private int energy = 4;
    private float targetTime = 10.0f;
    void Update () {
        Debug.Log("localscale: " + eb.transform.localScale.x);
        Debug.Log("time: " + targetTime);
        Debug.Log("energy: " + energy);

        if (!isLocalPlayer)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space))
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

    void createshockwave()
    {
        GameObject go = Instantiate(shockwave, transform.position, transform.rotation);
        go.transform.parent = transform;
    }

    private float _currentScale = InitScale;
    private const float TargetScale = 1.1f;
    private const float InitScale = 1f;
    private const int FramesCount = 100;
    private const float AnimationTimeSeconds = 2;
    private float _deltaTime = AnimationTimeSeconds / FramesCount;
    private float _dx = (TargetScale - InitScale) / FramesCount;
    private bool _upScale = true;
    private IEnumerator Breath(GameObject g)
    {
        while (true)
        {
            while (_upScale)
            {
                _currentScale += _dx;
                if (_currentScale > TargetScale)
                {
                    _upScale = false;
                    _currentScale = TargetScale;
                }
                g.transform.localScale = Vector3.one * _currentScale;
                yield return new WaitForSeconds(_deltaTime);
            }

            while (!_upScale)
            {
                _currentScale -= _dx;
                if (_currentScale < InitScale)
                {
                    _upScale = true;
                    _currentScale = InitScale;
                }
                g.transform.localScale = Vector3.one * _currentScale;
                yield return new WaitForSeconds(_deltaTime);
            }
        }
    }

    //IEnumerator Shock()
    //{
    //    Vector3 originalScale = shockwave.transform.localScale;
    //    Debug.Log(originalScale);
    //    Vector3 destinationScale = new Vector3(2.0f, 2.0f, 2.0f);

    //    float currentTime = 0.0f;

    //    do
    //    {
    //        shockwave.transform.localScale = Vector3.Lerp(originalScale, destinationScale, currentTime);
    //        currentTime += Time.deltaTime;
    //        Debug.Log(currentTime);
    //        Debug.Log("a" + originalScale);
    //        yield return null;
    //    } while (currentTime <= 10);


    //}
}
