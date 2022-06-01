using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //�ړ��X�e
    private float speed = 0.05f;

    void Start()
    {
    }

    void Update()
    {
        Vector2 position = transform.position;

        //�ړ��L�[  
        if (Input.GetKey("a"))
        {
            position.x -= speed;
        }
        else if (Input.GetKey("d"))
        {
            position.x += speed;
        }
        else if (Input.GetKey("w"))
        {
            position.y += speed;
        }
        else if (Input.GetKey("s"))
        {
            position.y -= speed;
        }

        transform.position = position;
    }
}
