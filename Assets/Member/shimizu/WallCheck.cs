using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
    éËÅHÇ…Ç≠Ç¡Ç¬ÇØÇƒ
 */
public class WallCheck : MonoBehaviour
{
    private string wallTag = "Wall";
    public static bool isWall = false;
    private bool isWallEnter, isWallStay, isWallExit;

    public bool IsWall()
    {
        //Debug.Log(isWall);
        if (isWallEnter || isWallStay)
        {
            isWall = true;
        }
        if (isWallExit)
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
        //Debug.Log("trueÇæÇÊ");
            isWallEnter = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == wallTag)
        {
        //Debug.Log("trueÇæÇÊ");
            isWallStay = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == wallTag)
        {
        //Debug.Log("falseÇæÇÊ");
            isWallExit = true;
        }
    }
}
