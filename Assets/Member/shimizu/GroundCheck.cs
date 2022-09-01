using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    ���ɂł���������
 */
public class GroundCheck : MonoBehaviour
{
    private string groundTag = "Ground";
    private bool isGround = false;
    private bool isGroundEnter, isGroundStay, isGroundExit;

    //�ڒn�����Ԃ�
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
    //�ȉ��ڒn����
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("true����");
        if (collision.tag == groundTag)
        {
            isGroundEnter = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log("true����");
        if (collision.tag == groundTag)
        {
            isGroundStay = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log("false����");
        if (collision.tag == groundTag)
        {
            isGroundExit = true;
        }
    }
}
