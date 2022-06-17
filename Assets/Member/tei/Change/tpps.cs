using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tpps : MonoBehaviour
{
    public static int tpss = 0;
    // Start is called before the first frame update
    void Start()
    {
        tpss = PlayerSV.tps1();
        Debug.Log("a"+tpss);
    }

    // Update is called once per frame
    void Update()
    {
        switch (tpss)
        {
            case 1:
                {
                    Vector3 tmp = GameObject.Find("Gate2").transform.position;
                    GameObject.Find("Player").transform.position = new Vector3(tmp.x, tmp.y - 3, tmp.z);
                    tpss = 0;
                    break;
                }
            case 2:
                {
                    Vector3 tmp = GameObject.Find("Gate1").transform.position;
                    GameObject.Find("Player").transform.position = new Vector3(tmp.x+3, tmp.y, tmp.z);
                    tpss = 0;
                    break;
                }            
            //case 3:
            //    {
            //        Vector3 tmp = GameObject.Find("Gate1").transform.position;
            //        GameObject.Find("Player").transform.position = new Vector3(tmp.x+3, tmp.y, tmp.z);
            //        tpss = 0;
            //        break;
            //    }         
            case 4:
                {
                    Vector3 tmp = GameObject.Find("Gate5").transform.position;
                    GameObject.Find("Player").transform.position = new Vector3(tmp.x+3, tmp.y, tmp.z);
                    tpss = 0;
                    break;
                }         
            case 5:
                {
                    Vector3 tmp = GameObject.Find("Gate4").transform.position;
                    GameObject.Find("Player").transform.position = new Vector3(tmp.x+3, tmp.y, tmp.z);
                    tpss = 0;
                    break;
                }
        }
    }
    public static int tps2()
    {
        return tpss;
    }

}

