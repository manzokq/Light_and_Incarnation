using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ga : MonoBehaviour
{

    En en;

    private void Start()
    {
        en=new En();
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("aaa");
        en.G();
    }

}
