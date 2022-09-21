using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
    ��H�ɂ�������
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
        //Debug.Log("true����");
            isWallEnter = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == wallTag)
        {
        //Debug.Log("true����");
            isWallStay = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == wallTag)
        {
        //Debug.Log("false����");
            isWallExit = true;
        }
    }
}
