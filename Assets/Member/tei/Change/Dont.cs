using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dont : MonoBehaviour
{
    // Start is called before the first frame update
    public static Dont instance = null;

    //Canvas canvas;
    

    private void Awake()
    {
        if(instance ==null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        //canvas = GetComponent<Canvas>().renderMode.;

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
