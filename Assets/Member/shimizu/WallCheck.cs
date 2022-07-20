using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
    éËÅHÇ…Ç≠Ç¡Ç¬ÇØÇƒ
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
        //Debug.Log(isGround);
        if (collision.tag == wallTag)
        {
            isWallEnter = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log(isGround);
        if (collision.tag == wallTag)
        {
            isWallStay = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log(isWall);
        if (collision.tag == wallTag)
        {
            isWallExit = true;
        }
    }
}
