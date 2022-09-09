using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    ‘«‚É‚Å‚à‚­‚Á‚Â‚¯‚Ä
 */
public class GroundCheck : MonoBehaviour
{
    private string groundTag = "Ground";
    private bool isGround = false;
    private bool isGroundEnter, isGroundStay, isGroundExit;

    //Ú’n”»’è‚ğ•Ô‚·
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
    //ˆÈ‰ºÚ’n”»’è
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("true‚¾‚æ");
        if (collision.tag == groundTag)
        {
            isGroundEnter = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log("true‚¾‚æ");
        if (collision.tag == groundTag)
        {
            isGroundStay = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log("false‚¾‚æ");
        if (collision.tag == groundTag)
        {
            isGroundExit = true;
        }
    }
}
