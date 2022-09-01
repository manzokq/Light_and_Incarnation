using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadCheck : MonoBehaviour
{
    private string ceilingTag = "Wall";
    private string groundTag = "Ground";
    public static bool heading = false;
    private void Update()
    {
       // Debug.Log(heading);
    }
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("ccc");
        if(collision.tag == ceilingTag)
        {
            heading = true;
        }
        if(collision.tag == groundTag)
        {
            heading = true;
        }
    }
}
