using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
    手？にくっつけて
 */
public class WallCheck : MonoBehaviour
{
    private string wallTag = "Wall";
    private bool isWall = false;
    private bool isWallEnter, isWallStay, isWallExit;

    public bool IsWall()
    {
        //Debug.Log(isWall);
        if (isWallEnter || isWallStay)
        {
            isWall = true;
        }
        else if (isWallExit)
        {
            isWall = false;
        }
        isWallEnter = false;
        isWallStay = false;
        isWallExit = false;
        return isWall;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == wallTag)
        {
        //Debug.Log("trueだよ");
            isWallEnter = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == wallTag)
        {
        //Debug.Log("trueだよ");
            isWallStay = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == wallTag)
        {
        //Debug.Log("falseだよ");
            isWallExit = true;
        }
    }
}
