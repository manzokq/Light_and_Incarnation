using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    足にでもくっつけて
 */
public class GroundCheck : MonoBehaviour
{
    private string groundTag = "Ground";
    private bool isGround = false;
    private bool isGroundEnter, isGroundStay, isGroundExit;

    //接地判定を返す
    public bool IsGround()
    {
        if (isGroundEnter || isGroundStay)
        {
            isGround = true;
        }
        else if(isGroundExit)
        {
            isGround = false;
        }
        isGroundEnter = false;
        isGroundStay = false;
        isGroundExit = false;
        return isGround;
    }
    //以下接地判定
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(isGround);
        if (collision.tag == groundTag)
        {
            isGroundEnter = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log(isGround);
        if (collision.tag == groundTag)
        {
            isGroundStay = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log(isGround);
        if (collision.tag == groundTag)
        {
            isGroundExit = true;
        }
    }
}
