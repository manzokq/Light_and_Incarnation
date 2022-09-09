using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadCheck : MonoBehaviour
{
    private string ceilingTag = "Wall";
    private string groundTag = "Ground";
    public static bool heading = false;
    private bool isHeadEnter, isHeadStay, isHeadExit;
    public bool IsHead()
    {
        //Debug.Log(isWall);
        if (isHeadEnter || isHeadStay)
        {
            heading = true;
        }
        else if (isHeadExit)
        {
            heading = false;
        }
        isHeadEnter = false;
        isHeadStay = false;
        isHeadExit = false;
        return heading;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == ceilingTag)
        {
            //Debug.Log("true����");
            isHeadEnter = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == ceilingTag)
        {
            //Debug.Log("true����");
            isHeadStay = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == ceilingTag)
        {
            //Debug.Log("false����");
            isHeadExit = true;
        }
    }
}
