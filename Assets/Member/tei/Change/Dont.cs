using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dont : MonoBehaviour
{
    // Start is called before the first frame update
    public static Dont instance = null;

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
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
